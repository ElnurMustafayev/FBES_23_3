CREATE TABLE Products (
    Id SERIAL PRIMARY KEY,
    Name TEXT NOT NULL,
    Description TEXT,
    Price DECIMAL(10, 2) NOT NULL,
    Quantity INT NOT NULL,
    CreatedAt TIMESTAMP NOT NULL
);

INSERT INTO Products (Name, Description, Price, Quantity, CreatedAt) VALUES
('Laptop', '15-inch display, 16GB RAM', 1200.00, 10, '2025-05-01 10:00:00'),
('Smartphone', '128GB storage, dual camera', 799.99, 25, '2025-05-02 12:30:00'),
('Headphones', 'Noise-cancelling', 199.50, 50, '2025-05-03 09:15:00'),
('Monitor', '27-inch 4K UHD', 349.90, 15, '2025-05-03 14:45:00'),
('Keyboard', 'Mechanical, backlit', 89.99, 30, '2025-05-04 11:20:00'),
('Mouse', 'Wireless, ergonomic', 49.95, 40, '2025-05-04 16:10:00'),
('Tablet', '10-inch screen, 64GB', 299.00, 20, '2025-05-05 08:00:00'),
('Smartwatch', 'Heart rate monitor, GPS', 179.99, 35, '2025-05-05 13:45:00'),
('External HDD', '2TB USB 3.0', 99.95, 60, '2025-05-06 10:30:00'),
('Webcam', '1080p HD', 59.90, 45, '2025-05-06 17:25:00');