<Query Kind="FSharpProgram" />

module Discount =
    type Year = int
    type [<Measure>] percent
    type Customer = Simple | Valuable | MostValuable

    type AccountStatus =
        | Registered of customer:Customer * since:Year
        | UnRegistered

    let customerDiscount = function
        | Simple -> 1<percent>
        | Valuable -> 3<percent>
        | MostValuable -> 5<percent>

    let yearsDiscount = function
        | years when years > 5 -> 5<percent>
        | years -> 1<percent> * years

    let accountDiscount = function
        | Registered(customer, years) -> customerDiscount customer, yearsDiscount years
        | UnRegistered -> 0<percent>, 0<percent>
        
    let asPercent p =
        decimal(p) / 100.0m

    let reducePriceBy discount price =
        price - price * (asPercent discount)

    let calculateDiscountPrice account price =
        let customerDiscount, yearsDiscount = accountDiscount account
        price
        |> reducePriceBy customerDiscount
        |> reducePriceBy yearsDiscount

open Discount

let tests =
    [
        calculateDiscountPrice (Registered(MostValuable, 1)) 100.0M
        calculateDiscountPrice (Registered(Valuable, 6)) 100.0M
        calculateDiscountPrice (Registered(Simple, 1)) 100.0M
        calculateDiscountPrice UnRegistered 100.0M
    ] = [94.05000M;92.15000M;98.01000M;100.0M]
    
tests.Dump()