﻿CREATE TABLE IF NOT EXISTS WarAttacks (
	Id INTEGER PRIMARY KEY,
	WarId INTEGER NOT NULL,
	AttackNumber INTEGER NOT NULL,
	WarriorId INTEGER NOT NULL,
	IsOpeningAttack BOOLEAN NULL,
	CurrentThLevel INTEGER NOT NULL,
	AttackedThLevel INTEGER NULL,
	Stars INTEGER NULL,
	AttackDone BOOLEAN NULL,
	IsCoherentAttack BOOLEAN NULL,
	HasFollowedStrategy BOOLEAN NULL,
	Comment VARCHAR(150) NULL, 
	FOREIGN KEY(WarId) REFERENCES Wars(Id),
	FOREIGN KEY(WarriorId) REFERENCES Warriors(Id),
	UNIQUE(WarId, AttackNumber, WarriorId)
)