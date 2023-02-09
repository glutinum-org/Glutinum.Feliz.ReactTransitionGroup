namespace Glutinum.Feliz.ReactTransitionGroup

open Feliz
open Fable.Core

type IReactResizeDetectorProperty =
    interface end

[<RequireQualifiedAccess>]
[<StringEnum>]
type TransitionStatus =
    | Entered
    | Entering
    | Exited
    | Exiting
    | Unmounted
