module App

open Feliz
open Fable.Core.JsInterop
open Browser
open Glutinum.Feliz.ReactTransitionGroup

open type Glutinum.Feliz.ReactTransitionGroup.Exports

// Workaround to have React-refresh working
// I need to open an issue on react-refresh to see if they can improve the detection
emitJsStatement () "import React from \"react\""

let duration = 300

// [<ReactComponent>]
// let FadeContent (state )

[<ReactComponent>]
let App () =
    let inProp, setInProp = React.useState false
    let nodeRef = React.useRef<Browser.Types.HTMLElement option>(None)

    Html.div [
        Transition [
            transition.``in`` inProp
            transition.nodeRef nodeRef
            transition.timeout duration
            transition.children (fun status ->
                Html.div [
                    prop.ref nodeRef
                    prop.style [
                        style.custom ("transition", $"opacity {duration}ms ease-in-out")
                        match status with
                        | TransitionStatus.Entered
                        | TransitionStatus.Entering -> style.opacity 1.
                        | TransitionStatus.Exiting
                        | TransitionStatus.Exited -> style.opacity 0.
                        | _ -> ()
                    ]

                    prop.text "I'm a fade transition"
                ]
            )
        ]

        Html.button [
            prop.text "Click to Enter"
            prop.onClick (fun _ -> setInProp (not inProp))
        ]

    ]
