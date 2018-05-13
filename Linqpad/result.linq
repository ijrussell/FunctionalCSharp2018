<Query Kind="FSharpProgram" />

type Result<'TSuccess, 'TError> =
    | Ok of 'TSuccess
    | Error of 'TError
    
type Customer = {
    Id : int
    Name : string
}

type Exception =
    | NotFound of string
    | NotComplete of string

let getFile fileName : Result<Customer, Exception> =
    match fileName with
    | "" -> Error (NotFound "Filename was empty")
    | _ -> Ok ({ Id = 1; Name = fileName})
    
let x = getFile ""
x.Dump()
let y = getFile "TestPage.txt"
y.Dump()