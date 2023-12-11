-- Создание таблицы Brand.
CREATE TABLE IF NOT EXISTS Brand (
	Id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
	Name TEXT
);