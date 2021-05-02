namespace Giraffe.ViewEngine.Mvc

open System.Collections.Generic
open Giraffe.ViewEngine

type GiraffeViewManualProvider(map: IDictionary<string * string, obj -> XmlNode>) =
    let map = map |> Seq.map (|KeyValue|) |> Map.ofSeq

    interface IGiraffeViewProvider with
        member this.GetFunction(controllerName: string, viewName: string) =
            map |> Map.find (controllerName, viewName)
