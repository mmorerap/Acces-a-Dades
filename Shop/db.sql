CREATE TABLE b1botiga.dbo.Producte (
	ID numeric(38,0) NOT NULL,
	Nom varchar(15) NULL,
	Preu numeric(38,0) NULL,
	Descompte numeric(38,0) NULL,
	CONSTRAINT Producte_PK PRIMARY KEY (ID)
);