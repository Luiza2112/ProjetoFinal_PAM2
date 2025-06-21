create database ApiFeedback;

create table Feedback(
	id INT IDENTITY PRIMARY KEY,
	remetente VARCHAR(50),
	destinatario VARCHAR(50),
	descricao VARCHAR(450),
	data DATE

);