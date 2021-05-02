namespace Giraffe.ViewEngine.Mvc.Sample

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Giraffe.ViewEngine
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.HttpsPolicy
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.DependencyInjection
open Giraffe.ViewEngine.Mvc


type Startup private () =
    let funToObj (f: _ -> XmlNode) = (fun (o: obj) -> f (o :?> _))

    new(configuration: IConfiguration) as this =
        Startup()
        then this.Configuration <- configuration

    member this.ConfigureServices(services: IServiceCollection) =
        services.AddSingleton<IGiraffeViewProvider>(
            GiraffeViewManualProvider(
                dict [ ("Home", "Index"), funToObj Giraffe.ViewEngine.Mvc.Sample.Views.Home.Index
                       ("Home", "Privacy"), funToObj Giraffe.ViewEngine.Mvc.Sample.Views.Home.Privacy
                       ("Home", "Error"), funToObj Giraffe.ViewEngine.Mvc.Sample.Views.Home.Error ]
            )
        )
        |> ignore

        services.AddMvc().AddGiraffeView() |> ignore

    member this.Configure(app: IApplicationBuilder, env: IWebHostEnvironment) =

        if (env.IsDevelopment()) then
            app.UseDeveloperExceptionPage() |> ignore
        else
            app.UseExceptionHandler("/Home/Error") |> ignore
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts() |> ignore

        app.UseHttpsRedirection() |> ignore
        app.UseStaticFiles() |> ignore

        app.UseRouting() |> ignore

        //app.UseAuthorization() |> ignore

        app.UseEndpoints
            (fun endpoints ->
                endpoints.MapControllerRoute(name = "default", pattern = "{controller=Home}/{action=Index}/{id?}")
                |> ignore

                //endpoints.MapRazorPages() |> ignore
                )
        |> ignore

    member val Configuration: IConfiguration = null with get, set
