-- Database Schema for Benefit Processing
CREATE TABLE Claimants (
    ClaimantID INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100),
    Salary DECIMAL(18, 2),
    MonthsOfService INT,
    GovernmentDebt DECIMAL(18, 2) DEFAULT 0,
    ClaimantType NVARCHAR(50) -- 'Standard' or 'Seasonal'
);

-- Sample Data
INSERT INTO Claimants (FullName, Salary, MonthsOfService, GovernmentDebt, ClaimantType)
VALUES ('Marko Kraljevic', 300000, 150, 15000, 'Standard'),
       ('Jovana Jovic', 80000, 10, 0, 'Seasonal');
