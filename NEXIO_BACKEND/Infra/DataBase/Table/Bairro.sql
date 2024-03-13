IF NOT EXISTS( SELECT name
                 FROM SysObjects
				WHERE name = 'Bairro'
				  AND type = 'U' )
  BEGIN
    
	CREATE TABLE [dbo].[Bairro]
	(	   		   
	   IdBairro         [Int] Identity(1,1) NOT NULL,
	   Descricao        [VarChar](100)      NOT NULL,
	   DataAlteracao    [DateTime]          NOT NULL,
	   UsuarioAlteracao [VarChar](20)       NOT NULL,
	   
	   CONSTRAINT [PkBairro]
	      PRIMARY KEY([IdBairro])
		     WITH FILLFACTOR = 90
			   ON [PRIMARY],
	   
	   CONSTRAINT [UnBairro_Descricao]
		   UNIQUE ([Descricao])
	)

	CREATE INDEX [Idx_Bairro_Descricao]
	          ON [dbo].[Bairro]([Descricao])
			WITH FILLFACTOR = 90
			  ON [PRIMARY]

  END
GO