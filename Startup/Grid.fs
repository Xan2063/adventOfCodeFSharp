module Grid

type Row = {
    Elements : string list
}

   type Vector2 = {
       X: int
       Y: int
   }

type Grid = 
   { 
       Dimensions : Vector2
       Rows : Row list
   }

let (<&>) f g = (fun x -> f x && g x)

let GetPlayground =     
    let grid = {Rows = [{Elements = ["X";"X";"1";"X";"X"]};
                        {Elements = ["X";"2";"3";"4";"X"]};
                        {Elements = ["5";"6";"7";"8";"9"]};
                        {Elements = ["X";"A";"B";"C";"X"]};
                        {Elements = ["X";"X";"D";"X";"X"]};]
    
                Dimensions = {X=5; Y=5}}

    grid

// let GetPlayground =     
//     let firstRow  = {Elements = ["1";"2";"3"]}
//     let secondRow  = {Elements = ["4";"5";"6"]}
//     let thirdRow  = {Elements = ["7";"8";"9"]}
//     let grid = {Rows = [firstRow;secondRow; thirdRow]; Dimensions = {X=3; Y=3}}
//     grid

let GetGridEntry (grid :Grid) position =
    let row = List.item position.Y grid.Rows
    List.item position.X row.Elements

let GetEntry = GetGridEntry <| GetPlayground


let CheckDimensions dimensions position =
     position.X < dimensions.X && position.X >= 0 &&
     position.Y <dimensions.Y && position.Y >=0

let  CheckGridDimensions = CheckDimensions <|GetPlayground.Dimensions  

let CheckLetterValid char =
    match(char) with
    | "X" -> false
    | _ ->true

let CheckEntryValid = GetEntry >> CheckLetterValid 
let ValidateNewPosition = CheckGridDimensions <&> CheckEntryValid

let CheckPosition (position, newposition)  = 
    match(newposition) with
    | newposition when ValidateNewPosition newposition ->newposition
    | _ -> position

let calculatePositionUp currentPosition = 
    let newposition = {X= currentPosition.X; Y= currentPosition.Y-1}
    currentPosition, newposition
let calculatePositionDown currentPosition = 
    let newposition = {X= currentPosition.X; Y= currentPosition.Y+1}
    currentPosition, newposition
let calculatePositionRight currentPosition = 
    let newposition = {X= currentPosition.X+1; Y= currentPosition.Y}
    currentPosition, newposition
let calculatePositionLeft currentPosition = 
    let newposition = {X= currentPosition.X-1; Y= currentPosition.Y}
    currentPosition, newposition

let InferDirection directionLetter = 
    let operation = 
        match(directionLetter) with
            | 'U' -> calculatePositionUp
            | 'D' -> calculatePositionDown
            | 'L' -> calculatePositionLeft
            | 'R' -> calculatePositionRight
    operation >> CheckPosition
