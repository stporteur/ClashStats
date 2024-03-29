﻿CREATE TABLE IF NOT EXISTS Wars (
	Id INTEGER PRIMARY KEY,
	ClanId INTEGER NOT NULL,
	WarSize int NOT NULL,
	WarDate DATETIME NOT NULL,
	OurStars INTEGER NULL,
	OurPercent DOUBLE NULL,
	TheirStars INTEGER NULL,
	TheirPercent DOUBLE NULL,
	FOREIGN KEY(ClanId) REFERENCES Clans(Id)
)