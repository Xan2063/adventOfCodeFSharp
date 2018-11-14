module Day7
open System.IO

let ContainsABBA input = 
    input
    |>Seq.windowed 4
    |>Seq.map (fun window -> match(window) with
    | ([|x;y;a;b|]) -> x=b&&y=a&&x<>y
    | _ -> false)
    |>Seq.reduce (||)
    
let GetABATuples (input:string)=
    input
    |>Seq.windowed 3
    |>Seq.filter (fun window -> match(window) with
    | ([|x1;y;x2;|]) -> x1=x2&&x1<>y
    | _ -> false)
    |>Seq.map (fun elem-> elem.[0..1] )
    |>Seq.toList


let CheckForAllBAB  ABATuples (input:string) =
    
    let pairs=
        input
        |>Seq.windowed 3
        |>Seq.allPairs ABATuples
        |>Seq.toList

    pairs
    |> Seq.map(fun (ABATuple,window)-> 
    match(ABATuple) with
    | ([|a;b;|]) -> 
    match(window)with
    | ([|x1;y;x2;|]) when x1=b && y=a-> x1=x2&&x1<>y
    | _ -> false
    )
    |>Seq.reduce (||)

let CheckTLS (input:string) =
    let sections = input.Split('[', ']')
    let outsidebracketSecion = [0..2..sections.Length-1]|>Seq.map(fun index->sections.[index])
    let bracketsection = [1..2..sections.Length-1]|>Seq.map(fun idx->sections.[idx])
    outsidebracketSecion |> Seq.exists ContainsABBA &&
    bracketsection |> Seq.forall (not <<ContainsABBA)


let CheckSSL (input:string) =
    let sections = input.Split('[', ']')
    let outsidebracketSecion = [0..2..sections.Length-1]|>Seq.map(fun index->sections.[index])
    let bracketsection = [1..2..sections.Length-1]|>Seq.map(fun idx->sections.[idx])
    let tuples = outsidebracketSecion|>Seq.map GetABATuples|>Seq.concat|>Seq.distinct|>Seq.toArray
    match(tuples)with
    |[||]->false
    |_ -> bracketsection|>Seq.map (CheckForAllBAB tuples)|>Seq.reduce (||)

let solve = 
    let result =
        File.ReadAllLines "input7.txt"
        |> Seq.filter CheckTLS
        |> Seq.toList
    result.Length
    let result2 =
        File.ReadAllLines "input7.txt"
        |> Seq.filter CheckSSL
        |> Seq.toList
    result.Length