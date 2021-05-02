namespace Giraffe.ViewEngine.Mvc.Sample.Views

open Giraffe.ViewEngine
open Microsoft.AspNetCore.Mvc.Rendering
open Microsoft.AspNetCore.Mvc.Rendering
open Microsoft.AspNetCore.Mvc.ViewFeatures
open Microsoft.AspNetCore.Mvc.ModelBinding

open Giraffe.ViewEngine.Mvc.Sample.Models

type RenderData<'Model> =
    { Model: 'Model
      ViewData: ViewDataDictionary
      ModelState: ModelStateDictionary }

module Home =
    let Index (data: RenderData<obj>) =
        div [] [
            p [] [ str (string data.Model) ]
            p [] [ str "Index" ]
        ]

    let Privacy (data: RenderData<obj>) =
        div [] [
            p [] [ str (string data.Model) ]
            p [] [ str "Privacy" ]
        ]

    let Error (data: RenderData<ErrorViewModel>) =
        div [] [
            p [] [
                str (string data.Model.RequestId)
            ]
            p [] [ str "Error" ]
        ]
