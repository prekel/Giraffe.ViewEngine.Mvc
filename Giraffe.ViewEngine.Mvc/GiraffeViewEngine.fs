namespace Giraffe.ViewEngine.Mvc

open Microsoft.AspNetCore.Mvc.Controllers
open Microsoft.AspNetCore.Mvc.ViewEngines

type GiraffeViewEngine(viewProvider: IGiraffeViewProvider) =
    interface IViewEngine with
        member this.FindView(context, viewName, isMainPage) =
            let controllerName =
                (context.ActionDescriptor :?> ControllerActionDescriptor)
                    .ControllerName

            let view =
                GiraffeView(viewProvider.GetFunction(controllerName, viewName))

            ViewEngineResult.Found(viewName, view)

        member this.GetView(executingFilePath, viewPath, isMainPage) = ViewEngineResult.NotFound(viewPath, [])
