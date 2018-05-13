<Query Kind="FSharpProgram" />

type Currency = Currency of symbol:string * exchangeRate:decimal

let usd = Currency ("USD", 0.8m)
let usd2 = Currency ("USD", 0.8m)
let gbp = Currency ("GBP", 1.0m)

(usd = usd2).Dump()
(usd = gbp).Dump()

type CustomerName = {
    FirstName: string
    MiddleName: string option
    LastName: string
}

type Customer = {
    Id: int
    CustomerName: CustomerName
}

let customer = { Id = 1; CustomerName = { FirstName = "Ian"; MiddleName = None; LastName = "Russell"}}

customer.Dump()

let customer2 = { customer with CustomerName = { FirstName = "Louise"; MiddleName = Some "Amanda"; LastName = "Russell"}}

customer2.Dump()

let getMiddleName value =
    match value with
    | Some n -> n
    | None -> "Not known"
    
let mn = getMiddleName customer2.CustomerName.MiddleName
mn.Dump()
let mn2 = getMiddleName customer.CustomerName.MiddleName
mn2.Dump()

let setMiddleName (value:string) =
    match value with
    | null -> "Is null" // None
    | _ -> "Is not null" // Some value
    
let mn3 = setMiddleName null

mn3.Dump()