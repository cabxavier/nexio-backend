IF NOT EXISTS( SELECT name
                 FROM SysObjects
				WHERE name = 'Empresa'
				  AND type = 'U' )
  BEGIN

    CREATE TABLE [dbo].[Empresa] 
    (
       IdEmpresa          [Int] Identity(1,1) NOT NULL,
	   IdPessoa           [Int]               NOT NULL,
       Nome               [VarChar](100)      NOT NULL,
       Cnpj               [VarChar](14)       NOT NULL,      
       InscricaoMunicipal [Varchar](20)           NULL,      
       InscricaoEstadual  [Varchar](20)           NULL,
	   Sigla              [Varchar](3)        NOT NULL,
       DataAlteracao      [DateTime]          NOT NULL,
       UsuarioAlteracao   [VarChar](20)       NOT NULL,

       CONSTRAINT [PkEmpresa] 
	      PRIMARY KEY([IdEmpresa])
             WITH FILLFACTOR = 90
			   ON [PRIMARY],

	   CONSTRAINT [UnEmpresa] 
	       UNIQUE ([IdPessoa],[Cnpj]),

       CONSTRAINT [UnEmpresa_Cnpj] 
	       UNIQUE ([Cnpj]),

	   CONSTRAINT [UnEmpresa_Sigla] 
	       UNIQUE ([Sigla]),

       CONSTRAINT [FkEmpresa_Pessoa]
	      FOREIGN KEY ([IdPessoa])
       REFERENCES [dbo].[Pessoa]([IdPessoa])    
	)
    
	CREATE INDEX [Idx_Empresa_IdPessoa] 
              ON [dbo].[Empresa]([IdPessoa])
            WITH FILLFACTOR = 90 
			  ON [PRIMARY]

	CREATE INDEX [Idx_Empresa_Nome] 
              ON [dbo].[Empresa]([Nome])
            WITH FILLFACTOR = 90 
			  ON [PRIMARY]
			    
	CREATE INDEX [Idx_Empresa_Cnpj] 
              ON [dbo].[Empresa]([Cnpj])
            WITH FILLFACTOR = 90 
			  ON [PRIMARY]

  END
GO