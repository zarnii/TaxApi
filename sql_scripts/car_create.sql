-- Создание таблицы Car.
CREATE TABLE IF NOT EXISTS Car (
	Id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
	Brand UUID REFERENCES Brand(Id),
	Model UUID REFERENCES Model(Id),
	CarNumberRegion UUID REFERENCES CarNumberRegion(Id),
	CreationYear Date
);