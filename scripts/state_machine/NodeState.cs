using Godot;
using System;

public partial class NodeState : Node
{
	[Signal]
	public delegate void TransitionEventHandler(string newStateName);


	public virtual void OnProcess(float delta) { }
	public virtual void OnPhysicsProcess(float delta) { }
	public virtual void OnNextTransitions() { }
	public virtual void OnEnter() { }
	public virtual void OnExit() { }
}
