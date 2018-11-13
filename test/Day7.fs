module TestDay7
open Day7

open NUnit.Framework

[<TestFixture>]
type TestClass () =

    [<SetUp>]
    member this.Setup () =
        ()

    [<Test>]
    member this.Test1 () =
        let result = CheckTLS "abba[mnop]qrst"
        Assert.IsTrue result
    [<Test>]
    member this.Test2 () =
        let result = CheckTLS "abcd[bddb]xyyx"
        Assert.IsFalse result
    [<Test>]
    member this.Test3 () =
        let result = CheckTLS "aaaa[qwer]tyui"
        Assert.IsFalse result
    [<Test>]
    member this.Test4 () =
        let result = CheckTLS "ioxxoj[asdfgh]zxcvb"
        Assert.IsTrue result

    [<Test>]
    member this.Test5 () =
        let result = CheckSSL "aba[bab]xyz"
        Assert.IsTrue result
    [<Test>]
    member this.Test6 () =
        let result = CheckSSL "xyx[xyx]xyx"
        Assert.IsFalse result
    [<Test>]
    member this.Test7 () =
        let result = CheckSSL "aaa[kek]eke"
        Assert.IsTrue result
    [<Test>]
    member this.Test8 () =
        let result = CheckSSL "zazbz[bzb]cdb"
        Assert.IsTrue result