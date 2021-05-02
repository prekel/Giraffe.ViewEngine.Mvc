namespace Giraffe.ViewEngine.Mvc.Sample

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting

open Giraffe.ViewEngine.Mvc
open Giraffe.ViewEngine.Mvc.Sample.Views
open GiraffeViewManualProvider

type Startup private () =

    new(configuration: IConfiguration) as this =
        Startup()
        then this.Configuration <- configuration

    member this.ConfigureServices(services: IServiceCollection) =
        services.AddSingleton<IGiraffeViewProvider>(
            GiraffeViewManualProvider(
                dict [ ("Home", "Index"), cast Home.Index
                       ("Home", "Privacy"), cast Home.Privacy
                       ("Home", "Error"), cast Home.Error ]
            )
        )
        |> ignore

        services.AddMvc().AddGiraffeView() |> ignore

    member this.Configure(app: IApplicationBuilder, env: IWebHostEnvironment) =

        if (env.IsDevelopment()) then
            app.UseDeveloperExceptionPage() |> ignore
        else
            app.UseExceptionHandler("/Home/Error") |> ignore
            app.UseHsts() |> ignore

        app.UseHttpsRedirection() |> ignore
        app.UseStaticFiles() |> ignore

        app.UseRouting() |> ignore

        app.UseEndpoints
            (fun endpoints ->
                endpoints.MapControllerRoute(name = "default", pattern = "{controller=Home}/{action=Index}/{id?}")
                |> ignore)
        |> ignore

    member val Configuration: IConfiguration = null with get, set
