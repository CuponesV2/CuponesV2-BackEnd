
CREATE TABLE Role (
    id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(75) NOT NULL
);

INSERT INTO Role (name)
VALUES ("Asesor"), ("Administrador");

CREATE TABLE MarketingUser (
    id INT PRIMARY KEY AUTO_INCREMENT,
    username VARCHAR(75) NOT NULL,
    password VARCHAR(75) NOT NULL,
    email VARCHAR(150) NOT NULL UNIQUE
);

INSERT INTO MarketingUser (username, password, email)
VALUES ("Juanky", "juanky123", "juanky@gmail.com");

CREATE TABLE UserRole (
    id INT PRIMARY KEY AUTO_INCREMENT,
    user_id INT NOT NULL,
    role_id INT NOT NULL,
    FOREIGN KEY (user_id) REFERENCES MarketingUser(id),
    FOREIGN KEY (role_id) REFERENCES Role(id)
);

INSERT INTO UserRole (user_id, role_id)
VALUES (1, 1);