namespace Glutinum.Feliz.ReactTransitionGroup

open Fable.Core
open Feliz

#nowarn "1182" // Don't warn about unused values

[<Global>]
type CSSTransitionClassNames [<ParamObject; Emit "$0">]
    (
        ?appear : string,
        ?appearActive : string,
        ?appearDone : string,
        ?enter : string,
        ?enterActive : string,
        ?enterDone : string,
        ?exit : string,
        ?exitActive : string,
        ?exitDone : string
    ) =

    member val appear : string option = jsNative
    member val appearActive : string option = jsNative
    member val appearDone : string option = jsNative
    member val enter : string option = jsNative
    member val enterActive : string option = jsNative
    member val enterDone : string option = jsNative
    member val exit : string option = jsNative
    member val exitActive : string option = jsNative
    member val exitDone : string option = jsNative

[<Erase>]
type cssTransition =

    /// <summary>
    /// The animation <c>classNames</c> applied to the component as it enters or exits.
    /// A single name can be provided and it will be suffixed for each stage: e.g.
    ///
    /// <c>classNames="fade"</c> applies <c>fade-enter</c>, <c>fade-enter-active</c>,
    /// <c>fade-exit</c>, <c>fade-exit-active</c>, <c>fade-appear</c>, and <c>fade-appear-active</c>.
    ///
    /// </summary>
    /// <param name="value"></param>
    static member inline classNames (value : string) =
        Interop.mkAttr "classNames" value

        /// <summary>
    /// The animation <c>classNames</c> applied to the component as it enters or exits.
    ///
    /// Each individual classNames can be specified independently like:
    ///
    /// <code lang="js">
    /// classNames={{
    ///    appear: 'my-appear',
    ///    appearActive: 'my-appear-active',
    ///    appearDone: 'my-appear-done',
    ///    enter: 'my-enter',
    ///    enterActive: 'my-enter-active',
    ///    enterDone: 'my-enter-done',
    ///    exit: 'my-exit',
    ///    exitActive: 'my-exit-active',
    ///    exitDone: 'my-exit-done'
    /// }}
    /// </code>
    /// </summary>
    /// <param name="value"></param>
    static member inline classNames (value : CSSTransitionClassNames) =
        Interop.mkAttr "classNames" value
