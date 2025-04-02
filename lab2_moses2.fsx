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

// Example test cases
let activities = [
    BoardGame;
    Chill;
    Movie Regular;
    Movie IMAXWithSnacks;
    Restaurant Korean;
    LongDrive (100, 1.5)
]

// Print the budget for each activity
activities |> List.iter (fun activity ->
    printfn "%A costs %.2f CAD" activity (calculateBudget activity))
