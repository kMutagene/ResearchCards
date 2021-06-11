module OrcidAPI

open FSharp.Data

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
