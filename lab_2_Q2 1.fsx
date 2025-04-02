// Define the Cuisine discriminated union
type Cuisine = 
    | Korean
    | Turkish

// Define the MovieType discriminated union
type MovieType = 
    | Regular
    | IMAX
    | DBOX
    | RegularWithSnacks
    | IMAXWithSnacks
    | DBOXWithSnacks

// Define the Activity discriminated union
type Activity =
    | BoardGame
    | Chill
    | Movie of MovieType
    | Restaurant of Cuisine
    | LongDrive of int * float  // (kilometers, fuel cost per km)

// Function to calculate the budget
let calculateBudget activity =
    match activity with
    | BoardGame -> 0.0
    | Chill -> 0.0
    | Movie Regular -> 12.0
    | Movie IMAX -> 17.0
    | Movie DBOX -> 20.0
    | Movie RegularWithSnacks -> 12.0 + 5.0
    | Movie IMAXWithSnacks -> 17.0 + 5.0
    | Movie DBOXWithSnacks -> 20.0 + 5.0
    | Restaurant Korean -> 70.0
    | Restaurant Turkish -> 65.0
    | LongDrive (km, fuelCostPerKm) -> float km * fuelCostPerKm

// Function to get user choice
let rec getUserChoice () =
    printfn "Choose an activity:"
    printfn "1. Board Game"
    printfn "2. Chill"
    printfn "3. Movie"
    printfn "4. Restaurant"
    printfn "5. Long Drive"
    printf "Enter your choice: "
    match System.Console.ReadLine() with
    | "1" -> BoardGame
    | "2" -> Chill
    | "3" -> 
        printfn "Choose Movie Type:"
        printfn "1. Regular"
        printfn "2. IMAX"
        printfn "3. DBOX"
        printfn "4. Regular with Snacks"
        printfn "5. IMAX with Snacks"
        printfn "6. DBOX with Snacks"
        printf "Enter your choice: "
        match System.Console.ReadLine() with
        | "1" -> Movie Regular
        | "2" -> Movie IMAX
        | "3" -> Movie DBOX
        | "4" -> Movie RegularWithSnacks
        | "5" -> Movie IMAXWithSnacks
        | "6" -> Movie DBOXWithSnacks
        | _ -> printfn "Invalid choice. Try again."; getUserChoice()
    | "4" -> 
        printfn "Choose Cuisine:"
        printfn "1. Korean"
        printfn "2. Turkish"
        printf "Enter your choice: "
        match System.Console.ReadLine() with
        | "1" -> Restaurant Korean
        | "2" -> Restaurant Turkish
        | _ -> printfn "Invalid choice. Try again."; getUserChoice()
    | "5" ->
        printf "Enter distance in km: "
        let km = int (System.Console.ReadLine())
        printf "Enter fuel cost per km: "
        let cost = float (System.Console.ReadLine())
        LongDrive (km, cost)
    | _ -> printfn "Invalid choice. Try again."; getUserChoice()

// Get user input and print the budget
let userActivity = getUserChoice()
printfn "%A costs %.2f CAD" userActivity (calculateBudget userActivity)