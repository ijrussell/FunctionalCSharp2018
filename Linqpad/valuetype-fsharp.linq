<Query Kind="FSharpProgram" />

type Currency =
    | GBP
    | USD
    | EUR
    
let gbp = GBP
let usd = USD
let unknown = GBP

(gbp = usd).Dump()
(gbp = unknown).Dump()
(unknown = usd).Dump()
