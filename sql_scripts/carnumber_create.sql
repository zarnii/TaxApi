-- Создание таблицы CarNumber.
CREATE TABLE IF NOT EXISTS CarNumber (
	Id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
	Number char(6)
);