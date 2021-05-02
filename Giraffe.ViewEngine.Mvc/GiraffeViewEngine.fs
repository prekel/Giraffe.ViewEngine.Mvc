namespace Giraffe.ViewEngine.Mvc

open Microsoft.AspNetCore.Mvc.ViewEngines

type GiraffeViewEngine() =
    interface IViewEngine with
        member this.FindView(context, viewName, isMainPage) =
            printfn "\nFindView"
            printfn $"%A{context}\n%A{viewName}\n%A{isMainPage}\n"

            let view = GiraffeView()
            ViewEngineResult.Found(viewName, view)

        member this.GetView(executingFilePath, viewPath, isMainPage) =
            printfn "\nGetView"
            printfn $"%A{executingFilePath}\n%A{viewPath}\n%A{isMainPage}\n"

            ViewEngineResult.NotFound(viewPath, [])
