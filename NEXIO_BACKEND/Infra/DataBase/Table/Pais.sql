IF NOT EXISTS( SELECT name
                 FROM SysObjects
				WHERE name = 'Pais'
				  AND type = 'U' )
  BEGIN
    
	CREATE TABLE [dbo].[Pais]
	(
	   IdPais           [Int] Identity(1,1) NOT NULL,
       Descricao        [VarChar](100)      NOT NULL,
       Ddi              [VarChar](2)            NULL,
	   CodigoBacen      [VarChar](5)            NULL,
       DataAlteracao    [DateTime]          NOT NULL,
       UsuarioAlteracao [VarChar](20)       NOT NULL,
       
	   CONSTRAINT [PkPais]
	      PRIMARY KEY([IdPais])
		     WITH FILLFACTOR = 90
			   ON [PRIMARY],

	   CONSTRAINT [UnPais_Descricao]
	       UNIQUE ([Descricao])
	)


	CREATE INDEX [Idx_Pais_Descricao]
	          ON [dbo].[Pais]([Descricao])
			WITH FILLFACTOR = 90
			  ON [PRIMARY]
    
	CREATE UNIQUE INDEX [Idx_Pais_Ddi]
	                 ON [dbo].[Pais]([Ddi])
		          WHERE [DDI] IS NOT NULL
			       WITH FILLFACTOR = 90
			         ON [PRIMARY]

	CREATE UNIQUE INDEX [Idx_Pais_CodigoBacen]
	                 ON [dbo].[Pais]([CodigoBacen])
		          WHERE [CodigoBacen] IS NOT NULL
			       WITH FILLFACTOR = 90
			         ON [PRIMARY]

  END
GO