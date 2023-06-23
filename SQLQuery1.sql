CREATE TABLE AddFarmer(
ID INT NOT NULL PRIMARY KEY IDENTITY,
Name VARCHAR (100) NOT NULL,
Surname VARCHAR (100) NOT NULL,
TradingName VARCHAR (100) NOT NULL,
Address VARCHAR (150) NULL,
Phone VARCHAR (20) NULL,
Cellphone VARCHAR (20) NULL,
Email VARCHAR (150) NOT NULL UNIQUE,
Created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO AddFarmer (Name, Surname, TradingName, Address, Phone, Cellphone, Email)
VALUES
('Sam','Smith','SMITHS','21 Flower Ave','3847583928','38472839384','ssmith@gmail.com'),
('Celine','Dion','DIONS','12 Rose Ave','1928394728','37298363728','cdion@gmail.com'),
('Mariah','Careys','MCS','14 Honey Ave','992837823764','3874693846','mcs@gmail.com');