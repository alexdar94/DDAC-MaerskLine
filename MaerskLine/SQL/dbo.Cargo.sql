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
    FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customer] ([CustomerID]) ON DELETE CASCADE
);

