CREATE TABLE [dbo].[Book] (
    [BookID]      INT         NOT NULL IDENTITY(1, 1),
    [Agent]       NCHAR (255) NOT NULL,
    [CargoID]     INT         NOT NULL,
    [ShipID]      INT         NOT NULL,
    [WarehouseID] INT         NOT NULL,
    PRIMARY KEY CLUSTERED ([BookID] ASC),
    FOREIGN KEY ([CargoID]) REFERENCES [dbo].[Cargo] ([CargoID]),
    FOREIGN KEY ([ShipID]) REFERENCES [dbo].[Ship] ([ShipID]),
    FOREIGN KEY ([WarehouseID]) REFERENCES [dbo].[Warehouse] ([WarehouseID])
);

CREATE TABLE [dbo].[Cargo] (
    [CargoID]     INT         NOT NULL IDENTITY(1, 1),
    [CargoName]   FLOAT (53)  NULL,
    [CargoLength] FLOAT (53)  NULL,
    [CargoWidth]  FLOAT (53)  NULL,
    [CargoHeight] FLOAT (53)  NULL,
    [CargoWeight] FLOAT (53)  NULL,
    [CargoStatus] NCHAR (255) NULL,
    [CustomerID]  INT         NOT NULL,
    PRIMARY KEY CLUSTERED ([CargoID] ASC),
    FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customer] ([CustomerID])
);

CREATE TABLE [dbo].[Customer] (
    [CustomerID] INT         NOT NULL IDENTITY(1, 1),
    [Name]       NCHAR (255) NULL,
    [Contact]    NCHAR (255) NULL,
    [Address]    NCHAR (255) NULL,
    [Email]      NCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([CustomerID] ASC)
);

CREATE TABLE [dbo].[Ship] (
    [ShipID]      INT         NOT NULL IDENTITY(1, 1),
    [ShipDate]    DATETIME    NULL,
    [ShipName]    NCHAR (255) NULL,
    [ShipAddress] NCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([ShipID] ASC)
);

CREATE TABLE [dbo].[Warehouse] (
    [WarehouseID]      INT         NOT NULL IDENTITY(1, 1),
    [WarehouseName]    NCHAR (255) NULL,
    [WarehouseAddress] NCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([WarehouseID] ASC)
);