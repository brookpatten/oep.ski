
ALTER TABLE dbo.Videos ADD CONSTRAINT
	FK_Videos_Users FOREIGN KEY
	(
	CreatedByUserId
	) REFERENCES dbo.Users
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
ALTER TABLE dbo.TimeCodes ADD CONSTRAINT
	FK_TimeCodes_Videos FOREIGN KEY
	(
	VideoId
	) REFERENCES dbo.Videos
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
ALTER TABLE dbo.Responses ADD CONSTRAINT
	FK_Responses_Videos FOREIGN KEY
	(
	VideoId
	) REFERENCES dbo.Videos
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
ALTER TABLE dbo.Responses ADD CONSTRAINT
	FK_Responses_Users FOREIGN KEY
	(
	CreatedByUserId
	) REFERENCES dbo.Users
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	

ALTER TABLE dbo.ResponsesCauses ADD CONSTRAINT
	FK_ResponsesCauses_Responses FOREIGN KEY
	(
	ResponseId
	) REFERENCES dbo.Responses
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 

ALTER TABLE dbo.ResponsesObservations ADD CONSTRAINT
	FK_ResponsesObservations_Responses FOREIGN KEY
	(
	ResponseId
	) REFERENCES dbo.Responses
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	

ALTER TABLE dbo.ResponsesObservations ADD CONSTRAINT
	FK_ResponsesObservations_Observations FOREIGN KEY
	(
	ObservationId
	) REFERENCES dbo.Observations
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	

ALTER TABLE dbo.ObservationSuggestions ADD CONSTRAINT
	FK_ObservationSuggestions_Observations FOREIGN KEY
	(
	IfObservationId
	) REFERENCES dbo.Observations
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 

ALTER TABLE dbo.ObservationSuggestions ADD CONSTRAINT
	FK_ObservationSuggestions_Observations1 FOREIGN KEY
	(
	ThenObservationId
	) REFERENCES dbo.Observations
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	

ALTER TABLE dbo.ResponseFundamentals ADD CONSTRAINT
	FK_ResponseFundamentals_ResponsesCauses FOREIGN KEY
	(
	ResponseCauseId
	) REFERENCES dbo.ResponsesCauses
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	

ALTER TABLE dbo.ResponseFundamentals ADD CONSTRAINT
	FK_ResponseFundamentals_Fundamentals FOREIGN KEY
	(
	FundamentalId
	) REFERENCES dbo.Fundamentals
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
ALTER TABLE dbo.CauseSuggestions ADD CONSTRAINT
	FK_CauseSuggestions_Causes FOREIGN KEY
	(
	CauseId
	) REFERENCES dbo.Causes
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
ALTER TABLE dbo.CauseSuggestions ADD CONSTRAINT
	FK_CauseSuggestions_Observations FOREIGN KEY
	(
	ObservationId
	) REFERENCES dbo.Observations
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
ALTER TABLE dbo.FundamentalSuggestions ADD CONSTRAINT
	FK_FundamentalSuggestions_Fundamentals FOREIGN KEY
	(
	FundamentalId
	) REFERENCES dbo.Fundamentals
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
ALTER TABLE dbo.FundamentalSuggestions ADD CONSTRAINT
	FK_FundamentalSuggestions_Causes FOREIGN KEY
	(
	CauseId
	) REFERENCES dbo.Causes
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 

ALTER TABLE dbo.ResponsesObservations ADD CONSTRAINT
	FK_ResponsesObservations_ResponsesCauses FOREIGN KEY
	(
	ResponseCauseId
	) REFERENCES dbo.ResponsesCauses
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 

ALTER TABLE dbo.Feedbacks ADD CONSTRAINT
	FK_Feedbacks_Responses FOREIGN KEY
	(
	ResponseId
	) REFERENCES dbo.Responses
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 

ALTER TABLE dbo.Videos ADD CONSTRAINT
	FK_Videos_SnowSports FOREIGN KEY
	(
	SnowSportId
	) REFERENCES dbo.SnowSports
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
ALTER TABLE dbo.Observations ADD CONSTRAINT
	FK_Observations_SnowSports FOREIGN KEY
	(
	SnowSportId
	) REFERENCES dbo.SnowSports
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	

ALTER TABLE dbo.Fundamentals ADD CONSTRAINT
	FK_Fundamentals_SnowSports FOREIGN KEY
	(
	SnowSportId
	) REFERENCES dbo.SnowSports
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	

ALTER TABLE dbo.Causes ADD CONSTRAINT
	FK_Causes_SnowSports FOREIGN KEY
	(
	SnowSportId
	) REFERENCES dbo.SnowSports
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 