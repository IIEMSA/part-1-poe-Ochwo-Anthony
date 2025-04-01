--CREATE 'VENUE' TABLE
CREATE TABLE Venue (
    VenueId INT IDENTITY(1,1) PRIMARY KEY,
    VenueName VARCHAR(255) NOT NULL,
    Location VARCHAR(255) NOT NULL,
    Capacity INT NOT NULL,
    ImageUrl VARCHAR(500)
);

--CREATE 'EVENT' TABLE
CREATE TABLE Event (
    EventId INT IDENTITY(1,1) PRIMARY KEY,
    EventName VARCHAR(255) NOT NULL,
    EventDate DATE NOT NULL,
    Description VARCHAR(MAX),
    VenueId INT NOT NULL,
    CONSTRAINT FK_Event_Venues FOREIGN KEY (VenueId) REFERENCES Venue(VenueId)
);

--CREATE 'BOOKING' TABLE
CREATE TABLE Booking (
    BookingId INT IDENTITY(1,1) PRIMARY KEY,
    EventId INT NOT NULL,
    VenueId INT NOT NULL,
    BookingDate DATE NOT NULL,
    CONSTRAINT FK_Booking_Events FOREIGN KEY (EventId) REFERENCES Event(EventId),
    CONSTRAINT FK_Booking_Venues FOREIGN KEY (VenueId) REFERENCES Venue(VenueId)
);

-- SAMPLE DATA 'VENUE'
INSERT INTO Venue (VenueName, Location, Capacity, ImageUrl) VALUES
('Grand Hall', 'Pretoria', 500, 'https://unsplash.com/photos/a-large-hall-with-a-clock-on-the-ceiling-Am6Vpx1RyUY'),
('Skyline Conference Center', 'Johannesburg', 300, 'https://unsplash.com/photos/a-room-filled-with-chairs-and-a-projector-screen-onxFGIkDvcI'),
('Oceanview Pavilion', 'Cape Town', 200, 'https://unsplash.com/photos/a-sandy-area-with-palm-trees-and-benches-hMdO_dYy0K0');

-- SAMPLE DATA 'EVENT'
INSERT INTO Event (EventName, EventDate, Description, VenueId) VALUES
('Tech Conference 2025', '2025-06-15', 'A conference on emerging tech trends.', 1),
('Music Fest 2025', '2025-07-22', 'A festival featuring live bands.', 2),
('Business Summit', '2025-08-10', 'Annual business networking event.', 3);

-- SAMPLE DATA 'BOOKING'
INSERT INTO Booking (EventId, VenueId, BookingDate) VALUES
(1, 1, '2025-06-01'),
(2, 2, '2025-07-05'),
(3, 3, '2025-07-20');

SELECT * FROM Venue
SELECT * FROM Event
SELECT * FROM Booking