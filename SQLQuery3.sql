﻿CREATE TABLE LoginEmp (
ID INT NOT NULL PRIMARY KEY IDENTITY,
Name VARCHAR (100) NOT NULL,
Password VARCHAR (100) NOT NULL );

INSERT INTO LoginEmp (Name, Password)
VALUES ('Eshara', 'Honey');