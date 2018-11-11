module Day4
open System.IO

let getsortedCharCounts (input) =
    input 
    |> Seq.filter ((<>)'-')
    |> Seq.countBy id
    |> Seq.sort
    |> Seq.sortBy (snd >> (~-))

let combineFirstFiveChars charCounts =
    charCounts |>Seq.take 5 |> Seq.map fst|>Seq.toArray |> System.String

let getFirstFiveChars = getsortedCharCounts >> combineFirstFiveChars 

    
let IsValidRoom (roomName:string, _, checksum)=
    let firstFiveChars = roomName |> getFirstFiveChars
    firstFiveChars = checksum


let input =
    File.ReadAllLines("Input4.txt")
    |> Array.map (fun line ->
        let [| rest; checksum|] =
            line.Split('[', ']')|>Array.take 2

        let lastDash = rest.LastIndexOf('-')
        let sectorId = rest.Substring(lastDash+1) |> int
        let encryptedName = rest.Substring(0, lastDash)
        encryptedName, sectorId, checksum)



let let2nat (letter : char) = int letter - int 'a'

let nat2let number = char(number + int 'a')

let rotate ordinal rotationnumber = 
    (ordinal + rotationnumber)%26

let rot rotationnumber = let2nat  >> rotate rotationnumber >> nat2let

let test = rot 2 'z' 
let rotateChar number inputchar=
    match(inputchar) with
    |'-' -> ' '
    | char -> rot number char

let decryptRooms (encryptedName:string, sectorId:int, _) =
    let rotatbyId = rotateChar sectorId
    let roomname = 
        encryptedName 
        |> Seq.map rotatbyId 
        |> Seq.toArray
        |> System.String
    roomname, sectorId

let GetSectorId (_,ID,_)=
    ID

let containsPole (name:string, _) =
    name.Contains("pole")
    

let SolveDay4 = 
    let test = 
        input 
        // |>Array.take 10
        |> Seq.filter IsValidRoom
        |> Seq.sumBy GetSectorId

    let test2 = 
        input
        |> Seq.filter IsValidRoom
        |> Seq.map decryptRooms 
        |> Seq.filter containsPole
        |> Seq.toList
    0
