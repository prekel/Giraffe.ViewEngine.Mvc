namespace Giraffe.ViewEngine.Mvc

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Options

type GiraffeMvcViewOptionsSetup(giraffeViewEngine: GiraffeViewEngine) =
    interface IConfigureOptions<MvcViewOptions> with
        member this.Configure(options) =
            options.ViewEngines.Add(giraffeViewEngine)
