namespace Giraffe.ViewEngine.Mvc

open System.Threading.Tasks
open Giraffe.ViewEngine
open Microsoft.AspNetCore.Mvc.ViewEngines
open Giraffe.ViewEngine.Mvc.Sample.Views

type GiraffeView(renderFunc: obj -> XmlNode) =
    interface IView with
        member this.Path = "path"

        member this.RenderAsync(context) =
            async {
                let renderData =
                    { RenderData.Model = context.ViewData.Model
                      ViewData = context.ViewData
                      ModelState = context.ModelState }

                let index = renderFunc renderData

                let html =
                    Giraffe.ViewEngine.RenderView.AsString.htmlDocument index

                return! context.Writer.WriteAsync(html) |> Async.AwaitTask
            }
            |> Async.StartAsTask
            :> Task
