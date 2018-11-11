module Day5
open System.Security.Cryptography
open System
let ByteToHex bytes = 
    bytes 
    |> Array.map (fun (x : byte) -> System.String.Format("{0:X2}", x))
    |> String.concat System.String.Empty
let createHash (text:string) = 
    
    use md5 = MD5.Create()
    let result =
        text
            |> System.Text.Encoding.ASCII.GetBytes
            |> md5.ComputeHash
            |> ByteToHex
    result
    // 

let test = createHash "abc3231929"

let prependSeed (index:int) =
    "cxdnnyjw" + string index


let Has5LeadingZeroes (hash:string) =
    hash.StartsWith "00000"
let inline charToInt c = int c - int '0'

let FilterPositions (position, _,_) =
    let positionAsInt = charToInt position
    match(positionAsInt) with
    | value when value >= 0 && value<8 -> true
    |_ -> false 

let solve = 
    let result = 
        Seq.initInfinite id
        |> Seq.map prependSeed
        |> Seq.map createHash
        |> Seq.filter Has5LeadingZeroes
        |> Seq.map (fun item-> (Seq.item 5 item, Seq.item 6 item,item))
        |> Seq.filter FilterPositions
        |> Seq.distinctBy (fun (position,_,_)->position)
        |> Seq.take 8
        |> Seq.sort
        |> Seq.toList


    0
