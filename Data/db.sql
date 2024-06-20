-- Active: 1718655917808@@bcvrf5vu4wyljyyc0tij-mysql.services.clever-cloud.com@3306

--Creación de Companies
CREATE TABLE Companies (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name Varchar(100),
    Logo Varchar(100),
    Nit Varchar(25) UNIQUE
);


-- Insersion de datos en la tabla Companies
INSERT INTO Companies (Name, Logo, Nit) VALUES 
    ('Company A','logo_a.png','123456789'),
    ('Company B','logo_b.png','987654321'),
    ('Company C','logo_c.png','567890123');


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

-- Insertar datos en la tabla Campaigns
INSERT INTO Campaigns (Name, Description, Start_date, End_date, CompanyId) VALUES
    ('Summer Sale', 'Discounts on summer items', '2023-06-01', '2023-08-31', 1),
    ('Winter Collection', 'New arrivals for winter', '2023-11-01', '2024-02-28', 2);


-- Creación de MarketingUsers
CREATE TABLE MarketingUsers (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    UserName Varchar(100),
    Password Varchar(100),
    Email Varchar(100) UNIQUE
);

-- Insersion de datos en la tabla MarketingUsers
INSERT INTO MarketingUsers (UserName, Password, Email) VALUES 
    ("Anthony","anthony123","anthony@gmail.com"),
    ("Juanky","juanky123","juanky@gmail.com"),
    ("Maicol","maicol123","maicol@gmail.com"),
    ("Juanda","juanda123","juanda@gmail.com");


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
    UserId INT,
    RoleId INT,
    FOREIGN KEY (UserId) REFERENCES MarketingUsers (Id),
    FOREIGN KEY (RoleId) REFERENCES Roles (Id)
);

INSERT INTO UserRole (UserId, RoleId) VALUES 
    (1, 2),
    (2, 2),
    (3, 2),
    (4, 2);

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
    CreatedBy INT,
    Code VARCHAR(255),
    CampaignId INT,
    FOREIGN KEY (CampaignId) REFERENCES Campaigns (Id),
    FOREIGN KEY (CreatedBy) REFERENCES MarketingUsers (Id)
);

drop table Coupons;

-- Insertar datos en la tabla Coupons
INSERT INTO Coupons (Name, Description, Start_date, End_date, Discount_type, Discount_value, Usage_limit, Min_purchase_amount, Max_purchase_amount, Status, Created_By, Code, CampaignId) VALUES
    ('SUMMER20', '20% off on summer sale', '2023-06-01', '2023-08-31', 'Porcentaje', 20, 100, 500, 5000, 'Activo', 1, 'SUM2023', 1),
    ('WINTER10', '10% off on all winter items', '2023-11-01', '2024-02-28', 'Porcentaje', 10, 50, 300, 3000, 'Activo', 2, 'WIN2023', 2);


-- Creación de CouponHistory
CREATE TABLE CouponHistories(
    Id INT AUTO_INCREMENT PRIMARY KEY,
    CouponId INT,
    Change_date Date,
    Field_changed Varchar(100),
    Old_value Varchar(100),
    New_value Varchar(100),
    FOREIGN KEY (CouponId) REFERENCES Coupons (Id)
);

-- Insertar datos en la tabla CouponHistories
INSERT INTO CouponHistories (CouponId, Change_date, Field_changed, Old_value, New_value) VALUES
    (1, '2023-06-10', 'Discount_value', '15', '20'),
    (2, '2023-11-15', 'Usage_limit', '40', '50');


-- Creación de MarketplaceUsers
CREATE TABLE MarketplaceUsers (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    UserName Varchar(100),
    Password VARCHAR(100),
    Email Varchar(100) UNIQUE
);

-- Insertar datos en la tabla MarketplaceUsers
INSERT INTO MarketplaceUsers (UserName, Password, Email) VALUES
    ('User1', 'password1', 'user1@example.com'),
    ('User2', 'password2', 'user2@example.com');


-- Creación de CouponUsage
CREATE TABLE CouponUsages (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    CouponId INT,
    UserMarketplaceId INT,
    Usage_date Date,
    Transaction_amount INT,
    Foreign Key (CouponId) REFERENCES Coupons (Id),
    Foreign Key (UserMarketplaceId) REFERENCES MarketplaceUsers (Id)
);

-- Insertar datos en la tabla CouponUsages
INSERT INTO CouponUsages (CouponId, UserMarketplaceId, Usage_date, Transaction_amount) VALUES
    (1, 1, '2023-06-15', 800),
    (2, 2, '2023-11-20', 1350);



-- Creación de Purchase
CREATE TABLE Purchases (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    UserMarketplaceId INT,
    Date date,
    Amount INT,
    Foreign Key (UserMarketplaceId) REFERENCES MarketplaceUsers (Id)
);

-- Insertar datos en la tabla Purchases
INSERT INTO Purchases (UserMarketplaceId, Date, Amount) VALUES
    (1, '2023-06-15', 1000),
    (2, '2023-11-20', 1500);


-- Creación de PurchaseCoupon
CREATE TABLE PurchaseCoupons (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    PurchaseId INT,
    CouponId INT,
    Foreign Key (PurchaseId) REFERENCES Purchases (Id),
    Foreign Key (CouponId) REFERENCES Coupons (Id)
);

-- Insertar datos en la tabla PurchaseCoupons
INSERT INTO PurchaseCoupons (PurchaseId, CouponId) VALUES
    (1, 1),
    (2, 2);


