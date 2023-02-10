namespace Glutinum.Feliz.ReactTransitionGroup

open Feliz
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type Exports =

    /// <summary>
    /// The Transition component lets you describe a transition from one component
    /// state to another _over time_ with a simple declarative API. Most commonly
    /// It's used to animate the mounting and unmounting of Component, but can also
    /// be used to describe in-place transition states as well.
    ///
    /// By default the <c>Transition</c> component does not alter the behavior of the
    /// component it renders, it only tracks "enter" and "exit" states for the components.
    /// It's up to you to give meaning and effect to those states. For example we can
    /// add styles to a component when it enters or exits:
    ///
    /// <code lang="jsx">
    /// import Transition from 'react-transition-group/Transition';
    ///
    /// const duration = 300;
    ///
    /// const defaultStyle = {
    ///    transition: `opacity ${duration}ms ease-in-out`,
    ///    opacity: 0,
    /// }
    ///
    /// const transitionStyles = {
    ///    entering: { opacity: 1 },
    ///    entered:  { opacity: 1 },
    /// };
    ///
    /// const Fade = ({ in: inProp }) =&gt; (
    ///    &lt;Transition in={inProp} timeout={duration}&gt;
    ///      {(state) =&gt; (
    ///        &lt;div style={{
    ///          ...defaultStyle,
    ///          ...transitionStyles[state]
    ///        }}&gt;
    ///          I'm A fade Transition!
    ///        &lt;/div&gt;
    ///      )}
    ///    &lt;/Transition&gt;
    /// );
    /// </code>
    /// </summary>
    /// <param name="properties"></param>
    static member inline Transition(properties: IReactProperty list) =
        Interop.reactApi.createElement (import "Transition" "react-transition-group", createObj !!properties)

    static member inline CSSTransition(properties: IReactProperty list) =
        Interop.reactApi.createElement (import "CSSTransition" "react-transition-group", createObj !!properties)

    static member inline TransitionGroup(properties: IReactProperty list) =
        Interop.reactApi.createElement (import "TransitionGroup" "react-transition-group", createObj !!properties)

    static member inline SwitchTransition(properties: IReactProperty list) =
        Interop.reactApi.createElement (import "SwitchTransition" "react-transition-group", createObj !!properties)

    static member inline config: Types.Config = import "config" "react-transition-group"
