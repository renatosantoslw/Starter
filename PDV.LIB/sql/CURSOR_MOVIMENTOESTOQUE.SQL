CREATE OR REPLACE FUNCTION ATUALIZA_SALDOATUAL_PRODUTO() RETURNS TRIGGER AS $$
   BEGIN
   /* [ REGRAS ]
	1. Quando for transferencia de estoque não mexer no saldo atual, somente em saldo do almoxarifado.

   */
      IF (TG_OP = 'INSERT') THEN
         -- ATUALIZA O SALDOESTOQUE DO PRODUTO
         UPDATE PRODUTO SET SALDOESTOQUE = ((SELECT SALDOESTOQUE 
                                               FROM PRODUTO 
                                             WHERE IDPRODUTO = NEW.IDPRODUTO) + (CASE 
                                                                                   WHEN NEW.IDITEMTRANSFERENCIAESTOQUE IS NOT NULL THEN 0
                                                                                   WHEN NEW.TIPO = 0 THEN NEW.QUANTIDADE
                                                                                   WHEN NEW.TIPO = 1 THEN NEW.QUANTIDADE * -1 
                                                                                 END))
          WHERE IDPRODUTO = NEW.IDPRODUTO;

          -- ATUALIZA O SALDO ATUAL EM MOVIMENTOESTOQUE
          UPDATE MOVIMENTOESTOQUE SET SALDOATUAL = ((SELECT SUM(SALDOATUAL) 
                                                       FROM ((SELECT SALDOATUAL
                                                                 FROM MOVIMENTOESTOQUE 
                                                              WHERE IDPRODUTO = NEW.IDPRODUTO
                                                                AND IDMOVIMENTOESTOQUE <> NEW.IDMOVIMENTOESTOQUE
                                                              ORDER BY IDMOVIMENTOESTOQUE DESC LIMIT 1)

                                                              UNION 
                                                              SELECT CAST(0 AS NUMERIC(15,4)) AS SALDOATUAL
                                                    ) AS _PRODS) + (CASE 
                                                                      WHEN NEW.IDITEMTRANSFERENCIAESTOQUE IS NOT NULL THEN 0
                                                                      WHEN NEW.TIPO = 0 THEN NEW.QUANTIDADE 
                                                                      WHEN NEW.TIPO = 1 THEN NEW.QUANTIDADE * -1 
                                                                    END))
          WHERE IDMOVIMENTOESTOQUE = NEW.IDMOVIMENTOESTOQUE;

          -- ATUALIZA O SALDO ATUAL DO ALMOXARIFADO
          UPDATE MOVIMENTOESTOQUE SET SALDOALMOXARIFADO = ((SELECT SUM(SALDOALMOXARIFADO) 
                                                       FROM ((SELECT SALDOALMOXARIFADO
                                                                 FROM MOVIMENTOESTOQUE 
                                                              WHERE IDPRODUTO = NEW.IDPRODUTO
                                                                AND IDMOVIMENTOESTOQUE <> NEW.IDMOVIMENTOESTOQUE
                                                                AND IDALMOXARIFADO = NEW.IDALMOXARIFADO
                                                              ORDER BY IDMOVIMENTOESTOQUE DESC LIMIT 1)

                                                              UNION 
                                                              SELECT CAST(0 AS NUMERIC(15,4)) AS SALDOALMOXARIFADO
                                                    ) AS _PRODS) + (CASE 
                                                                      WHEN NEW.TIPO = 0 THEN NEW.QUANTIDADE 
                                                                      WHEN NEW.TIPO = 1 THEN NEW.QUANTIDADE * -1 
                                                                    END))
          WHERE IDMOVIMENTOESTOQUE = NEW.IDMOVIMENTOESTOQUE;

          -- ATUALIZA SALDOS DO INVENTARIO
          IF NEW.IDITEMINVENTARIO IS NOT NULL THEN
              UPDATE MOVIMENTOESTOQUE 
                 SET SALDOALMOXARIFADO = NEW.QUANTIDADE,
                     SALDOATUAL = NEW.QUANTIDADE
                 WHERE IDMOVIMENTOESTOQUE = NEW.IDMOVIMENTOESTOQUE;
          END IF;
          
         RETURN NEW;
      END IF;
      RETURN NULL;
   END;
$$ language plpgsql;

CREATE TRIGGER MOVIMENTACAOESTOQUE_PRODUTO AFTER INSERT ON MOVIMENTOESTOQUE FOR EACH ROW EXECUTE PROCEDURE ATUALIZA_SALDOATUAL_PRODUTO();