﻿CREATE TABLE IF NOT EXISTS ScoreOptions (
	Id INTEGER PRIMARY KEY,
	ScoreType NVARCHAR(10) NOT NULL,
	ScoreName NVARCHAR(50) NOT NULL,
	ScoreValue NVARCHAR(5) NOT NULL
)