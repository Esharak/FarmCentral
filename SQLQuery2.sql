CREATE TABLE FarmerProduct(
ID INT NOT NULL PRIMARY KEY IDENTITY,
Name VARCHAR (100) NOT NULL,
Description VARCHAR (200) NOT NULL,
Price VARCHAR (50) NOT NULL,
Quantity VARCHAR (50) NOT NULL,
FarmerName VARCHAR(100) NOT NULL,
FarmerPhone VARCHAR (20) NOT NULL,
FarmerCell VARCHAR (20) NOT NULL,
FarmerEmail VARCHAR (150) NOT NULL,
Created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO FarmerProduct (Name, Description, Price, Quantity, FarmerName, FarmerPhone, FarmerCell, FarmerEmail)
VALUES
('Auger', 'Creates holes to install posts and retaining walls, as well as other uses', 'R5000.00', '500 units', 
'Celion Dion', '1928394728', '37298363728', 'cdion@gmail.com'),

('Bale Handler', 'To move wrapped and rolled bales', 'R6000.00', '700 units', 
'Sam Smith', '3847583928', '38472839384', 'ssmith@gmail.com'),

('Bale Spear', 'To move unwrapped hay bales', 'R2000.00', '900 units', 
'Mariah Careys', '992837823764', '3874693846', 'mcs@gmail.com');
