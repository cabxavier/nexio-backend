IF NOT EXISTS( SELECT name
                 FROM SysObjects
				WHERE name = 'Usuario'
				  AND type = 'U' )
  BEGIN

    CREATE TABLE [dbo].[Usuario]
    (   
       IdUsuario                [Int] Identity(1,1) NOT NULL,
       Cpf                      [VarChar](11)       NOT NULL,
       Nome                     [VarChar](70)       NOT NULL,
       UsuarioLogin             [VarChar](20)       NOT NULL,
       Senha                    [VarBinary](100)    NOT NULL,
       AlterarSenhaProximoLogin [Bit]               NOT NULL,
       DataLimiteAcesso         [DateTime]          NOT NULL,
       Ativo                    [Bit]               NOT NULL,
       DataAlteracao            [DateTime]          NOT NULL,
       UsuarioAlteracao         [VarChar](20)       NOT NULL,

       CONSTRAINT [PkUsuario] 
	      PRIMARY KEY ([IdUsuario])
             WITH FILLFACTOR = 90
			   ON [PRIMARY],

       CONSTRAINT [UnUsuario_UsuarioLogin]
	       UNIQUE CLUSTERED([UsuarioLogin])
             WITH FILLFACTOR = 90 
			   ON [PRIMARY],      

       CONSTRAINT [UnUsuario_Cpf]
	       UNIQUE ([Cpf])
             WITH FILLFACTOR = 90
			   ON [PRIMARY]
    )

	CREATE INDEX [Idx_Usuario_Cpf]
	          ON [dbo].[Usuario]([Cpf])
		    WITH FILLFACTOR = 90
			  ON [PRIMARY]

	CREATE INDEX [Idx_Usuario_Nome]
	          ON [dbo].[Usuario]([Nome])
		    WITH FILLFACTOR = 90
			  ON [PRIMARY]

	CREATE INDEX [Idx_Usuario_UsuarioLogin]
	          ON [dbo].[Usuario]([UsuarioLogin])
		    WITH FILLFACTOR = 90
			  ON [PRIMARY]


  END
GO