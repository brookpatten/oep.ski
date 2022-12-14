using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

using NUnit.Framework;
using Amphibian.Oep.Configuration;
using Dapper;
using Amphibian.Oep.Persistence.Migrations;
using System.Data;
using Microsoft.Extensions.Configuration;
using ThrowawayDb;

namespace Amphibian.Oep.Tests.Repositories
{
    [TestFixture(Category = "Persistence")]
    public abstract class DatabaseConnectedTestFixture
    {
        private string _connectionString;
        protected SqlConnection _connection;
        private string _databaseName;
        private SqlConnectionStringBuilder _connectionStringBuilder;
        private const string _dbOpsDb = "master";
        private OepApiConfiguration _configuration;
        private DateTime _runTime;

        private ThrowawayDatabase _throwaway;

        [OneTimeSetUp]
        public void BaseOneTimeSetUp()
        {
            //find the config for the app
            var configurations = OepApiConfiguration.LoadFromJsonConfig(null,Path.Combine(Directory.GetCurrentDirectory(), "../../../../Amphibian.Oep.Api"));
            this._configuration = configurations.Item2;

            //reformat the existing connection string to connect to the master db (not strictly necassary, but mast always exists, the app db doesn't)
            
            _runTime = DateTime.Now;
        }

        private bool UseThrowawayDb
        {
            get
            {
                return string.IsNullOrEmpty(_configuration.Test.ConnectionString);
            }
        }

        [SetUp]
        public void BaseSetUp()
        {
            if (UseThrowawayDb)
            {
                _throwaway = ThrowawayDatabase.Create("Server=(localdb)\\mssqllocaldb;Trusted_Connection=True;MultipleActiveResultSets=true");
                _connectionString = _throwaway.ConnectionString;
            }
            else
            {
                _connectionStringBuilder = new SqlConnectionStringBuilder(_configuration.Test.ConnectionString);
                //create a connection string to a database we know exists, but is not the db we intend to create/drop
                _connectionStringBuilder.InitialCatalog = _dbOpsDb;
                _connectionString = _connectionStringBuilder.ToString();

                //connect to master and create our test database
                _databaseName = $"{NUnit.Framework.TestContext.CurrentContext.Test.ClassName.Substring(NUnit.Framework.TestContext.CurrentContext.Test.ClassName.LastIndexOf(".") + 1)}-{NUnit.Framework.TestContext.CurrentContext.Test.MethodName}";
                _connection = new SqlConnection(_connectionString);
                _connection.Open();
                _connection.Execute($"create database [{_databaseName}]");
                _connection.Close();
                _connection.Dispose();

                //reformat the connection sring to point to the test database
                _connectionStringBuilder.InitialCatalog = _databaseName;
                _connectionString = _connectionStringBuilder.ToString();
            }

            //run migrations on the test database - with initial data - with test data
            MigrationRunner.RunMigrationsThrowOnException(_connectionString, true, true);

            //initialize the test connection to use the test database
            _connection = new SqlConnection(_connectionString);
        }

        internal SqlConnection CreateAdditionalConnection()
        {
            return new SqlConnection(_connectionString);
        }

        [TearDown]
        public void BaseTearDown()
        {
            if (UseThrowawayDb)
            {
                if (_connection != null)
                {
                    _connection.Close();
                    _connection.Dispose();
                }
                if (_throwaway != null)
                {
                    _throwaway.Dispose();
                    _throwaway = null;
                }
            }
            else
            {
                _connection.Close();
                _connection.Dispose();

                _connectionStringBuilder.InitialCatalog = _dbOpsDb;
                _connectionString = _connectionStringBuilder.ToString();
                _connection = new SqlConnection(_connectionString);
                _connection.Execute($"alter database [{_databaseName}] set single_user with rollback immediate");

                if (_configuration.Test.OnPersistenceTestCompletion == TestConfiguration.PersistenceTestCompletionAction.DropOnComplete)
                {
                    Drop(_connection, _databaseName);
                }
                else if (_configuration.Test.OnPersistenceTestCompletion == TestConfiguration.PersistenceTestCompletionAction.RenameOnComplete)
                {
                    _databaseName = RenameWithRunTime(_connection, _databaseName, _runTime);
                }
                else if (_configuration.Test.OnPersistenceTestCompletion == TestConfiguration.PersistenceTestCompletionAction.DropIfSuccessRenameIfFailures)
                {
                    if (NUnit.Framework.TestContext.CurrentContext.Result.Outcome == NUnit.Framework.Interfaces.ResultState.Failure)
                    {
                        _databaseName = RenameWithRunTime(_connection, _databaseName, _runTime);
                    }
                    else
                    {
                        Drop(_connection, _databaseName);
                    }
                }
                else if (_configuration.Test.OnPersistenceTestCompletion == TestConfiguration.PersistenceTestCompletionAction.DropIfSuccess)
                {
                    if (NUnit.Framework.TestContext.CurrentContext.Result.Outcome == NUnit.Framework.Interfaces.ResultState.Success)
                    {
                        Drop(_connection, _databaseName);
                    }
                }
                else
                {
                    throw new InvalidOperationException("Unknown PersistenceTestCompletionAction");
                }

                _connection.Close();
                _connection.Dispose();
            }
            

            _databaseName = "";
            _connectionString = "";
            _connection = null;
        }

        private void Drop(IDbConnection connection,string databaseName)
        {
            connection.Execute($"drop database [{databaseName}]");
        }

        private string RenameWithRunTime(IDbConnection connection, string databaseName, DateTime runTime)
        {
            var newDatabaseName = $"{runTime.Year:0000}{runTime.Month:00}{runTime.Day:00}-{runTime.Hour:00}{runTime.Minute:00}{runTime.Second:00}-{runTime.Millisecond:0000}-{databaseName}";
            connection.Execute($"ALTER DATABASE [{databaseName}] MODIFY NAME = [{newDatabaseName}] ;");
            connection.Execute($"ALTER DATABASE [{newDatabaseName}] SET MULTI_USER");
            return newDatabaseName;
        }
    }
}
