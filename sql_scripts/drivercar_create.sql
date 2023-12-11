-- Создание таблицы DriverCar
CREATE TABLE IF NOT EXISTS DriverCar (
	Id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
	Driver UUID REFERENCES Driver(Id),
	Car UUID REFERENCES Car(Id),
	HoldingPeriod Integer 
);