#r "nuget: System.Text.Json, 5.0.2"
#r "nuget: FSharp.Data, 4.1.1"

#load "../src/OrcidAPI.fs"

open System.Text.Json
open System.Text.Json.Serialization
open FSharp.Data

type AuthenticationToken =
    {
        [<JsonPropertyName("access_token")>]
        AccessToken: string
        [<JsonPropertyName("token_type")>]
        TokenType: string
        [<JsonPropertyName("refresh_token")>]
        RefreshToken: string
        [<JsonPropertyName("access_token")>]
        EpiresIn: int64
        [<JsonPropertyName("access_token")>]
        scope: string
        [<JsonPropertyName("access_token")>]
        orcid: string option
    }

type AuthTokenRequestBody = 
    {
        [<JsonPropertyName("client_id")>]
        ClientId: string
        [<JsonPropertyName("client_secret")>]
        ClientSecret: string
        [<JsonPropertyName("grant_type")>]
        GrantType: string
        [<JsonPropertyName("scope")>]
        Scope: string
    }

let lol = 
    {
        ClientId = "APP-QUUT21ENY75O8TCJ"
        ClientSecret = "lolno"
        GrantType="authorization_code"
        Scope="/read-public"
    }

let body id secret = $"""client_id={id}&client_secret={secret}&grant_type=client_credentials&scope=/read-public"""


let t = 
    Http.Request(
        url = "https://orcid.org/oauth/token",
        httpMethod = "POST",
        headers = ["Accept", "application/json"],
        body =
            HttpRequestBody.TextRequest (JsonSerializer.Serialize<AuthTokenRequestBody>(lol))
    )

t.ResponseUrl