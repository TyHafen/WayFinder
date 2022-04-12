CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS trips(
  Id int AUTO_INCREMENT primary key,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name TEXT NOT NULL
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS reservations(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  type TEXT,
  name TEXT NOT NULL,
  confirmationNumber TEXT,
  address TEXT,
  date TEXT,
  cost INT,
  tripId INT NOT NULL,
  FOREIGN KEY (tripId) REFERENCES trips(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';
DROP TABLE reservations;
SELECT
  *
FROM
  reservations;
INSERT INTO
  reservations (
    type,
    name,
    confirmationNumber,
    address,
    date,
    cost,
    tripId
  )
VALUES(
    "vacation",
    "Ty",
    "x27",
    "300 west The Street",
    "may 30 2023",
    125,
    1
  );