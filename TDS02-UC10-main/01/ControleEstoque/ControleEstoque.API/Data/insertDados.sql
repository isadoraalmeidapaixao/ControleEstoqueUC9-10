INSERT INTO Fornecedores (NomeFantasia, CNPJ) VALUES
 
('Distribuidora Gama', '12345678000199'),
 
('Loja Tech', '98765432000188'),
 
('Mega Eletronicos', '11223344000155'),
 
('Importadora Digital', '55667788000122');
 
-- =====================
 
-- USUARIOS
 
-- =====================
 
-- Clientes
 
INSERT INTO Usuarios VALUES
 
('Carlos Silva', 'carlos@email.com', '123', 0, 'Cliente', NULL, '11111111111', NULL),
 
('Ana Souza', 'ana@email.com', '123', 0, 'Cliente', NULL, '22222222222', NULL),
 
('Bruno Lima', 'bruno@email.com', '123', 0, 'Cliente', NULL, '33333333333', NULL);
 
-- Caixas
 
INSERT INTO Usuarios VALUES
 
('João Caixa', 'joao@empresa.com', '123', 1, 'Caixa', 'Manhã', NULL, NULL),
 
('Mariana Caixa', 'mariana@empresa.com', '123', 1, 'Caixa', 'Tarde', NULL, NULL);
 
-- Gerente
 
INSERT INTO Usuarios VALUES
 
('Fernanda Gerente', 'gerente@empresa.com', '123', 2, 'Gerente', NULL, NULL, 'Vendas');
 
-- =====================
 
-- PRODUTOS
 
-- =====================
 
INSERT INTO Produtos (Nome, Preco, QauntidadeEstoque, FornecedorId) VALUES
 
('Teclado Mecânico RGB', 250.00, 50, 1),
 
('Mouse Gamer', 120.00, 80, 1),
 
('Monitor 24 Polegadas', 900.00, 30, 2),
 
('Notebook i5', 3500.00, 15, 3),
 
('Headset Gamer', 200.00, 60, 2),
 
('Webcam Full HD', 150.00, 40, 4);
 
-- =====================
 
-- PEDIDOS
 
-- =====================
 
INSERT INTO Pedidos (DataPedido, Status, CaixaId, ClienteId) VALUES
 
(GETDATE(), 'Finalizado', 4, 1),
 
(GETDATE(), 'Finalizado', 5, 2),
 
(GETDATE(), 'Pendente', 4, 3),
 
(GETDATE(), 'Cancelado', 5, 1);
 
-- =====================
 
-- ITENS DOS PEDIDOS
 
-- =====================
 
-- Pedido 1
 
INSERT INTO ItensPedido VALUES (2, 250.00, 1, 1);
 
INSERT INTO ItensPedido VALUES (1, 120.00, 1, 2);
 
-- Pedido 2
 
INSERT INTO ItensPedido VALUES (1, 900.00, 2, 3);
 
INSERT INTO ItensPedido VALUES (2, 200.00, 2, 5);
 
-- Pedido 3
 
INSERT INTO ItensPedido VALUES (1, 3500.00, 3, 4);
 
-- Pedido 4
 
INSERT INTO ItensPedido VALUES (1, 150.00, 4, 6);
 
INSERT INTO ItensPedido VALUES (1, 120.00, 4, 2);