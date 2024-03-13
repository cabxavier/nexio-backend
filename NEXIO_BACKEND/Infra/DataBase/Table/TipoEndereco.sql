IF NOT EXISTS( SELECT name
                 FROM SysObjects
			    WHERE name  = 'TipoEndereco'
			      AND type  = 'U' )
  BEGIN
    
	CREATE TABLE [dbo].[TipoEndereco]
	(
	  IdTipoEndereco   [Int] Identity(1,1) NOT NULL,
	  Descricao        [VarChar](100)      NOT NULL,
	  Principal        [Bit]               NOT NULL,
	  Entrega          [Bit]               NOT NULL,
	  Cobranca         [Bit]               NOT NULL,
	  DataAlteracao    [DateTime]          NOT NULL,
      UsuarioAlteracao [VarChar](20)       NOT NULL,

	  CONSTRAINT [PkTipoEndereco]
	     PRIMARY KEY([IdTipoEndereco])
		    WITH FILLFACTOR = 90
			  ON [PRIMARY],
			    
	  CONSTRAINT [UnTipoEndereco_Descricao]
	      UNIQUE ([Descricao]),

	  CONSTRAINT [CkTipoEndereco]
		   CHECK ( ( [Principal] = 1 ) OR
				   ( [Entrega]   = 1 ) OR
				   ( [Cobranca]  = 1 )
				 ),
	)

	CREATE INDEX [Idx_TipoEndereco_Descricao]
              ON [dbo].[TipoEndereco](Descricao)
		    WITH FILLFACTOR = 90
		      ON [PRIMARY]

	CREATE INDEX [Idx_TipoEndereco_Principal]
              ON [dbo].[TipoEndereco](Principal)
		    WITH FILLFACTOR = 90
		      ON [PRIMARY]

	CREATE INDEX [Idx_TipoEndereco_Entrega]
              ON [dbo].[TipoEndereco](Entrega)
		    WITH FILLFACTOR = 90
		      ON [PRIMARY]

	CREATE INDEX [Idx_TipoEndereco_Cobranca]
              ON [dbo].[TipoEndereco](Cobranca)
		    WITH FILLFACTOR = 90
		      ON [PRIMARY]

    CREATE INDEX [Idx_TipoEndereco_Descricao_090]
              ON [dbo].[TipoEndereco](Descricao)
		 INCLUDE ([Principal],[Entrega],[Cobranca])
		    WITH FILLFACTOR = 90
		      ON [PRIMARY]
  
  END
GO