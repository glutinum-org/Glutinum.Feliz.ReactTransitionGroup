namespace Glutinum.Feliz.ReactTransitionGroup

open Fable.Core
open Feliz

[<Erase>]
type transition =

    /// <summary>
    /// Show the component; triggers the enter or exit states
    /// </summary>
    /// <param name="value"></param>
    static member inline ``in``(value: bool) = Interop.mkAttr "in" value

    /// <summary>
    /// By default the child component does not perform the enter transition when
    /// it first mounts, regardless of the value of <c>in</c>. If you want this
    /// behavior, set both <c>appear</c> and <c>in</c> to <c>true</c>.
    ///
    /// &gt; **Note**: there are no special appear states like <c>appearing</c>/<c>appeared</c>, this prop
    /// &gt; only adds an additional enter transition. However, in the
    /// &gt; <c>&lt;CSSTransition&gt;</c> component that first enter transition does result in
    /// &gt; additional <c>.appear-*</c> classes, that way you can choose to style it
    /// &gt; differently.
    /// </summary>
    /// <param name="value"></param>
    static member inline appear (value : bool) = Interop.mkAttr "appear" value

    /// <summary>
    /// Enable or disable enter transitions.
    /// </summary>
    /// <param name="value"></param>
    static member inline enter (value : bool) = Interop.mkAttr "enter" value

    /// <summary>
    /// Enable or disable exit transitions.
    /// </summary>
    /// <param name="value"></param>
    static member inline exit (value : bool) = Interop.mkAttr "exit" value

    /// <summary>
    /// By default the child component is mounted immediately along with the
    /// parent Transition component. If you want to "lazy mount" the component on
    /// the first <c>in={true}</c> you can set <c>mountOnEnter</c>. After the first enter
    /// transition the component will stay mounted, even on "exited", unless you
    /// also specify <c>unmountOnExit</c>.
    /// </summary>
    static member inline mountOnEnter = Interop.mkAttr "mountOnEnter" true

    /// <summary>
    /// By default the child component stays mounted after it reaches the
    /// 'exited' state. Set <c>unmountOnExit</c> if you'd prefer to unmount the
    /// component after it finishes exiting.
    /// </summary>
    static member inline unmountOnExit = Interop.mkAttr "unmountOnExit" true

    /// <summary>
    /// Callback fired before the "entering" status is applied. An extra
    /// parameter <c>isAppearing</c> is supplied to indicate if the enter stage is
    /// occurring on the initial mount
    /// </summary>
    static member inline onEnter(func: bool -> unit) = Interop.mkAttr "onEnter" func

    /// <summary>
    /// Callback fired before the "entering" status is applied. An extra
    /// parameter <c>isAppearing</c> is supplied to indicate if the enter stage is
    /// occurring on the initial mount
    /// </summary>
    static member inline onEnter(func: Browser.Types.HTMLElement -> bool -> unit) = Interop.mkAttr "onEnter" func

    /// <summary>
    /// Callback fired after the "entering" status is applied. An extra parameter
    /// isAppearing is supplied to indicate if the enter stage is occurring on
    /// the initial mount
    /// </summary>
    /// <param name="func"></param>
    static member inline onEntering(func: bool -> unit) = Interop.mkAttr "onEntering" func

    /// <summary>
    /// Callback fired after the "entering" status is applied. An extra parameter
    /// isAppearing is supplied to indicate if the enter stage is occurring on
    /// the initial mount
    /// </summary>
    /// <param name="func"></param>
    static member inline onEntering(func: Browser.Types.HTMLElement -> bool -> unit) = Interop.mkAttr "onEntering" func

    /// <summary>
    /// Callback fired after the "entered" status is applied. An extra parameter
    /// isAppearing is supplied to indicate if the enter stage is occurring on
    /// the initial mount
    /// </summary>
    /// <param name="func"></param>
    static member inline onEntered(func: bool -> unit) = Interop.mkAttr "onEntered" func

    /// <summary>
    /// Callback fired after the "entered" status is applied. An extra parameter
    /// isAppearing is supplied to indicate if the enter stage is occurring on
    /// the initial mount
    /// </summary>
    /// <param name="func"></param>
    static member inline onEntered(func: Browser.Types.HTMLElement -> bool -> unit) = Interop.mkAttr "onEntered" func

    /// <summary>
    /// Callback fired before the "exiting" status is applied.
    /// </summary>
    /// <param name="func"></param>
    static member inline onExit(func: unit -> unit) = Interop.mkAttr "onExit" func

    /// <summary>
    /// Callback fired before the "exiting" status is applied.
    /// </summary>
    /// <param name="func"></param>
    static member inline onExit(func: Browser.Types.HTMLElement -> unit) = Interop.mkAttr "onExit" func

    /// <summary>
    /// Callback fired after the "exiting" status is applied.
    /// </summary>
    /// <param name="func"></param>
    static member inline onExiting(func: unit -> unit) = Interop.mkAttr "onExiting" func

    /// <summary>
    /// Callback fired after the "exiting" status is applied.
    /// </summary>
    /// <param name="func"></param>
    static member inline onExiting(func: Browser.Types.HTMLElement -> unit) = Interop.mkAttr "onExiting" func

    /// <summary>
    /// Callback fired after the "exited" status is applied.
    /// </summary>
    /// <param name="func"></param>
    static member inline onExited(func: unit -> unit) = Interop.mkAttr "onExited" func

    /// <summary>
    /// Callback fired after the "exited" status is applied.
    /// </summary>
    /// <param name="func"></param>
    static member inline onExited(func: Browser.Types.HTMLElement -> unit) = Interop.mkAttr "onExited" func

    /// <summary>
    /// A function child can be used instead of a React element. This function is
    /// called with the current transition status ('entering', 'entered',
    /// 'exiting',  'exited', 'unmounted'), which can be used to apply context
    /// specific props to a component.
    /// <code lang="jsx">
    ///     &lt;Transition in={this.state.in} timeout={150}&gt;
    ///         {state => (
    ///             &lt;MyComponent className={`fade fade-${state}`} /&gt;
    ///         )}
    ///     &lt;/Transition&gt;
    /// </code>
    /// </summary>
    /// <param name="child"></param>
    static member inline child(child: ReactElement) =
        Interop.mkAttr "children" child

    /// <summary>
    /// A function child can be used instead of a React element. This function is
    /// called with the current transition status ('entering', 'entered',
    /// 'exiting',  'exited', 'unmounted'), which can be used to apply context
    /// specific props to a component.
    /// <code lang="jsx">
    ///     &lt;Transition in={this.state.in} timeout={150}&gt;
    ///         {state => (
    ///             &lt;MyComponent className={`fade fade-${state}`} /&gt;
    ///         )}
    ///     &lt;/Transition&gt;
    /// </code>
    /// </summary>
    /// <param name="func"></param>
    static member inline children(func: TransitionStatus -> ReactElement) = Interop.mkAttr "children" func

    /// <summary>
    /// A React reference to DOM element that need to transition: <see href="https://stackoverflow.com/a/51127130/4671932" />
    /// When <c>nodeRef</c> prop is used, node is not passed to callback functions (e.g. onEnter) because user already has direct access to the node.
    /// When changing <c>key</c> prop of <c>Transition</c> in a <c>TransitionGroup</c> a new <c>nodeRef</c> need to be provided to <c>Transition</c> with changed <c>key</c>
    /// prop (@see <see href="https://github.com/reactjs/react-transition-group/blob/master/test/Transition-test.js)." />
    /// </summary>
    /// <param name="ref"></param>
    static member inline nodeRef(ref: IRefValue<Browser.Types.HTMLElement option>) = Interop.mkAttr "nodeRef" ref

    /// <summary>
    /// The duration of the transition, in milliseconds. Required unless addEndListener is provided.
    ///
    /// You may specify a single timeout for all transitions:
    /// <code lang="js">
    ///    timeout={500}
    /// </code>
    /// or individually:
    /// <code lang="js">
    /// timeout={{
    ///   appear: 500,
    ///   enter: 300,
    ///   exit: 500,
    /// }}
    /// </code>
    /// - appear defaults to the value of <c>enter</c>
    /// - enter defaults to <c>0</c>
    /// - exit defaults to <c>0</c>
    /// </summary>
    /// <param name="value"></param>
    static member inline timeout(value: int) = Interop.mkAttr "timeout" value

    /// <summary>
    /// The duration of the transition, in milliseconds. Required unless addEndListener is provided.
    ///
    /// You may specify a single timeout for all transitions:
    /// <code lang="js">
    ///    timeout={500}
    /// </code>
    /// or individually:
    /// <code lang="js">
    /// timeout={{
    ///   appear: 500,
    ///   enter: 300,
    ///   exit: 500,
    /// }}
    /// </code>
    /// - appear defaults to the value of <c>enter</c>
    /// - enter defaults to <c>0</c>
    /// - exit defaults to <c>0</c>
    /// </summary>
    /// <param name="config"></param>
    static member inline timeout
        (config:
            {|
                appear: float option
                enter: float option
                exit: float option
            |})
        =
        Interop.mkAttr "timeout" config

    /// <summary>
    /// Add a custom transition end trigger. Called with the transitioning DOM
    /// node and a done callback. Allows for more fine grained transition end
    /// logic. Note: Timeouts are still used as a fallback if provided.
    /// </summary>
    /// <param name="func"></param>
    static member inline addEndListener(func: Browser.Types.HTMLElement option -> unit) = Interop.mkAttr "addEndListener" func
