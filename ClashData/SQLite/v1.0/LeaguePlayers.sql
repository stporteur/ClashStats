﻿CREATE TABLE IF NOT EXISTS LeaguePlayers (
	Id INTEGER PRIMARY KEY,
	LeagueId INTEGER NOT NULL,
	WarriorId INTEGER NOT NULL,
	FOREIGN KEY(LeagueId) REFERENCES Leagues(Id),
	FOREIGN KEY(WarriorId) REFERENCES Warriors(Id),
	UNIQUE(LeagueId, WarriorId)
)