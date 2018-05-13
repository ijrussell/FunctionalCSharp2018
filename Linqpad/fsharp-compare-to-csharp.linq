<Query Kind="FSharpProgram" />

// Discriminated Union/Pattern Matching

type Discount =
    | NoDiscount
    | HasDiscount of decimal

let getDiscount discount =
    match discount with
    | HasDiscount amount -> (true, amount)
    | NoDiscount -> (false, 0m)
    
let setDiscount (status, amount) =
    match status, amount with
    | true, amount -> HasDiscount amount
    | false, _ -> NoDiscount
    
let test (hasDiscount, amount) = 
    setDiscount (hasDiscount, amount)
    |> getDiscount 
    
let run = test (true, 25m)
run.Dump()
let (hasDiscount, discount) = test (true, 25m)
hasDiscount.Dump("hasDiscount")
discount.Dump("discount")

let run2 = test (false, 25m)
run2.Dump();