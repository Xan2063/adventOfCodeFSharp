module Day2

open Grid
let SolveDay2 =
    let position = {X= 1; Y = 1;}

    // let a =  ['U'; 'D'; 'U';'D';'R';'D'] |>
    let execute = Seq.fold (fun acc elem -> InferDirection elem acc) position >> GetEntry

    let command = 
        FileOpener.ReadCommandsFromFile "Input.txt"
        |> Seq.fold (fun acc elem -> acc+execute elem ) ""
    command
