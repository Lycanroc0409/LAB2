open System
// PART-A Define the records
type Coach = { Name: string; FormerPlayer: bool }
type Stats = { Wins: int64; Losses: int64 }
type Team = { Name: string; Coach: Coach; Stats: Stats }

// PART-B Create a list of 5 teams
let teams = [
    { Name = "Atlanta Hawks"; Coach = { Name = "Quin Snyder"; FormerPlayer = false }; Stats = { Wins = 2927; Losses = 3010 } }
    { Name = "Boston Celtics"; Coach = { Name = "Joe Mazzulla"; FormerPlayer = false }; Stats = { Wins = 3634; Losses = 2480 } }
    { Name = "Brooklyn Nets"; Coach = { Name = "Jordi Fernandez"; FormerPlayer = false }; Stats = { Wins = 1654; Losses = 2214 } }
    { Name = "Charlotte Hornets"; Coach = { Name = "Charles Lee"; FormerPlayer = false }; Stats = { Wins = 1174; Losses = 1539 } }
    { Name = "Chicago Bulls"; Coach = { Name = "Billy Donovan"; FormerPlayer = false }; Stats = { Wins = 2383; Losses = 2297 } }
]

// Print all teams
printfn "PART-B All Teams:"
teams |> List.iter (fun team -> printfn "%s - Wins: %d, Losses: %d" team.Name team.Stats.Wins team.Stats.Losses)

printfn "\nFiltering successful teams...\n"

// PART-C Filtering successful teams
let successfulTeams = teams |> List.filter (fun team -> team.Stats.Wins > team.Stats.Losses)

// PART-D Mapping to calculate success percentage
let successPercentages = 
    teams 
    |> List.map (fun team -> (team.Name, float team.Stats.Wins / float (team.Stats.Wins + team.Stats.Losses) * 100.0))

// Print successful teams and their success percentages
printfn "PART-C Successful Teams:" 
successfulTeams |> List.iter (fun team -> printfn "%s" team.Name)

printfn "\nPART-D Success Percentages:" 
successPercentages |> List.iter (fun (name, percentage) -> printfn "%s: %.2f%%" name percentage)




