namespace Glutinum.Feliz.ReactTransitionGroup

open Feliz
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type Exports =

    static member inline Transition (properties : #obj list) =
        Interop.reactApi.createElement(import "Transition" "react-transition-group", createObj !!properties)

    static member inline CSSTransition (properties : #obj list) =
        Interop.reactApi.createElement(import "CSSTransition" "react-transition-group", createObj !!properties)

    static member inline TransitionGroup (properties : #obj list) =
        Interop.reactApi.createElement(import "TransitionGroup" "react-transition-group", createObj !!properties)

    static member inline SwitchTransition (properties : #obj list) =
        Interop.reactApi.createElement(import "SwitchTransition" "react-transition-group", createObj !!properties)

    static member inline config : Types.Config =
        import "config" "react-transition-group"
