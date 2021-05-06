##Overview
### Step 1
1. Create entity classes `Car`, `Manufacturer`
2. Create static Class `DataReader` 
    - Method: `IEnumerable<Car> GetAllCars()`
        * use `File.ReadAllLines` to open the file and get all its text as `string[]`
        * create a helper string extension method `Car ToCar(this string source)`
    - Method: `IEnumerable<Manufacturer> GetAllManufacturers()`
        * use `File.ReadAllLines` to open the file and get all its text as `string[]`
        * create a helper string extension method `Naufacturer ToManufacturer(this string source)`
### Step 2
1. In the main program create an endless loop that shows a menu and then reads the user choice
2. Collect user choice using `Console.Readline`
3. And then point to the proper function according that whatever the user has selected
    - Please use `switch case` to choose the proper function

### Step 3 - Option 1: List of all manufacturers
1. Present a list of all manufacturers sorted by the name

### Step 4 - Option 2: List of all vehicles of a specific manufacturer
1. Present a list of all manufacturers, only names and index, sorted by name
2. Ask the userto select manufacturer by index
3. Present a list of all cars of this manufacturer ordered by model name

### Step 5 - Option 3: Number of cars per MFG
1. Present a list of all Mfgs names
2. Next to each name, show the number of cars




