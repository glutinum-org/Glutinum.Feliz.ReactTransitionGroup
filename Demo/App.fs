module App

open Feliz
open Fable.Core.JsInterop
open Browser
open Glutinum.Feliz.ReactTransitionGroup
open Feliz.Bulma

open type Glutinum.Feliz.ReactTransitionGroup.Exports

// Workaround to have React-refresh working
// I need to open an issue on react-refresh to see if they can improve the detection
emitJsStatement () "import React from \"react\""

let duration = 300

// [<ReactComponent>]
// let FadeContent (state )

[<ReactComponent>]
let Fade () =
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

[<ReactComponent>]
let CSSTransitionDemo () =
    let showMessage, setShowMessage = React.useState false
    let showButton, setShowButton = React.useState true
    let nodeRef = React.useRef<Browser.Types.HTMLElement option>(None)

    Html.div [
        if showButton then
            Bulma.button.a [
                color.isPrimary
                prop.text "Show Message"
                prop.onClick (fun _ ->
                    setShowMessage true
                )
            ]

        CSSTransition [
            transition.nodeRef nodeRef
            transition.``in`` showMessage
            transition.appear true
            transition.timeout 300
            transition.unmountOnExit
            cssTransition.classNames "alert"
            transition.onEnter (fun _ ->
                setShowButton false
            )
            transition.onExited (fun () ->
                setShowButton true
            )

            transition.child (
                Bulma.message [
                    prop.ref nodeRef
                    prop.children [
                        Bulma.messageHeader [
                            Html.p "Message title"
                            Bulma.delete [
                                prop.onClick (fun _ ->
                                    setShowMessage false
                                )
                            ]
                        ]
                        Bulma.messageBody [
                            Html.p "Message body"
                            Bulma.button.a [
                                color.isPrimary
                                prop.text "Close"
                                prop.onClick (fun _ ->
                                    setShowMessage false
                                )
                            ]
                        ]
                    ]
                ]
            )
        ]
    ]

[<ReactComponent>]
let App () =
    Html.div [
        Fade ()
        CSSTransitionDemo ()
    ]
