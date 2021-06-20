module OrcidAPI

open FSharp.Data
open System.Text.Json
open System.Text.Json.Serialization

module ResponseTypes =
 
    [<Literal>]
    let resolutionPath = (__SOURCE_DIRECTORY__ + "/data/schemas")

    type Common = 
        XmlProvider<Schema="common-3.0.xsd", 
                    EmbeddedResource="ResearchCards.App, ResearchCards.App.data.schemas.common-3.0.xsd",
                    ResolutionFolder = resolutionPath>

    type Error = 
        XmlProvider<Schema="error-3.0.xsd", 
                    EmbeddedResource="ResearchCards.App, ResearchCards.App.data.schemas.error-3.0.xsd",
                    ResolutionFolder = resolutionPath>

    type Work = 
        XmlProvider<Schema="work-3.0.xsd", 
                    EmbeddedResource="ResearchCards.App, ResearchCards.App.data.schemas.work-3.0.xsd",
                    ResolutionFolder = resolutionPath>

    type AuthenticationToken =
        {
            [<JsonPropertyName("access_token")>]
            AccessToken: string
            [<JsonPropertyName("token_type")>]
            TokenType: string
            [<JsonPropertyName("refresh_token")>]
            RefreshToken: string
            [<JsonPropertyName("expires_in")>]
            EpiresIn: int64
            [<JsonPropertyName("scope")>]
            scope: string
            [<JsonPropertyName("orcid")>]
            Orcid: string option
        }

module Requests =
    
    let getAccessToken clientId clientSecret : ResponseTypes.AuthenticationToken =

        Http.RequestString(
            url = "https://orcid.org/oauth/token",
            httpMethod = "POST",
            headers = [
                "Accept", "application/json"
                "Content-Type", HttpContentTypes.FormValues
            ],
            body = 
                HttpRequestBody.FormValues [
                    "client_id", clientId
                    "client_secret", clientSecret
                    "grant_type", "client_credentials"
                    "scope", "/read-public"
                ]
        )

        |> JsonSerializer.Deserialize<ResponseTypes.AuthenticationToken>