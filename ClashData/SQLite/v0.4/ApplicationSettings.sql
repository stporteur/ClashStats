﻿CREATE TABLE IF NOT EXISTS ApplicationSettings (
	Id INTEGER PRIMARY KEY,
	SettingName NVARCHAR(50) NOT NULL,
	SettingValue NVARCHAR(150) NOT NULL,
	UNIQUE(SettingName)
)