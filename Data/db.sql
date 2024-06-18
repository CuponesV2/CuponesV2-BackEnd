-- Active: 1718655917808@@bcvrf5vu4wyljyyc0tij-mysql.services.clever-cloud.com@3306
--Creación de Companies
CREATE TABLE Companies (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name Varchar(100),
    Logo Varchar(100),
    Nit Varchar(25) UNIQUE
);

INSERT INTO
    Companies (Name, Logo, Nit)
VALUES (
        'Company A',
        'logo_a.png',
        '123456789'
    ),
    (
        'Company B',
        'logo_b.png',
        '987654321'
    ),
    (
        'Company C',
        'logo_c.png',
        '567890123'
    );

-- Creación de Campaigns
CREATE TABLE Campaigns (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name Varchar(100),
    Description Varchar(255),
    Start_date Date,
    End_date Date,
    CompanyId INT,
    FOREIGN KEY (CompanyId) REFERENCES Companies (Id)
);

-- Creación de MarketingUsers
CREATE TABLE MarketingUsers (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    UserName Varchar(100),
    Password Varchar(100),
    Email Varchar(100) UNIQUE
);

-- Insersion de datos en la tabla Companies
INSERT INTO
    MarketingUsers (UserName, Password, Email)
VALUES (
        "Anthony",
        "anthony123",
        "anthony@gmail.com"
    ),
    (
        "Juanky",
        "juanky123",
        "juanky@gmail.com"
    ),
    (
        "Maicol",
        "maicol123",
        "maicol@gmail.com"
    ),
    (
        "Juanda",
        "juanda123",
        "juanda@gmail.com"
    );

-- Creación de Role
CREATE TABLE Roles (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name Varchar(55)
);

--Insersion de datos en la tabla Role
INSERT INTO Roles (Name) VALUES ("Asesor"), ("Administrador");

-- Creación de UserRole
CREATE TABLE UserRole (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    User_id INT,
    Role_id INT,
    FOREIGN KEY (User_id) REFERENCES MarketingUsers (ID),
    FOREIGN KEY (Role_id) REFERENCES Roles (Id)
);

INSERT INTO
    UserRole (user_id, role_id)
VALUES (1, 2),
    (1, 2),
    (1, 2),
    (1, 2);

-- Creación de Coupon
CREATE TABLE Coupons (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(100),
    Description VARCHAR(255),
    Start_date Date,
    End_date Date,
    Discount_type ENUM('Porcentaje', 'Valor'),
    Discount_value INT,
    Usage_limit INT,
    Min_purchase_amount INT,
    Max_purchase_amount INT,
    Status ENUM('Activo', 'Inactivo'),
    Created_By INT,
    Code VARCHAR(255),
    CampaignId INT NOT NULL,
    FOREIGN KEY (CampaignId) REFERENCES Campaigns (Id),
    FOREIGN KEY (Created_By) REFERENCES MarketingUsers (Id)
);

-- Creación de CouponHistory
CREATE TABLE CouponHistories(
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Coupon_id INT,
    Change_date Date,
    Field_changed Varchar(100),
    Old_value Varchar(100),
    New_value Varchar(100),
    FOREIGN KEY (Coupon_id) REFERENCES Coupons (Id)
);


-- Creación de MarketplaceUsers
CREATE TABLE MarketplaceUsers (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    UserName Varchar(100),
    Password VARCHAR(100),
    Email Varchar(100) UNIQUE
);


-- Creación de CouponUsage
CREATE TABLE CouponUsages (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Coupon_id INT,
    UserMarketplace_id INT,
    Usage_date Date,
    Transaction_amount INT,
    Foreign Key (Coupon_id) REFERENCES Coupons (Id),
    Foreign Key (UserMarketplace_id) REFERENCES MarketplaceUsers (Id)
);


-- Creación de Purchase
CREATE TABLE Purchases (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    UserMarketplace_id INT,
    Date date,
    Amount INT,
    Foreign Key (UserMarketplace_id) REFERENCES MarketplaceUsers (Id)
);

-- Creación de PurchaseCoupon
CREATE TABLE PurchaseCoupons (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Purchase_id INT,
    Coupon_id INT,
    Foreign Key (Purchase_id) REFERENCES Purchases (Id),
    Foreign Key (Coupon_id) REFERENCES Coupons (Id)
);

-- Insertar datos en la tabla Campaigns
INSERT INTO Campaigns (Name, Description, Start_date, End_date, CompanyId)
VALUES
    ('Summer Sale', 'Discounts on summer items', '2023-06-01', '2023-08-31', 1),
    ('Winter Collection', 'New arrivals for winter', '2023-11-01', '2024-02-28', 2);

-- Insertar datos en la tabla Coupons
INSERT INTO Coupons (Name, Description, Start_date, End_date, Discount_type, Discount_value, Usage_limit, Min_purchase_amount, Max_purchase_amount, Status, Created_By, Code, CampaignId)
VALUES
    ('SUMMER20', '20% off on summer sale', '2023-06-01', '2023-08-31', 'Porcentaje', 20, 100, 500, 5000, 'Activo', 1, 'SUM2023', 1),
    ('WINTER10', '10% off on all winter items', '2023-11-01', '2024-02-28', 'Porcentaje', 10, 50, 300, 3000, 'Activo', 2, 'WIN2023', 2);

-- Insertar datos en la tabla MarketplaceUsers
INSERT INTO MarketplaceUsers (UserName, Password, Email)
VALUES
    ('User1', 'password1', 'user1@example.com'),
    ('User2', 'password2', 'user2@example.com');

-- Insertar datos en la tabla Purchases
INSERT INTO Purchases (UserMarketplace_id, Date, Amount)
VALUES
    (1, '2023-06-15', 1000),
    (2, '2023-11-20', 1500);

-- Insertar datos en la tabla PurchaseCoupons
INSERT INTO PurchaseCoupons (Purchase_id, Coupon_id)
VALUES
    (1, 1),
    (2, 2);

-- Insertar datos en la tabla CouponUsages
INSERT INTO CouponUsages (Coupon_id, UserMarketplace_id, Usage_date, Transaction_amount)
VALUES
    (1, 1, '2023-06-15', 800),
    (2, 2, '2023-11-20', 1350);

-- Insertar datos en la tabla CouponHistories
INSERT INTO CouponHistories (Coupon_id, Change_date, Field_changed, Old_value, New_value)
VALUES
    (1, '2023-06-10', 'Discount_value', '15', '20'),
    (2, '2023-11-15', 'Usage_limit', '40', '50');
