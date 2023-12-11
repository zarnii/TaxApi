CREATE TABLE IF NOT EXISTS CarType (
	Id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
	Name TEXT NOT NULL,
	TaxCoefficient Integer
);