-- ----------------------------
-- Table structure for PedidoItens
-- ----------------------------
DROP TABLE IF EXISTS "public"."PedidoItens";
CREATE TABLE "public"."PedidoItens" (
  "Id" uuid NOT NULL,
  "PedidoId" uuid NOT NULL,
  "ProdutoId" uuid NOT NULL,
  "ProdutoNome" varchar(100) COLLATE "pg_catalog"."default",
  "Quantidade" int4 NOT NULL,
  "ValorUnitario" numeric NOT NULL
)
;

-- ----------------------------
-- Records of PedidoItens
-- ----------------------------
INSERT INTO "public"."PedidoItens" VALUES ('ab8e09b5-58b3-497c-bf3a-3ae3d777d759', '7481b601-7ae4-4fc0-beae-6e3d27a707b3', '82e966fe-806e-4395-97af-20bcf4f31733', 'Camiseta Debugar Preta', 2, 110);

-- ----------------------------
-- Table structure for Pedidos
-- ----------------------------
DROP TABLE IF EXISTS "public"."Pedidos";
CREATE TABLE "public"."Pedidos" (
  "Id" uuid NOT NULL,
  "Codigo" int4 NOT NULL,
  "ClienteId" uuid NOT NULL,
  "VoucherId" uuid,
  "VoucherUtilizado" bool NOT NULL,
  "Desconto" numeric NOT NULL,
  "ValorTotal" numeric NOT NULL,
  "DataCadastro" timestamp(6) NOT NULL,
  "PedidoStatus" int4 NOT NULL
)
;

-- ----------------------------
-- Records of Pedidos
-- ----------------------------
INSERT INTO "public"."Pedidos" VALUES ('7481b601-7ae4-4fc0-beae-6e3d27a707b3', 0, '7030f1d4-a952-4b27-b323-7277615621fb', NULL, 'f', 0, 220, '2021-02-28 21:01:11.862132', 0);

-- ----------------------------
-- Table structure for Vouchers
-- ----------------------------
DROP TABLE IF EXISTS "public"."Vouchers";
CREATE TABLE "public"."Vouchers" (
  "Id" uuid NOT NULL,
  "Codigo" varchar(100) COLLATE "pg_catalog"."default",
  "Percentual" numeric,
  "ValorDesconto" numeric,
  "Quantidade" int4 NOT NULL,
  "TipoDescontoVoucher" int4 NOT NULL,
  "DataCriacao" timestamp(6) NOT NULL,
  "DataUtilizacao" timestamp(6),
  "DataValidade" timestamp(6) NOT NULL,
  "Ativo" bool NOT NULL,
  "Utilizado" bool NOT NULL
)
;

-- ----------------------------
-- Records of Vouchers
-- ----------------------------

-- ----------------------------
-- Indexes structure for table PedidoItens
-- ----------------------------
CREATE INDEX "IX_PedidoItens_PedidoId" ON "public"."PedidoItens" USING btree (
  "PedidoId" "pg_catalog"."uuid_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table PedidoItens
-- ----------------------------
ALTER TABLE "public"."PedidoItens" ADD CONSTRAINT "PK_PedidoItens" PRIMARY KEY ("Id");

-- ----------------------------
-- Indexes structure for table Pedidos
-- ----------------------------
CREATE INDEX "IX_Pedidos_VoucherId" ON "public"."Pedidos" USING btree (
  "VoucherId" "pg_catalog"."uuid_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table Pedidos
-- ----------------------------
ALTER TABLE "public"."Pedidos" ADD CONSTRAINT "PK_Pedidos" PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table Vouchers
-- ----------------------------
ALTER TABLE "public"."Vouchers" ADD CONSTRAINT "PK_Vouchers" PRIMARY KEY ("Id");

-- ----------------------------
-- Foreign Keys structure for table PedidoItens
-- ----------------------------
ALTER TABLE "public"."PedidoItens" ADD CONSTRAINT "FK_PedidoItens_Pedidos_PedidoId" FOREIGN KEY ("PedidoId") REFERENCES "public"."Pedidos" ("Id") ON DELETE RESTRICT ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table Pedidos
-- ----------------------------
ALTER TABLE "public"."Pedidos" ADD CONSTRAINT "FK_Pedidos_Vouchers_VoucherId" FOREIGN KEY ("VoucherId") REFERENCES "public"."Vouchers" ("Id") ON DELETE RESTRICT ON UPDATE NO ACTION;
