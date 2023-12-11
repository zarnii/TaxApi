-- Создание таблицы DriverDriverLicense
CREATE TABLE IF NOT EXISTS DriverDriverLicense (
	Id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
	Driver UUID REFERENCES Driver(Id),
	DriverLicense UUID REFERENCES DriverLicense(Id)
);