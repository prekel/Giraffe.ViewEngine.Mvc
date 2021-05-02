namespace Giraffe.ViewEngine.Mvc

open Microsoft.AspNetCore.Mvc.ModelBinding
open Microsoft.AspNetCore.Mvc.ViewFeatures

open Giraffe.ViewEngine

type IGiraffeViewProvider =
    abstract GetFunction :
        controllerName: string * viewName: string ->
        (obj -> ViewDataDictionary -> ModelStateDictionary -> XmlNode)
