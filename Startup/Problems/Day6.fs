module Day6
open System.IO
open CharUtils
open Day4
open CharUtils

let getMostUsedChar input =
    getsortedCharCounts input|>Seq.head|> fst

let getLeastUsedChar input = 
    getsortedCharCounts input|>Seq.last|> fst
let solve = 
    let result =
        File.ReadAllLines "input6.txt"   
        |> Seq.transpose
        |> Seq.map getLeastUsedChar
        |> Seq.toList
    0