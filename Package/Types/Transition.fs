namespace Glutinum.Feliz.ReactTransitionGroup

open Fable.Core
open Feliz

[<Erase>]
type transition =

    static member inline nodeRef (ref : IRefValue<Browser.Types.HTMLElement option>) =
        Interop.mkAttr "nodeRef" ref


    static member ``in`` (value : bool) =
        Interop.mkAttr "in" value

    static member timeout (value : int) =
        Interop.mkAttr "timeout" value

    static member children (value : #seq<ReactElement>) =
        Interop.mkAttr "children" value

    static member children (func : TransitionStatus -> ReactElement) =
        Interop.mkAttr "children" func
