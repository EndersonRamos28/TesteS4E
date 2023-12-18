use S4E;

CREATE TABLE [Associados]( 
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY 
	,[Nome] [Varchar](200) NOT NULL 
	,[Cpf] [varchar] (11) NOT NULL UNIQUE
	,[DataNascimento] [DateTime] NULL);


CREATE TABLE [Empresas]( 
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY 
	,[Nome] [Varchar](200) NOT NULL 
	,[Cnpj] [varchar] (14) NOT NULL UNIQUE);

CREATE TABLE AssociadosEmpresas (
    AssociadoId INT,
    EmpresaId INT,
    PRIMARY KEY (AssociadoId, EmpresaId),
    FOREIGN KEY (AssociadoId) REFERENCES Associados(Id),
    FOREIGN KEY (EmpresaId) REFERENCES Empresas(Id)
);