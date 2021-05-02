namespace Giraffe.ViewEngine.Mvc

open System.Runtime.CompilerServices
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Options

[<Extension>]
type MvcViewFeaturesMvcBuilderExtensions =
    [<Extension>]
    static member AddGiraffeView(builder: IMvcBuilder) =
        builder.Services.AddTransient<IConfigureOptions<MvcViewOptions>, GiraffeMvcViewOptionsSetup>()
        |> ignore

        builder.Services.AddSingleton<GiraffeViewEngine>()
        |> ignore

        builder
