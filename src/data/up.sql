CREATE TABLE Person (
    id INT PRIMARY KEY IDENTITY(1,1),
    identity_id NVARCHAR(450) UNIQUE
    -- Add other columns as needed
);

-- Step 2: Create the Collections table
CREATE TABLE Collections (
    id INT PRIMARY Key IDENTITY (1,1),
    person_id INT,
    name VARCHAR(255) NOT NULL,
    tags VARCHAR(1000),
    description VARCHAR(MAX),
    img VARCHAR(MAX),
    FOREIGN KEY (person_id) REFERENCES Person(id)
);

-- Step 3: Create the Recipes table
CREATE TABLE Recipes (
    id INT PRIMARY KEY IDENTITY(1,1),
    collection_id INT,
    person_id INT, -- New column
    name VARCHAR(255) NOT NULL,
    description VARCHAR(MAX),
    img VARCHAR(MAX),
    uri VARCHAR(MAX),
    FOREIGN KEY (collection_id) REFERENCES Collections(id),
    FOREIGN KEY (person_id) REFERENCES Person(id) -- New foreign key constraint
);

-- Step 4: Create the FavoriteRecipes table
CREATE TABLE FavoriteRecipe (
    id INT PRIMARY KEY IDENTITY(1,1),
    person_id INT NOT NULL,
    recipe_id VARCHAR(MAX),
    favorite_date DATETIME NOT NULL,
    ImageUrl VARCHAR(MAX),
    Label VARCHAR(MAX),
    Uri VARCHAR(MAX),
    tags VARCHAR(MAX),
);

-- Step 4: Create the Videos table
CREATE TABLE Videos (
    id INT PRIMARY KEY IDENTITY(1,1),
    person_id INT,
    video_name VARCHAR(255) NOT NULL,
    video_type VARCHAR(100),
    video_link VARCHAR(MAX),
    video_notes VARCHAR(MAX),
    FOREIGN KEY (person_id) REFERENCES Person(id)
);

-- Step 5: Create the Restaurants table
CREATE TABLE Restaurants (
    id INT PRIMARY KEY IDENTITY(1,1),
    person_id INT,
    restaurants_name VARCHAR(255) NOT NULL,
    restaurants_address VARCHAR(MAX),
    restaurants_website VARCHAR(MAX),
    restaurants_menu VARCHAR(MAX),
    restaurants_phone_number VARCHAR(20),
    restaurants_notes VARCHAR(MAX),
    restaurant_type VARCHAR(100)
    FOREIGN KEY (person_id) REFERENCES Person(id)
);