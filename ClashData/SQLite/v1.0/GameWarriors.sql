﻿CREATE TABLE IF NOT EXISTS GameWarriors (
	Id INTEGER PRIMARY KEY,
	GameId INTEGER NOT NULL,
	WarriorId INTEGER NOT NULL,
	Score INTEGER NULL,
	FOREIGN KEY(GameId) REFERENCES Games(Id),
	FOREIGN KEY(WarriorId) REFERENCES Warriors(Id)
	UNIQUE(GameId, WarriorId)
)