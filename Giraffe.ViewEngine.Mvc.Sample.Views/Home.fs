namespace Giraffe.ViewEngine.Mvc.Sample.Views

open Microsoft.AspNetCore.Mvc.ViewFeatures
open Microsoft.AspNetCore.Mvc.ModelBinding

open Giraffe.ViewEngine

open Giraffe.ViewEngine.Mvc.Sample.Models

module Home =
    let Index (model: obj) (viewData: ViewDataDictionary) (modelState: ModelStateDictionary) =
        div [] [
            p [] [ str (string model) ]
            p [] [ str "Index" ]
        ]

    let Privacy (model: obj) (viewData: ViewDataDictionary) (modelState: ModelStateDictionary) =
        div [] [
            p [] [ str (string model) ]
            p [] [ str "Privacy" ]
        ]

    let Error model (viewData: ViewDataDictionary) (modelState: ModelStateDictionary) =
        div [] [
            p [] [ str (string model.RequestId) ]
            p [] [ str (string model.ShowRequestId) ]
            p [] [ str "Error" ]
        ]
