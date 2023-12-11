CREATE TABLE IF NOT EXISTS Engine (
	Id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
	Name TEXT,
	Power Integer
);