CREATE DATABASE UsersDb;

CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Surname NVARCHAR(255) NOT NULL
);

INSERT INTO Users (Name, Surname)
VALUES ('John', 'Doe');

INSERT INTO Users (Name, Surname)
VALUES ('Jane', 'Smith');

INSERT INTO Users (Name, Surname)
VALUES ('Alice', 'Johnson');

INSERT INTO Users (Name, Surname)
VALUES ('Bob', 'Brown');

INSERT INTO Users (Name, Surname)
VALUES ('Charlie', 'Davis');

INSERT INTO Users (Name, Surname)
VALUES ('David', 'Miller');

INSERT INTO Users (Name, Surname)
VALUES ('Emma', 'Wilson');

INSERT INTO Users (Name, Surname)
VALUES ('Frank', 'Moore');

INSERT INTO Users (Name, Surname)
VALUES ('Grace', 'Taylor');

INSERT INTO Users (Name, Surname)
VALUES ('Hannah', 'Anderson');

INSERT INTO Users (Name, Surname)
VALUES ('Ivy', 'Thomas');

INSERT INTO Users (Name, Surname)
VALUES ('Jack', 'Jackson');

INSERT INTO Users (Name, Surname)
VALUES ('Karen', 'White');

INSERT INTO Users (Name, Surname)
VALUES ('Leo', 'Harris');

INSERT INTO Users (Name, Surname)
VALUES ('Mia', 'Martin');

INSERT INTO Users (Name, Surname)
VALUES ('Nina', 'Lee');

INSERT INTO Users (Name, Surname)
VALUES ('Oscar', 'Perez');

INSERT INTO Users (Name, Surname)
VALUES ('Paul', 'Clark');

INSERT INTO Users (Name, Surname)
VALUES ('Quincy', 'Rodriguez');

INSERT INTO Users (Name, Surname)
VALUES ('Rachel', 'Lewis');
