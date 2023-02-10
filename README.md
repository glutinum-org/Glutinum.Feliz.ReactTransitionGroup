# Glutinum.Feliz.ReactTransitionGroup

This binding was used to show how to use Feliz with ReactTransitionGroup.

It is not published because, I don't have the time to complete it.
The problem is that the documentation of the npm package is neither clear or complete.

If someone want to complete it, I will be happy to publish it.

## Usage

```fsharp
open Glutinum.Feliz.ReactTransitionGroup
open Feliz.Bulma

open type Glutinum.Feliz.ReactTransitionGroup.Exports

let duration = 300

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
```
