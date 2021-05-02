namespace Giraffe.ViewEngine.Mvc

open System
open System.Collections.Generic
open Microsoft.AspNetCore.Mvc.ModelBinding
open Microsoft.AspNetCore.Mvc.ViewFeatures

open Giraffe.ViewEngine

module GiraffeViewManualProvider =
    let cast (f: _ -> ViewDataDictionary -> ModelStateDictionary -> XmlNode) =
        Func<obj, ViewDataDictionary, ModelStateDictionary, XmlNode>(fun (o: obj) b c -> f (o :?> _) b c)

    let castF<'T> (f: Func<'T, ViewDataDictionary, ModelStateDictionary, XmlNode>) =
        Func<obj, ViewDataDictionary, ModelStateDictionary, XmlNode>(fun (o: obj) b c -> f.Invoke((o :?> _), b, c))

type GiraffeViewManualProvider
    (
        map: IDictionary<struct (string * string), Func<obj, ViewDataDictionary, ModelStateDictionary, XmlNode>>
    ) =

    interface IGiraffeViewProvider with
        member this.GetFunction(controllerName: string, viewName: string) =
            (fun a b c -> map.[controllerName, viewName].Invoke(a, b, c))
