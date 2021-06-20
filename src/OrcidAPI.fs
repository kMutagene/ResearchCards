module OrcidAPI

open FSharp.Data
open System.Text.Json

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

    type Authentication =
        {
            "access_token":"4bed1e13-7792-4129-9f07-aaf7b88ba88f",
            "token_type":"bearer",
            "refresh_token":"2d76d8d0-6fd6-426b-a017-61e0ceda0ad2",
            "expires_in":631138518,
            "scope":"/read-public",
            "orcid":null}
        }

module Requests =
    
    let getAccessToken = raise new System.NotImplementedException()