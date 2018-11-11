module FileOpener
open System.IO

let ReadCommandsFromFile path = File.ReadAllLines path