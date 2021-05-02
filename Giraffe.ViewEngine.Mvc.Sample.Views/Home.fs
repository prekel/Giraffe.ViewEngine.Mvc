namespace Giraffe.ViewEngine.Mvc.Sample.Views

open Giraffe.ViewEngine

type Home() = 
    let Index _ = p [] [ str "Index" ]

    let Privacy _ = p [] [ str "Privacy" ]

    let Error _ = p [] [ str "Error" ]

module Home =
    let Index (q :int) = p [] [ str "Index" ]