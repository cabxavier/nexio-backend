IF NOT EXISTS( SELECT name
                 FROM SysObjects
				WHERE name = 'TipoLogradouro'
				  AND type = 'U' )
  BEGIN
    
	CREATE TABLE [dbo].[TipoLogradouro]
	(	   		   
	   IdTipoLogradouro [Int] Identity(1,1) NOT NULL,
	   Descricao        [VarChar](100)      NOT NULL,
	   Sigla            [VarChar](20)           NULL,
	   DataAlteracao    [DateTime]          NOT NULL,
	   UsuarioAlteracao [VarChar](20)       NOT NULL,
	   
	   CONSTRAINT [PkTipoLogradouro]
	      PRIMARY KEY([IdTipoLogradouro])
		     WITH FILLFACTOR = 90
			   ON [PRIMARY],
	   
	   CONSTRAINT [UnTipoLogradouro_Descricao]
		   UNIQUE ([Descricao]), 

	   CONSTRAINT [UnTipoLogradouro_Sigla]
		   UNIQUE ([Sigla]),

	)

	CREATE INDEX [Idx_TipoLogradouro_Descricao]
	          ON [dbo].[TipoLogradouro]([Descricao])
			WITH FILLFACTOR = 90
			  ON [PRIMARY]

	CREATE INDEX [Idx_TipoLogradouro_Sigla]
	          ON [dbo].[TipoLogradouro]([Sigla])
			WITH FILLFACTOR = 90
			  ON [PRIMARY]

  END
GO