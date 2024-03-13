IF NOT EXISTS( SELECT name
                 FROM SysObjects
				WHERE name = 'Cidade'
				  AND type = 'U' )
  BEGIN
    
	CREATE TABLE [dbo].[Cidade]
	(	   		   
	   IdCidade         [Int] Identity(1,1) NOT NULL,
	   IdEstado         [Int]               NOT NULL,
	   Descricao        [VarChar](100)      NOT NULL,
	   CodigoIbge       [VarChar](20)           NULL,
	   DataAlteracao    [DateTime]          NOT NULL,
	   UsuarioAlteracao [VarChar](20)       NOT NULL,
	   
	   CONSTRAINT [PkCidade]
	      PRIMARY KEY([IdCidade])
		     WITH FILLFACTOR = 90
			   ON [PRIMARY],
	   
	   CONSTRAINT [UnCidade_Descricao]
		   UNIQUE ([Descricao]), 

	   CONSTRAINT [FkCidade_Estado]
	      FOREIGN KEY([IdEstado])
	   REFERENCES [dbo].[Estado]([IdEstado])

	)

	CREATE INDEX [Idx_Cidade_IdEstado]
	          ON [dbo].[Cidade](IdEstado)
			WITH FILLFACTOR = 90
			  ON [PRIMARY]

	CREATE INDEX [Idx_Cidade_Descricao]
	          ON [dbo].[Cidade](Descricao)
			WITH FILLFACTOR = 90
			  ON [PRIMARY]
			    
   CREATE UNIQUE INDEX [Idx_Cidade_CodigoIbge]
                    ON [dbo].[Cidade]([CodigoIbge])
	             WHERE [CodigoIbge] IS NOT NULL
		          WITH FILLFACTOR = 90
		            ON [PRIMARY]

  END
GO