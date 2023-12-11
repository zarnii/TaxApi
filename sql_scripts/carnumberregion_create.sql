-- Создание таблицы CarNumberRegion.
CREATE TABLE IF NOT EXISTS CarNumberRegion (
	Id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
	CarNumber UUID REFERENCES CarNumber(Id),
	Region UUID REFERENCES Region(Id)
);