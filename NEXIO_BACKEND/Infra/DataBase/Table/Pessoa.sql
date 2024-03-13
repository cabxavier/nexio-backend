IF NOT EXISTS( SELECT name
                 FROM SysObjects
				WHERE name = 'Pessoa'
				  AND type = 'U' )
  BEGIN
    
	CREATE TABLE [dbo].[Pessoa]
	(
	   IdPessoa         [Int] Identity(1,1) NOT NULL,
	   IdUsuario        [Int]                   NULL,
	   Codigo           [VarChar](10)       NOT NULL,
	   CodigoInterno    [VarChar](10)           NULL,
	   RazaoSocial      [VarChar](100)      NOT NULL,
	   NomeFantasia     [VarChar](100)      NOT NULL,
	   Cnpj             [VarChar](14)           NULL,
	   Cpf              [VarChar](11)           NULL,
	   EmailPrincipal   [VarChar](100)          NULL,
	   EmailSecundario  [VarChar](100)          NULL,
	   Cliente          [Bit]               NOT NULL,
	   Funcionario      [Bit]               NOT NULL,
	   Vendedor         [Bit]               NOT NULL,
	   Transportadora   [Bit]               NOT NULL,
	   Fornecedor       [Bit]               NOT NULL,
	   Representante    [Bit]               NOT NULL,
	   ConsumidorFinal  [Bit]               NOT NULL,
	   ContribuinteIcms [Bit]               NOT NULL,
	   IsentoIpi        [Bit]               NOT NULL,
	   Ativo            [Bit]               NOT NULL,
	   DataAlteracao    [DateTime]          NOT NULL,
       UsuarioAlteracao [VarChar](20)       NOT NULL,

	   CONSTRAINT [PkPessoa]
	      PRIMARY KEY([IdPessoa])
		     WITH FILLFACTOR = 90
			   ON [PRIMARY],

		CONSTRAINT [UnPessoa_Codigo]
		    UNIQUE ([Codigo]),

		CONSTRAINT [CkPessoa_Cnpj]
		     CHECK ( ( [Cnpj] IS NULL )
			         OR
			         ( ( [Cnpj] IS NOT NULL                                                                       ) AND 
					   ( [Cnpj] LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]' )
					 )
				   ),

		CONSTRAINT [CkPessoa_Cpf]
		     CHECK ( ( [Cpf] IS NULL )
			         OR
			         ( ( [Cpf] IS NOT NULL                                                    ) AND 
					   ( [Cpf] LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]' )
					 )
				   ),

		CONSTRAINT [CkPessoa_EmailPrincipal]
		     CHECK ( ( [EmailPrincipal] IS NULL )
			         OR
			         ( ( [EmailPrincipal] IS NOT NULL                   ) AND 
					   ( [EmailPrincipal]     LIKE '%_@_%_.__%'         ) AND 
					   ( [EmailPrincipal] NOT LIKE '%[^a-z,0-9,@,.-_]%' ) AND 
					   ( [EmailPrincipal] NOT LIKE '%_@@_%_.__%'        ) 
					 )
				   ),

		CONSTRAINT [CkPessoa_EmailSecundario]
		     CHECK ( ( [EmailSecundario] IS NULL )
			         OR
			         ( ( [EmailSecundario] IS NOT NULL                   ) AND 
					   ( [EmailSecundario]     LIKE '%_@_%_.__%'         ) AND 
					   ( [EmailSecundario] NOT LIKE '%[^a-z,0-9,@,.-_]%' ) AND 
					   ( [EmailSecundario] NOT LIKE '%_@@_%_.__%'        ) 
					 )
				   ),

	    CONSTRAINT [CkPessoaTipo]
		     CHECK ( ( [Cliente]        = 1 ) OR
			         ( [Funcionario]    = 1 ) OR
				     ( [Vendedor]       = 1 ) OR
				     ( [Transportadora] = 1 ) OR
					 ( [Fornecedor]     = 1 ) OR
				     ( [Representante]  = 1 )
				   ),

	   CONSTRAINT [FkPessoa_Usuario]
	      FOREIGN KEY([IdUsuario])
	   REFERENCES [dbo].[Usuario]([IdUsuario])
	)

	CREATE INDEX [Idx_Pessoa_IdUsuario]
              ON [dbo].[Pessoa]([IdUsuario])
		    WITH FILLFACTOR = 90
		      ON [PRIMARY]

	CREATE INDEX [Idx_Pessoa_Codigo]
              ON [dbo].[Pessoa]([Codigo])
		    WITH FILLFACTOR = 90
		      ON [PRIMARY]

	CREATE INDEX [Idx_Pessoa_CodigoInterno]
              ON [dbo].[Pessoa]([CodigoInterno])
		    WITH FILLFACTOR = 90
		      ON [PRIMARY]

	CREATE INDEX [Idx_Pessoa_RazaoSocial]
              ON [dbo].[Pessoa]([RazaoSocial])
		    WITH FILLFACTOR = 90
		      ON [PRIMARY]

	CREATE INDEX [Idx_Pessoa_NomeFantasia]
              ON [dbo].[Pessoa]([NomeFantasia])
		    WITH FILLFACTOR = 90
		      ON [PRIMARY]

	CREATE INDEX [Idx_Pessoa_Cnpj]
              ON [dbo].[Pessoa]([Cnpj])
		    WITH FILLFACTOR = 90
		      ON [PRIMARY]

   CREATE UNIQUE INDEX [Idx_Pessoa_Cnpj_090]
              ON [dbo].[Pessoa]([Cnpj])
           WHERE [Cnpj] IS NOT NULL
            WITH FILLFACTOR = 90
              ON [PRIMARY]

	CREATE INDEX [Idx_Pessoa_Cpf]
              ON [dbo].[Pessoa]([Cpf])
		    WITH FILLFACTOR = 90
		      ON [PRIMARY]
			    
   CREATE UNIQUE INDEX [Idx_Pessoa_Cpf_090]
              ON [dbo].[Pessoa]([Cpf])
           WHERE [Cpf] IS NOT NULL
            WITH FILLFACTOR = 90
              ON [PRIMARY]

  END
GO