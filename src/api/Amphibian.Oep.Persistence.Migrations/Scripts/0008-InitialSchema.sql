CREATE TABLE [dbo].[Videos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VideoProvider] [varchar](512) NOT NULL,
	[VideoProviderKey] [varchar](512) NOT NULL,
	[Title] [varchar](512) NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[SnowSport] [varchar](20) NOT NULL
 CONSTRAINT [PK_Videos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[TimeCodes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VideoId] [int] NOT NULL,
	[TimeCodeType] [varchar](128) NOT NULL,
	[Name] [varchar](128) NULL,
	[StartMs] [int] NOT NULL,
	[EndMs] [int] NOT NULL,
	[Index] [int] NOT NULL
 CONSTRAINT [PK_TimeCodes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[Fundamentals](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](128) NOT NULL,
	[Text] [varchar](512) NOT NULL,
	[Index] [int] NOT NULL,
	[SnowSport] [varchar](20) NOT NULL
 CONSTRAINT [PK_Fundamentals] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[FundamentalSuggestions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CauseId] [int] NOT NULL,
	[FundamentalId] [int] NOT NULL,
 CONSTRAINT [PK_FundamentalSuggestions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[Causes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](128) NOT NULL,
	[Text] [varchar](512) NOT NULL,
	[Index] [int] NOT NULL,
	[SnowSport] [varchar](20) NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[AcceptedAt] [datetime] NULL
 CONSTRAINT [PK_Causes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[CauseSuggestions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ObservationId] [int] NOT NULL,
	[CauseId] [int] NOT NULL
 CONSTRAINT [PK_CauseSuggestions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[Observations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](128) NOT NULL,
	[Text] [varchar](512) NOT NULL,
	[Index] [int] NOT NULL,
	[Category] [varchar](20) NOT NULL,
	[SkiPerformance] [varchar](20) NULL,
	[TurnPhase] [varchar](20) NULL,
	[SnowSport] [varchar](20) NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[AcceptedAt] [datetime] NULL
 CONSTRAINT [PK_Observations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[ObservationSuggestions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IfObservationId] [int] NOT NULL,
	[ThenObservationId] [int] NOT NULL
 CONSTRAINT [PK_ObservationSuggestions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[Responses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
	[VideoId] [int] NOT NULL,
	[Comments] [varchar](1024) NOT NULL
 CONSTRAINT [PK_Responses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[ResponsesCauses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ResponseId] [int] NOT NULL,
	[CauseId] [int] NOT NULL
 CONSTRAINT [PK_ResponsesCause] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[ResponsesObservations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ResponseId] [int] NOT NULL,
	[ObservationId] [int] NOT NULL,
	[ResponseCauseId] [int] NULL
 CONSTRAINT [PK_ResponsesObservations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[ResponseFundamentals](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ResponseCauseId] [int] NOT NULL,
	[FundamentalId] [int] NOT NULL
 CONSTRAINT [PK_ResponseFundamentals] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[Feedbacks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ResponseId] [int] NOT NULL,
	[ThumbsUp] [bit] NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL
 CONSTRAINT [PK_ResponseFeedbacks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]