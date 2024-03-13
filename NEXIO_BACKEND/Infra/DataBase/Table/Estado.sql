IF NOT EXISTS( SELECT name
                 FROM SysObjects
				WHERE name = 'Estado'
				  AND type = 'U' )
  BEGIN
    
	CREATE TABLE [dbo].[Estado]
	(	   		   
	   IdEstado         [Int] Identity(1,1) NOT NULL,
	   IdPais           [Int]               NOT NULL,
	   Descricao        [VarChar](100)      NOT NULL,
	   Sigla            [VarChar](2)        NOT NULL,
	   CodigoIbge       [VarChar](20)           NULL,
	   DataAlteracao    [DateTime]          NOT NULL,
	   UsuarioAlteracao [VarChar](20)       NOT NULL,
	   
	   CONSTRAINT [PkEstado]
	      PRIMARY KEY([IdEstado])
		     WITH FILLFACTOR = 90
			   ON [PRIMARY],
	   
	   CONSTRAINT [UnEstado_Descricao]
		   UNIQUE ([Descricao]),
	   
	   CONSTRAINT [UnEstado_Sigla]
		   UNIQUE ([Sigla]),	   

	   CONSTRAINT [FkEstado_Pais]
	      FOREIGN KEY([IdPais])
	   REFERENCES [dbo].[Pais]([IdPais])

	)

	CREATE INDEX [Idx_Estado_IdPais]
	          ON [dbo].[Estado]([IdPais])
			WITH FILLFACTOR = 90
			  ON [PRIMARY]

	CREATE INDEX [Idx_Estado_Descricao]
	          ON [dbo].[Estado]([Descricao])
			WITH FILLFACTOR = 90
			  ON [PRIMARY]

	CREATE INDEX [Idx_Estado_Sigla]
	          ON [dbo].[Estado]([Sigla])
			WITH FILLFACTOR = 90
			  ON [PRIMARY]

   CREATE UNIQUE INDEX [Idx_Estado_CodigoIbge]
                    ON [dbo].[Estado]([CodigoIbge])
	             WHERE [CodigoIbge] IS NOT NULL
		          WITH FILLFACTOR = 90
		            ON [PRIMARY]

  END
GO