module CharUtils

let getsortedCharCounts (input) =
    input 
    |> Seq.countBy id
    |> Seq.sort
    |> Seq.sortBy (snd >> (~-))