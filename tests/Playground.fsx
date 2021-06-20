#r "nuget: System.Text.Json, 5.0.2"
#r "nuget: FSharp.Data, 4.1.1"

#load "../src/OrcidAPI.fs"
open OrcidAPI

open System.Text.Json
open System.Text.Json.Serialization
open FSharp.Data

Requests.getAccessToken "APP-QUUT21ENY75O8TCJ" "lolno"
