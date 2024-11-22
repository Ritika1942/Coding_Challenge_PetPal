CREATE DATABASE PetPals

CREATE TABLE Pets (
    PetID INT IDENTITY PRIMARY KEY, 
    Name VARCHAR(100) NOT NULL, 
    Age INT NOT NULL CHECK (Age > 0), 
    Breed VARCHAR(100) NOT NULL, 
    Type VARCHAR(10) NOT NULL CHECK (Type IN ('Dog', 'Cat')),
    AvailableForAdoption BIT NOT NULL DEFAULT 1
)

CREATE TABLE Shelters (
    ShelterID INT IDENTITY PRIMARY KEY, 
    Name VARCHAR(100) NOT NULL,
    Location VARCHAR(255) NOT NULL 
)

CREATE TABLE Donations (
    DonationID INT IDENTITY PRIMARY KEY, 
    DonorName VARCHAR(100) NOT NULL, 
    DonationType VARCHAR(20) NOT NULL CHECK (DonationType IN ('Cash', 'Item')), 
    DonationAmount DECIMAL(10, 2) NULL, 
    DonationItem VARCHAR(100) NULL, 
    DonationDate DATETIME NOT NULL 
)

CREATE TABLE AdoptionEvents (
    EventID INT IDENTITY PRIMARY KEY, 
    EventName VARCHAR(100) NOT NULL, 
    EventDate DATETIME NOT NULL,
    Location VARCHAR(255) NOT NULL
)

CREATE TABLE Participants (
    ParticipantID INT IDENTITY PRIMARY KEY, 
    ParticipantName VARCHAR(100) NOT NULL, 
    ParticipantType VARCHAR(50) NOT NULL, 
    EventID INT, 
    FOREIGN KEY (EventID) REFERENCES AdoptionEvents(EventID) 
)

CREATE TABLE Dog (
    DogID INT PRIMARY KEY, 
    DogBreed VARCHAR(100) NOT NULL, 
    FOREIGN KEY (DogID) REFERENCES Pets(PetID) 
)

CREATE TABLE Cat (
    CatID INT PRIMARY KEY,
    CatColor VARCHAR(50) NOT NULL, 
    FOREIGN KEY (CatID) REFERENCES Pets(PetID)
)

--insetion of values
INSERT INTO Pets (Name, Age, Breed, Type, AvailableForAdoption)
VALUES
('Buddy', 3, 'Golden Retriever', 'Dog', 1),
('Whiskers', 2, 'Persian', 'Cat', 1),
('Max', 4, 'Labrador', 'Dog', 0),
('Luna', 1, 'Siamese', 'Cat', 1),
('Charlie', 5, 'Beagle', 'Dog', 1)




INSERT INTO Shelters (Name, Location)
VALUES
('Happy Paws Shelter', '1234 Elm Street, Springfield'),
('Furry Friends Shelter', '5678 Oak Avenue, Rivertown'),
('Paws and Claws Shelter', '9101 Maple Road, Greenfield'),
('Safe Haven Animal Shelter', '1122 Pine Lane, Brooksville'),
('The Rescue Shelter', '3344 Cedar Blvd, Hilltop')


INSERT INTO Donations (DonorName, DonationType, DonationAmount, DonationItem, DonationDate)
VALUES
('Anu', 'Cash', 100.00, NULL, '2024-11-01 10:00:00'),
('Janani', 'Item', NULL, 'Dog Food', '2024-11-02 11:30:00'),
('Manisha', 'Cash', 50.00, NULL, '2024-11-03 14:15:00'),
('Guru', 'Item', NULL, 'Cat Toys', '2024-11-04 09:00:00'),
('Mega', 'Cash', 200.00, NULL, '2024-11-05 16:45:00')



INSERT INTO AdoptionEvents (EventName, EventDate, Location)
VALUES
('Adopt a Pet Day', '2024-12-01 10:00:00', 'Central Park, Bangalore'),
('Holiday Pet Adoption Event', '2024-12-10 14:00:00', 'Animal Shelter, Hyderabad'),
('Summer Adoption Drive', '2025-06-15 09:00:00', 'City Plaza, Chennai'),
('Winter Pet Rescue Event', '2025-01-20 11:30:00', 'Main Street, Coimbatore'),
('Spring Fling Adoption Event', '2025-04-05 13:00:00', 'Green Valley Park, Dehradun')


INSERT INTO Participants (ParticipantName, ParticipantType, EventID)
VALUES
('Happy Tails Shelter', 'Shelter', 1),
('Paws for Life', 'Shelter', 2),
('John Doe', 'Adopter', 1),
('Jane Smith', 'Adopter', 3),
('Rescue Me Shelter', 'Shelter', 4)

INSERT INTO Dog (DogID, DogBreed)
VALUES
(1, 'Golden Retriever'),
(2, 'German Shepherd'),
(3, 'Labrador Retriever'),
(4, 'Bulldog'),
(5, 'Beagle')

INSERT INTO Cat (CatID, CatColor)
VALUES
(2, 'White'),       
(4, 'Cream'),     
(11, 'Gray'),       
(12, 'Black'),     
(13, 'Calico')    



SELECT * FROM Pets WHERE Type = 'Cat'
INSERT INTO Cat (CatID, CatColor)
VALUES
(2, 'White'),  
(4, 'Cream')

CREATE TABLE PetShelters (
    ShelterID INT IDENTITY PRIMARY KEY, 
    ShelterName VARCHAR(100) NOT NULL,
    ShelterLocation VARCHAR(255) NOT NULL
)

CREATE TABLE PetShelterPets (
    ShelterID INT, 
    PetID INT, 
    PRIMARY KEY (ShelterID, PetID),
    FOREIGN KEY (ShelterID) REFERENCES PetShelters(ShelterID),
    FOREIGN KEY (PetID) REFERENCES Pets(PetID)
)

INSERT INTO PetShelters (ShelterName, ShelterLocation)
VALUES
('Happy Paws Shelter', '1234 Elm Street, Springfield'),
('Furry Friends Shelter', '5678 Oak Avenue, Rivertown')

INSERT INTO PetShelterPets (ShelterID, PetID)
VALUES
(1, 1),  
(1, 2), 
(2, 3)
ALTER TABLE Dog
DROP CONSTRAINT FK_Dog_Pet
ALTER TABLE Dog
ADD CONSTRAINT FK_Dog_Pet
FOREIGN KEY (DogID) REFERENCES Pets(PetID)
ON DELETE CASCADE


DELETE FROM Pets WHERE PetID = 1

SELECT*FROM Pets

SELECT*FROM Dog
SELECT*FROM Cat


ALTER TABLE Cat

DROP CONSTRAINT FK__Cat__CatID__4E88ABD4

ALTER TABLE Cat
ADD CONSTRAINT FK__Cat__CatID__4E88ABD4
FOREIGN KEY (CatID)
REFERENCES Pets(PetID)
ON DELETE CASCADE


-- Drop the existing foreign key constraint
ALTER TABLE PetShelterPets
DROP CONSTRAINT FK__PetShelte__PetID__5441852A;

-- Create a new foreign key constraint with ON DELETE CASCADE
ALTER TABLE PetShelterPets
ADD CONSTRAINT FK__PetShelte__PetID__5441852A
FOREIGN KEY (PetID)
REFERENCES Pets(PetID)
ON DELETE CASCADE






