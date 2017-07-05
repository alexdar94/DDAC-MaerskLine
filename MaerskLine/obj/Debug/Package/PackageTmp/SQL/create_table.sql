CREATE TABLE [dbo].[MLUserRole] (
    [Email] NCHAR (255) NOT NULL,
    [Role]  NCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([Email] ASC)
);

CREATE TABLE [dbo].[Ship] (
    [ShipID]      INT         IDENTITY (1, 1) NOT NULL,
    [ShipDate]    DATETIME    NULL,
    [ShipName]    NCHAR (255) NULL,
    [ShipAddress] NCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([ShipID] ASC)
);

CREATE TABLE [dbo].[Warehouse] (
    [WarehouseID]      INT         IDENTITY (1, 1) NOT NULL,
    [WarehouseName]    NCHAR (255) NULL,
    [WarehouseAddress] NCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([WarehouseID] ASC)
);

CREATE TABLE [dbo].[Customer] (
    [CustomerID] INT         IDENTITY (1, 1) NOT NULL,
    [Name]       NCHAR (255) NULL,
    [Contact]    NCHAR (255) NULL,
    [Address]    NCHAR (255) NULL,
    [Email]      NCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([CustomerID] ASC)
);

CREATE TABLE [dbo].[Cargo] (
    [CargoID]     INT         IDENTITY (1, 1) NOT NULL,
    [CargoName]   NCHAR (255) NULL,
    [CargoLength] FLOAT (53)  NULL,
    [CargoWidth]  FLOAT (53)  NULL,
    [CargoHeight] FLOAT (53)  NULL,
    [CargoWeight] FLOAT (53)  NULL,
    [CargoStatus] NCHAR (255) NULL,
    [CustomerID]  INT         NOT NULL,
    PRIMARY KEY CLUSTERED ([CargoID] ASC),
    FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customer] ([CustomerID])
);

CREATE TABLE [dbo].[Book] (
    [BookID]      INT IDENTITY (1, 1) NOT NULL,
    [CustomerID]  INT NOT NULL,
    [CargoID]     INT NOT NULL,
    [ShipID]      INT NOT NULL,
    [WarehouseID] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([BookID] ASC),
    FOREIGN KEY ([ShipID]) REFERENCES [dbo].[Ship] ([ShipID]) ON DELETE CASCADE,
    FOREIGN KEY ([WarehouseID]) REFERENCES [dbo].[Warehouse] ([WarehouseID]) ON DELETE CASCADE,
    FOREIGN KEY ([CargoID]) REFERENCES [dbo].[Cargo] ([CargoID]) ON DELETE CASCADE,
    FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customer] ([CustomerID]) ON DELETE CASCADE
);

INSERT INTO MLUserRole VALUES ('mladmin@ddactp034766outlook.onmicrosoft.com','Admin');
INSERT INTO MLUserRole VALUES ('mlstaff@ddactp034766outlook.onmicrosoft.com','Admin');
INSERT INTO MLUserRole VALUES ('bjones@ddactp034766outlook.onmicrosoft.com','Staff');

INSERT INTO Customer VALUES ('Kanye West','+1 (936) 571-3179','4 Goldfield Rd. Honolulu, HI 96815','kanye@gmail.com');
INSERT INTO Customer VALUES ('Alisha Travis','+1 (959) 435-2704','979 Harrison Avenue, Sena, Massachusetts, 9023','bettyemorrison@steeltab.com');
INSERT INTO Customer VALUES ('Humphrey Mcconnell','+1 (985) 447-3266','355 Grace Court, Thermal, Palau, 6054','humphreymcconnell@steeltab.com');
INSERT INTO Customer VALUES ('Dunn Roberts','+1 (914) 481-2385','421 Hampton Place, Tivoli, Illinois, 9370','dunnroberts@steeltab.com ');
INSERT INTO Customer VALUES ('Tracy Cannon','+1 (950) 511-3328','347 Dahill Road, Kimmell, Maine, 8000','tracycannon@steeltab.com');
INSERT INTO Customer VALUES ('Mathews Combs','+1 (948) 513-2504','314 Fenimore Street, Lowgap, Illinois, 212','mathewscombs@steeltab.com');
INSERT INTO Customer VALUES ('Lorene Day','+1 (819) 432-3258','421 College Place, Draper, Washington, 8696','loreneday@steeltab.com ');
INSERT INTO Customer VALUES ('Hilary Wooten','+1 (859) 535-3508','927 Turner Place, Sunbury, Northern Mariana Islands, 5824','hilarywooten@steeltab.com');
INSERT INTO Customer VALUES ('Elba Christian','+1 (913) 402-2405','299 Ferris Street, Garberville, Louisiana, 4799','elbachristian@steeltab.com');
INSERT INTO Customer VALUES ('Joanna Wilson','+1 (828) 478-3814','711 Montieth Street, Richford, Northern Mariana Islands, 6917','joannawilson@steeltab.com');
INSERT INTO Customer VALUES ('Mcneil Austin','+1 (820) 546-3326','719 Bushwick Court, Dawn, Illinois, 4209','mcneilaustin@steeltab.com');

INSERT INTO Customer VALUES ('Mcneil Austin','+1 (820) 546-3326','719 Bushwick Court, Dawn, Illinois, 4209','mcneilaustin@steeltab.com');
SELECT* FROM Customer