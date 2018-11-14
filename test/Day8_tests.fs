module Day8_tests
open Day8

open NUnit.Framework

[<TestFixture>]
type TestClass () =

    [<SetUp>]
    member this.Setup () =
        ()

    [<Test>]
    member this.Test1 () =
        let result = rotatLine "..##.." 1
        Assert.AreEqual("...##.",result) 

    [<Test>]
    member this.Test2 () =
        let result = rotatLine "..##" 2
        Assert.AreEqual("##..",result)


    [<Test>]
    member this.Test2 () =
        
        let result = rotateColumn [|"..##", "##..", "..##"|] |> 2
        Assert.AreEqual("##..",result)
