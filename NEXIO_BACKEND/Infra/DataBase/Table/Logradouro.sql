IF NOT EXISTS( SELECT name
                 FROM SysObjects
				WHERE name = 'Logradouro'
				  AND type = 'U' )
  BEGIN
    
	CREATE TABLE [dbo].[Logradouro]
	(	   		   
	   IdLogradouro     [Int] Identity(1,1) NOT NULL,
	   IdTipoLogradouro [Int]               NOT NULL,
	   Descricao        [VarChar](100)      NOT NULL,
	   DataAlteracao    [DateTime]          NOT NULL,
	   UsuarioAlteracao [VarChar](20)       NOT NULL,
	   
	   CONSTRAINT [PkLogradouro]
	      PRIMARY KEY([IdLogradouro])
		     WITH FILLFACTOR = 90
			   ON [PRIMARY],
	   
	   CONSTRAINT [UnLogradouro_Descricao]
		   UNIQUE ([Descricao]),

	   CONSTRAINT [FkLogradouro_TipoLogradouro]
	      FOREIGN KEY([IdTipoLogradouro])
	   REFERENCES [dbo].[TipoLogradouro]([IdTipoLogradouro])
	)

	CREATE INDEX [Idx_Logradouro_IdTipoLogradouro]
	          ON [dbo].[Logradouro]([IdTipoLogradouro])
			WITH FILLFACTOR = 90
			  ON [PRIMARY]

	CREATE INDEX [Idx_Logradouro_Descricao]
	          ON [dbo].[Logradouro]([Descricao])
			WITH FILLFACTOR = 90
			  ON [PRIMARY]

  END
GO