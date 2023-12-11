-- Создание таблицы Driver.
CREATE TABLE IF NOT EXISTS Driver (
	Id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
	SecondName TEXT,
	FirtsName TEXT,
	MiddleName TEXT
);