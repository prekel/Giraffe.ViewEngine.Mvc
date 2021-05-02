namespace Giraffe.ViewEngine.Mvc

open Giraffe.ViewEngine

type IGiraffeViewProvider =
    abstract GetFunction : controllerName: string * viewName: string -> (obj -> XmlNode)
