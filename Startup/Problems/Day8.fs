module Day8


let rotatLine (line:seq<char>) stepsToRotate = 
    let chars = line|> Seq.toList
    Seq.permute (fun index -> (index + stepsToRotate) % chars.Length) chars

let rotateColumn (matrix:seq<seq<char>>) stepsToRotate columnNumber = 
    matrix|> Seq.transpose |> Seq.mapi (fun idx column->
    match(idx) with
    | columnNumber -> rotatLine column stepsToRotate
    | _ -> column )
    |> Seq.transpose
    
    
let solve =
    //File.
    0