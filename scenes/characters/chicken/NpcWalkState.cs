using Godot;
using System;

public partial class NpcWalkState : NodeState
{

	[Export]
	public CharacterBody2D CharacterBody2D { get; set; }

	[Export]
	public AnimatedSprite2D AnimatedSprite2D { get; set; }



	public override void OnProcess(float delta) { }
	public override void OnPhysicsProcess(float delta) { }
	public override void OnNextTransitions() { }
	public override void OnEnter()
	{
		AnimatedSprite2D.Play("walk");
	}
	public override void OnExit()
	{
		AnimatedSprite2D.Stop();
	}
}
