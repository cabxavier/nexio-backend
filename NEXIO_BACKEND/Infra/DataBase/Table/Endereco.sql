IF NOT EXISTS( SELECT name
                 FROM SysObjects
				WHERE name = 'Endereco'
				  AND type = 'U' )
  BEGIN
    
	CREATE TABLE [dbo].[Endereco]
	(	   		   
	   IdEndereco       [Int] Identity(1,1) NOT NULL,
	   IdTipoEndereco   [Int]               NOT NULL,
	   IdCep            [Int]               NOT NULL,
	   IdPessoa         [Int]               NOT NULL,
	   Numero           [VarChar](20)       NOT NULL,
	   Telefone         [VarChar](15)           NULL,
	   Celular          [VarChar](15)           NULL,
	   Complemento      [VarChar](100)          NULL,
	   Observacao       [VarChar](100)          NULL,
	   Ativo            [Bit]               NOT NULL,
	   DataAlteracao    [DateTime]          NOT NULL,
	   UsuarioAlteracao [VarChar](20)       NOT NULL,
	   
	   CONSTRAINT [PkEndereco]
	      PRIMARY KEY([IdEndereco])
		     WITH FILLFACTOR = 90
			   ON [PRIMARY],

	   CONSTRAINT [UnEndereco]
		   UNIQUE ([IdTipoEndereco],[IdCep],[IdPessoa]),

	   CONSTRAINT [FkEndereco_TipoEndereco]
	      FOREIGN KEY([IdTipoEndereco])
	   REFERENCES [dbo].[TipoEndereco]([IdTipoEndereco]),

	   CONSTRAINT [FkEndereco_Cep]
	      FOREIGN KEY([IdCep])
	   REFERENCES [dbo].[Cep]([IdCep]),

	   CONSTRAINT [FkEndereco_Pessoa]
	      FOREIGN KEY([IdPessoa])
	   REFERENCES [dbo].[Pessoa]([IdPessoa])
	)

	CREATE INDEX [Idx_Endereco_TipoEndereco]
	          ON [dbo].[Endereco](IdTipoEndereco)
			WITH FILLFACTOR = 90
			  ON [PRIMARY]

	CREATE INDEX [Idx_Endereco_Cep]
	          ON [dbo].[Endereco](IdCep)
			WITH FILLFACTOR = 90
			  ON [PRIMARY]

	CREATE INDEX [Idx_Endereco_Pessoa]
	          ON [dbo].[Endereco](IdPessoa)
			WITH FILLFACTOR = 90
			  ON [PRIMARY]

	CREATE INDEX [Idx_Endereco_090]
              ON [dbo].[Endereco]([IdTipoEndereco],[IdCep],[IdPessoa])
            WITH FILLFACTOR = 90
              ON [PRIMARY]

  END
GO