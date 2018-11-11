
module Day3
open System.IO
open System

let convertToTriangle (elements:seq<string>) = 
    elements
    |> Seq.map (fun text ->text.Trim() )
    |> Seq.map int

let IsLargestLargerThanOthers elements =
    let sortedelements =  elements|> Seq.sort |>Seq.toArray
    match(sortedelements) with
    | sortedelements when sortedelements.[2] < (sortedelements.[0] + sortedelements.[1]) -> true 
    | _ -> false
    // if sortedelements.[2] >= sortedelements.[0] + sortedelements.[1] then true else false

let ReadFile path =
    let triangles = File.ReadAllLines path |> Seq.map (fun text->text.Split(' ',StringSplitOptions.RemoveEmptyEntries)) |> Seq.transpose |> Seq.concat|> Seq.toArray

    
    
    triangles
    |> Seq.chunkBySize 3
    |> Seq.map convertToTriangle
    |> Seq.map IsLargestLargerThanOthers
    |> Seq.filter (fun x->x=true)
    |> Seq.length

    // |> Seq.map (fun elems->Seq.map elem)


let SolveDay3 =
    let input = ReadFile "input3.txt"

    0

