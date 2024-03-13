IF NOT EXISTS( SELECT name
                 FROM SysObjects
				WHERE name = 'Cep'
				  AND type = 'U' )
  BEGIN
    
	CREATE TABLE [dbo].[Cep]
	(	   		   
	   IdCep            [Int] Identity(1,1) NOT NULL,
	   IdCidade         [Int]               NOT NULL,
	   IdBairro         [Int]               NOT NULL,
	   IdLogradouro     [Int]               NOT NULL,
	   CepNumero        [VarChar](8)        NOT NULL,
	   Complemento      [VarChar](100)          NULL,
	   DataAlteracao    [DateTime]          NOT NULL,
	   UsuarioAlteracao [VarChar](20)       NOT NULL,
	   
	   CONSTRAINT [PkCep]
	      PRIMARY KEY([IdCep])
		     WITH FILLFACTOR = 90
			   ON [PRIMARY],

	   CONSTRAINT [UnCep]
		   UNIQUE ([IdCidade],[IdBairro],[IdLogradouro],[CepNumero]),

	   CONSTRAINT [CkCep_CepNumero] 
	        CHECK (CepNumero LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),

	   CONSTRAINT [FkCep_Cidade]
	      FOREIGN KEY([IdCidade])
	   REFERENCES [dbo].[Cidade]([IdCidade]),

	   CONSTRAINT [FkCep_Bairro]
	      FOREIGN KEY([IdBairro])
	   REFERENCES [dbo].[Bairro]([IdBairro]),

	   CONSTRAINT [FkCep_Logradouro]
	      FOREIGN KEY([IdLogradouro])
	   REFERENCES [dbo].[Logradouro]([IdLogradouro])
	)

	CREATE INDEX [Idx_Cep_IdCidade]
	          ON [dbo].[Cep]([IdCidade])
			WITH FILLFACTOR = 90
			  ON [PRIMARY]

	CREATE INDEX [Idx_Cep_Bairro]
	          ON [dbo].[Cep]([IdBairro])
			WITH FILLFACTOR = 90
			  ON [PRIMARY]

	CREATE INDEX [Idx_Cep_Logradouro]
	          ON [dbo].[Cep]([IdLogradouro])
			WITH FILLFACTOR = 90
			  ON [PRIMARY]

	CREATE INDEX [Idx_Cep_CepNumero]
	          ON [dbo].[Cep]([CepNumero])
			WITH FILLFACTOR = 90
			  ON [PRIMARY]

	CREATE INDEX [Idx_Cep_CepNumero_090]
              ON [dbo].[Cep]([IdCidade],[IdBairro],[IdLogradouro],[CepNumero])
            WITH FILLFACTOR = 90
              ON [PRIMARY]

  END
GO