namespace Giraffe.ViewEngine.Mvc

open System.Collections.Generic
open Microsoft.AspNetCore.Mvc.ModelBinding
open Microsoft.AspNetCore.Mvc.ViewFeatures

open Giraffe.ViewEngine

module GiraffeViewManualProvider =
    let cast (f: _ -> ViewDataDictionary -> ModelStateDictionary -> XmlNode) = (fun (o: obj) -> f (o :?> _))

type GiraffeViewManualProvider
    (
        map: IDictionary<string * string, obj -> ViewDataDictionary -> ModelStateDictionary -> XmlNode>
    ) =

    interface IGiraffeViewProvider with
        member this.GetFunction(controllerName: string, viewName: string) = map.[controllerName, viewName]
