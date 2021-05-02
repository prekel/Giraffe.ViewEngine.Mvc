namespace Giraffe.ViewEngine.Mvc

open Microsoft.AspNetCore.Mvc.ModelBinding
open Microsoft.AspNetCore.Mvc.ViewEngines
open Microsoft.AspNetCore.Mvc.ViewFeatures

open Giraffe.ViewEngine

type GiraffeView(renderFunc: obj -> ViewDataDictionary -> ModelStateDictionary -> XmlNode) =
    interface IView with
        member this.Path = ""

        member this.RenderAsync(context) =
            renderFunc context.ViewData.Model context.ViewData context.ModelState
            |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
            |> context.Writer.WriteAsync
