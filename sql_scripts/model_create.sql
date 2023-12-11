-- Создание таблицы Model.
CREATE TABLE IF NOT EXISTS Model (
	Id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
	Name TEXT,
	Power Integer
);