﻿CREATE TABLE IF NOT EXISTS Leagues (
	Id INTEGER PRIMARY KEY,
	ClanId INTEGER NOT NULL,
	LeagueDate DATETIME NOT NULL,
	Position INTEGER NULL,
	FOREIGN KEY(ClanId) REFERENCES Clans(Id)
)