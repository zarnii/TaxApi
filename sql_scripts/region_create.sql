-- Создание таблицы Region.
CREATE TABLE IF NOT EXISTS Region (
	Id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
	Region Integer
);