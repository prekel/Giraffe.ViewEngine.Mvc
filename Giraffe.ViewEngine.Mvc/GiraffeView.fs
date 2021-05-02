namespace Giraffe.ViewEngine.Mvc

open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc.ViewEngines

type GiraffeView() =
    interface IView with
        member this.Path = "path"

        member this.RenderAsync(context) =
            async {
                return!
                    context.Writer.WriteAsync((this :> IView).Path)
                    |> Async.AwaitTask
            }
            |> Async.StartAsTask
            :> Task
