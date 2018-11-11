module Day7
open System.IO
open System.Text.RegularExpressions

let FilterTextInBrackets (input:string) =
    let regex = new Regex(@"\[[^]]*\]")
    regex.Replace(input, "")
    
    // let result = Regex.Match (input, @"\[[^]]*\]")
    // result.Value

let removeBracketElements position (items:seq<string>) = 
    items|>Seq.filter (fun _-> position%2=0)

let solve = 
    let result =
        File.ReadAllLines "input7.txt"
        |> Seq.take 10
        |> Seq.map (fun text -> text.Split('[',']'))
        |> Seq.mapi removeBracketElements
        |> Seq.map Seq.toList
        |> Seq.toList
    0