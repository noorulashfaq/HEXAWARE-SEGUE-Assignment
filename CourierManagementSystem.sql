-- creating the db
CREATE DATABASE CourierMgtSystem
USE CourierMgtSystem

-- creating schemas for tables
-- Users
CREATE TABLE Users(
UserID INT PRIMARY KEY IDENTITY,  
Name VARCHAR(255),  
Email VARCHAR(255) UNIQUE,
Password VARCHAR(255),  
ContactNumber VARCHAR(20),  
Address TEXT
);

-- Couriers
CREATE TABLE Couriers(
CourierID INT PRIMARY KEY IDENTITY,
SenderID int,
ReceiverName VARCHAR(255),  
ReceiverAddress TEXT,  
Weight DECIMAL(5, 2),  
Status VARCHAR(50),  
TrackingNumber VARCHAR(20) UNIQUE,
ServiceID int,
EmployeeID int,
DeliveryDate DATE
);

-- CourierServices
CREATE TABLE CourierServices(
ServiceID INT PRIMARY KEY IDENTITY,  
ServiceName VARCHAR(100),  
Cost DECIMAL(8, 2)
);

-- Employees
CREATE TABLE Employees(
EmployeeID INT PRIMARY KEY IDENTITY,  
Name VARCHAR(255),  
Email VARCHAR(255) UNIQUE,  
ContactNumber VARCHAR(20),  
Role VARCHAR(50),  
Salary DECIMAL(10, 2)
);

-- Locations
CREATE TABLE Locations(
LocationID INT PRIMARY KEY IDENTITY,  
LocationName VARCHAR(100),  
Address TEXT
);

-- Payments
CREATE TABLE Payments(
PaymentID INT PRIMARY KEY IDENTITY,  
CourierID INT,  
LocationID INT,  
Amount DECIMAL(10, 2),
PaymentDate DATE
);

------------------------------------------
------------- relations ------------------
------------------------------------------

ALTER TABLE Couriers
ADD CONSTRAINT FK_Couriers_Users
FOREIGN KEY (SenderID) REFERENCES Users(UserID);

ALTER TABLE Couriers
ADD CONSTRAINT FK_Couriers_Employees
FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID);

ALTER TABLE Couriers
ADD CONSTRAINT FK_Couriers_Services
FOREIGN KEY (ServiceID) REFERENCES CourierServices(ServiceID);

ALTER TABLE Payments
ADD CONSTRAINT FK_Payments_Locations
FOREIGN KEY (LocationID) REFERENCES Locations(LocationID);

ALTER TABLE Payments
ADD CONSTRAINT FK_Payments_Couriers
FOREIGN KEY (CourierID) REFERENCES Couriers(CourierID);

-- Inserting arbitrary values

INSERT INTO Users (Name, Email, Password, ContactNumber, Address) VALUES 
	('MS Dhoni', 'dhoni@example.com', 'password321', '5556667777', '101 Pine Street'),
    ('Sachin Tendulkar', 'sachin@example.com', 'password123', '1234567890', '123 Elm Street'),
    ('Virat Kohli', 'virat@example.com', 'password456', '0987654321', '456 Oak Street'),
	('Rohit Sharma', 'rohit@example.com', 'password789', '2223334444', '789 Maple Street');

SELECT * FROM Users;

INSERT INTO CourierServices (ServiceName, Cost)
VALUES 
    ('SpeedExpress', 150.00),
    ('FastTrack Couriers', 200.00),
    ('Tamil Nadu Logistics', 180.00),
    ('ExpressDelivery TN', 220.00),
    ('TN Quick Couriers', 250.00);

SELECT * FROM CourierServices;

INSERT INTO Employees (Name, Email, ContactNumber, Role, Salary)
VALUES 
    ('Vadivelu', 'vadivelu@example.com', '1234567890', 'Manager', 75000.00),
    ('Goundamani', 'goundamani@example.com', '0987654321', 'Director', 85000.00),
    ('Senthil', 'senthil@example.com', '1122334455', 'Supervisor', 65000.00),
    ('Santhanam', 'santhanam@example.com', '2233445566', 'Team Lead', 70000.00);

SELECT * FROM Employees;

INSERT INTO Locations (LocationName, Address)
VALUES 
    ('Bangalore Office', '456 MG Road, Bangalore, Karnataka, India'),
    ('Chennai Branch', '789 Anna Salai, Chennai, Tamil Nadu, India'),
    ('Delhi Headquarters', '101 Connaught Place, New Delhi, Delhi, India'),
    ('Kolkata Office', '102 Park Street, Kolkata, West Bengal, India');

SELECT * FROM Locations;

INSERT INTO Couriers (SenderID, ReceiverName, ReceiverAddress, Weight, Status, TrackingNumber, ServiceID, EmployeeID, DeliveryDate)
VALUES 
    (1, 'Vijay Sethupathi', '123 Main St, Chennai, Tamil Nadu', 5.00, 'In Transit', 'TRK123456789', 1, 1, '2024-11-01'),
    (2, 'Nayanthara', '456 Elm St, Bangalore, Karnataka', 10.50, 'Delivered', 'TRK987654321', 2, 2, '2024-11-02'),
    (3, 'Dhanush', '789 Oak St, Mumbai, Maharashtra', 2.25, 'Pending', 'TRK112233445', 3, 2, '2024-11-03'),
    (4, 'Sivakarthikeyan', '321 Pine St, Hyderabad, Telangana', 7.75, 'In Transit', 'TRK556677889', 4, 4, '2024-11-04'),
    (1, 'Trisha Krishnan', '654 Maple St, Kolkata, West Bengal', 3.00, 'Delivered', 'TRK223344556', 1, 3, '2024-11-05'),
    (2, 'Kajal Aggarwal', '987 Cedar St, Delhi', 8.90, 'In Transit', 'TRK889900112', 2, 3, '2024-11-06'),
    (3, 'Radhika Apte', '543 Spruce St, Pune, Maharashtra', 4.80, 'Pending', 'TRK445566778', 3, 4, '2024-11-07'),
    (4, 'Keerthy Suresh', '234 Fir St, Jaipur, Rajasthan', 6.30, 'In Transit', 'TRK334455667', 4, 1, '2024-11-08');

SELECT * FROM Couriers;

INSERT INTO Payments (CourierID, LocationID, Amount, PaymentDate)
VALUES 
    (2, 2, 175.50, '2024-11-02'),
    (3, 3, 300.75, '2024-11-03'),
    (4, 4, 220.25, '2024-11-04'),
    (3, 2, 150.00, '2024-11-05'),
    (2, 3, 200.50, '2024-11-06'),
    (3, 4, 275.80, '2024-11-07'),
    (4, 1, 180.25, '2024-11-08'),
    (4, 3, 320.00, '2024-11-09'),
    (2, 4, 250.00, '2024-11-10');

SELECT * FROM Payments;

ALTER TABLE Couriers
ADD OrderedDate DATE;

UPDATE Couriers SET OrderedDate = '2024-03-02';

------------------------------------------
-- Task 2: Select, Where -----------------
------------------------------------------

-- 1. List all customers:
SELECT * FROM Users;

-- 2. List all orders for a specific customer: 
SELECT * FROM Couriers where SenderID = 1;

-- 3. List all couriers:
SELECT * FROM Couriers;

-- 4. List all packages for a specific order:
SELECT * FROM Couriers where SenderID = 3;

-- 5. List all deliveries for a specific courier:
SELECT * FROM Couriers where ServiceID = 3;

-- 6. List all undelivered packages:
SELECT * FROM Couriers where Status != 'Delivered';

-- 7. List all packages that are scheduled for delivery today:
SELECT * FROM Couriers where DeliveryDate = FORMAT(GETDATE(), 'yyyy-MM-dd');

-- 8. List all packages with a specific status:
SELECT * FROM Couriers where Status = 'Delivered';
SELECT * FROM Couriers where Status = 'Pending';
SELECT * FROM Couriers where Status = 'In Transit';

-- 9. Calculate the total number of packages for each courier:
SELECT COUNT(CourierID) FROM Couriers where ServiceID = 1;

-- 10. Find the average delivery time for each courier:
SELECT CourierID, DATEDIFF(day, OrderedDate, DeliveryDate) AS AvgDeliveryTime FROM Couriers;

-- 11. List all packages with a specific weight range:
SELECT * FROM Couriers where Weight = 5.00;

-- 12. Retrieve employees whose names contain 'velu':
SELECT * FROM Employees where Name like '%velu%';

-- 13. Retrieve all courier records with payments greater than $200:
SELECT * FROM Payments where Amount > 200;

-------------------------------------------------------------------------------
-- Task 3: GroupBy, Aggregate Functions, Having, Order By, where --------------
-------------------------------------------------------------------------------

-- 14. Find the total number of couriers handled by each employee:
SELECT EmployeeID, COUNT(CourierID) AS NumberOfCouriers
FROM Couriers
GROUP BY EmployeeID;

-- 15. Calculate the total revenue generated by each location:
SELECT LocationID, SUM(Amount) AS TotalRevenue
FROM Payments
GROUP BY LocationID;

-- 16. Find the total number of couriers delivered to each location:
SELECT LocationID, COUNT(CourierID) AS NumberOfCouriers
FROM Payments
GROUP BY LocationID;

-- 17. Find the courier with the highest average delivery time:
SELECT MAX(DATEDIFF(day, OrderedDate, DeliveryDate)) AS HighDeliveryTime FROM Couriers;

-- 18. Find Locations with Total Payments Less Than a Certain Amount:
SELECT LocationID, SUM(Amount) AS TotalAmount
FROM Payments
GROUP BY LocationID
HAVING SUM(Amount) < 500;

-- 19. Calculate Total Payments per Location:
SELECT LocationID, SUM(Amount) AS TotalAmount
FROM Payments
GROUP BY LocationID;

-- 20. Retrieve couriers who have received payments totaling more than $1000 in a specific location (LocationID = X):
SELECT CourierID, SUM(Amount) AS TotalAmount
FROM Payments
where LocationID = 3
GROUP BY CourierID
HAVING SUM(Amount) > 1000;

-- 21. Retrieve couriers who have received payments totaling more than $1000 after a certain date (PaymentDate > 'YYYY-MM-DD'):
SELECT CourierID, SUM(Amount) AS TotalAmount
FROM Payments
where PaymentDate > '2024-10-09'
GROUP BY CourierID
HAVING SUM(Amount) > 1000;

-- 22. Retrieve locations where the total amount received is more than $5000 before a certain date (PaymentDate > 'YYYY-MM-DD'):
SELECT CourierID, SUM(Amount) AS TotalAmount
FROM Payments
where PaymentDate < '2024-11-17'
GROUP BY CourierID
HAVING SUM(Amount) > 1000;

------------------------------------------------------------------------------------------------
-- Task 4: Inner Join,Full Outer Join, Cross Join, Left Outer Join,Right Outer Join ------------
------------------------------------------------------------------------------------------------

-- 23. Retrieve Payments with Courier Information
SELECT P.PaymentID, C.CourierID, U.Name AS SenderName, C.ReceiverName, C.TrackingNumber
FROM Payments AS P
INNER JOIN Couriers AS C
ON P.CourierID = C.CourierID
INNER JOIN Users AS U
ON C.SenderID = U.UserID;

-- 24. Retrieve Payments with Location Information
SELECT P.PaymentID, P.Amount, P.PaymentDate, L.LocationName FROM Payments AS P
INNER JOIN Locations AS L
ON P.LocationID = L.LocationID;

-- 25. Retrieve Payments with Courier and Location Information
SELECT P.PaymentID, P.Amount, P.PaymentDate, C.CourierID, C.TrackingNumber, L.LocationName
FROM Payments AS P
INNER JOIN Couriers AS C
ON P.CourierID = C.CourierID
INNER JOIN Locations AS L
ON P.LocationID = L.LocationID;

-- 26. List all payments with courier details
SELECT P.PaymentID, P.Amount, P.PaymentDate, C.CourierID, C.TrackingNumber
FROM Payments AS P
INNER JOIN Couriers AS C
ON P.CourierID = C.CourierID;

-- 27. Total payments received for each courier
SELECT CourierID, COUNT(PaymentID) AS NumberOfPayments, SUM(Amount) AS TotalAmount
FROM Payments
GROUP BY CourierID;

-- 28. List payments made on a specific date
SELECT * FROM Payments where PaymentDate = '2024-11-02';

-- 29. Get Courier Information for Each Payment
SELECT P.PaymentID, C.CourierID, C.TrackingNumber, C.OrderedDate, C.DeliveryDate
FROM Payments AS P
INNER JOIN Couriers AS C
ON P.CourierID = C.CourierID;

-- 30. Get Payment Details with Location (repeated)
SELECT P.PaymentID, P.PaymentDate, L.LocationName
FROM Payments AS P
INNER JOIN Locations AS L
ON L.LocationID = P.LocationID;

-- 31. Calculating Total Payments for Each Courier
SELECT CourierID, SUM(Amount) AS TotalPayments FROM Payments GROUP BY CourierID;

-- 32. List Payments Within a Date Range
SELECT * FROM Payments where PaymentDate < '2024-11-07' and PaymentDate > '2024-11-03';

-- 33. Retrieve a list of all users and their corresponding courier records, including cases where there are no matches on either side
SELECT U.Name, C.CourierID
FROM Couriers AS C
RIGHT JOIN Users AS U
ON C.SenderID = U.UserID;

-- 34. Retrieve a list of all couriers and their corresponding services, including cases where there are no matches on either side 
SELECT C.CourierID, C.TrackingNumber, CS.ServiceID, CS.ServiceName
FROM Couriers AS C
RIGHT JOIN CourierServices AS CS
ON C.ServiceID = CS.ServiceID;

-- 35. Retrieve a list of all employees and their corresponding payments, including cases where there are no matches on either side 


-- 36. List all users and all courier services, showing all possible combinations
SELECT * FROM Users
CROSS JOIN CourierServices;

-- 37. List all employees and all locations, showing all possible combinations
SELECT * FROM Employees
CROSS JOIN Locations;

-- 38. Retrieve a list of couriers and their corresponding sender information (if available)
SELECT C.CourierID, C.TrackingNumber, C.Status, U.Name, U.ContactNumber
FROM Couriers AS C
INNER JOIN Users AS U
ON C.SenderID = U.UserID;

-- 39. Retrieve a list of couriers and their corresponding receiver information (if available)
SELECT CourierID, ReceiverName, ReceiverAddress FROM Couriers;

-- 40. Retrieve a list of couriers along with the courier service details (if available)
SELECT C.CourierID, C.TrackingNumber, CS.ServiceName
FROM Couriers AS C
INNER JOIN CourierServices AS CS
ON C.ServiceID = CS.ServiceID;

-- 41. Retrieve a list of employees and the number of couriers assigned to each employee
SELECT E.EmployeeID, E.Name, COUNT(C.CourierID) AS NumberOfCouriers
FROM Employees AS E
INNER JOIN Couriers AS C
ON E.EmployeeID = C.EmployeeID
GROUP BY E.EmployeeID, E.Name;

-- 42. Retrieve a list of locations and the total payment amount received at each location
SELECT L.LocationName, SUM(P.Amount) AS TotalPayment
FROM Locations AS L
INNER JOIN Payments AS P
ON L.LocationID = P.LocationID
GROUP BY L.LocationName;

-- 43. Retrieve all couriers sent by the same sender (based on SenderName)
SELECT C.CourierID, C.TrackingNumber, U.Name
FROM Couriers AS C
INNER JOIN Users AS U
on C.SenderID = U.UserID
WHERE U.Name = 'MS Dhoni';

-- 44. List all employees who share the same role
SELECT E1.* FROM Employees E1
INNER JOIN Employees E2 ON E1.Role = E2.Role 
WHERE E1.EmployeeID <> E2.EmployeeID;

-- 45. Retrieve all payments made for couriers sent from the same location
SELECT L.LocationName, COUNT(L.LocationID) as NumberOfCouriers
FROM Payments AS P
INNER JOIN Locations AS L
ON P.LocationID = L.LocationID
GROUP BY L.LocationID, L.LocationName;

-- 46. Retrieve all couriers sent from the same location (based on SenderAddress)
SELECT C.CourierID, U.UserID, U.Address
FROM Couriers AS C
INNER JOIN Users AS U
ON C.SenderID = U.UserID
ORDER BY U.UserID;

-- 47. List employees and the number of couriers they have delivered
SELECT E.EmployeeID, COUNT(C.CourierID) AS NumberOfCouriers
FROM Employees AS E
INNER JOIN Couriers AS C
ON E.EmployeeID = C.EmployeeID
GROUP BY E.EmployeeID
ORDER BY E.EmployeeID;

-- 48. Find couriers that were paid an amount greater than the cost of their respective courier services
SELECT C.CourierID, C.TrackingNumber, P.Amount, CS.ServiceName, CS.Cost
FROM Couriers AS C
INNER JOIN Payments AS P
ON C.CourierID = P.CourierID
INNER JOIN CourierServices AS CS
ON C.ServiceID = CS.ServiceID
WHERE P.Amount > CS.Cost;

-- 49. Find couriers that have a weight greater than the average weight of all couriers
SELECT * FROM Couriers WHERE Weight > (SELECT AVG(Weight) FROM Couriers);

-- 50. Find the names of all employees who have a salary greater than the average salary
SELECT * FROM Employees WHERE Salary > (SELECT AVG(Salary) FROM Employees);

-- 51. Find the total cost of all courier services where the cost is less than the maximum cost
SELECT SUM(Cost) AS TotalCost FROM CourierServices WHERE Cost < (SELECT MAX(Cost) FROM CourierServices);

-- 52. Find all couriers that have been paid for
SELECT * FROM Couriers WHERE CourierID IN (SELECT CourierID FROM Payments);

-- 53. Find the locations where the maximum payment amount was made
SELECT * FROM Locations WHERE LocationID IN (SELECT TOP 1 LocationID FROM Payments ORDER BY Amount DESC);

-- 54. Find all couriers whose weight is greater than the weight of all couriers sent by a specific sender (e.g., 'SenderName')
SELECT TOP 1 * FROM Couriers WHERE SenderID = (SELECT UserID FROM Users WHERE Name = 'MS Dhoni') ORDER BY Weight DESC;







------------------------------
SELECT * FROM Couriers;
SELECT * FROM Payments;
SELECT * FROM Employees;
SELECT * FROM CourierServices;
SELECT * FROM Locations;
SELECT * FROM Users;


--------------------------

ALTER TABLE Couriers
ADD CONSTRAINT Check_Status
CHECK (Status IN ('Yet to Transit', 'In Transit', 'Delivered'));

ALTER TABLE Couriers
ADD CONSTRAINT Def_Status
DEFAULT 'Yet to transit' FOR Status;