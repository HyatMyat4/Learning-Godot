using Godot;
using System;

public partial class NpcIdleState : NodeState
{
	[Export]
	public CharacterBody2D CharacterBody2D { get; set; }

	[Export]
	public AnimatedSprite2D AnimatedSprite2D { get; set; }

	[Export]
	public float IdleStateTimeInterval = 5.0f;

	private Timer idleStateTimer;
	private bool idleStateTimeout = false;

	public override void _Ready()
	{
		idleStateTimer = new Timer
		{
			WaitTime = IdleStateTimeInterval
		};

		idleStateTimer.Timeout += OnIdleStateTimeout;
		AddChild(idleStateTimer);
	}

	private void OnIdleStateTimeout()
	{
		idleStateTimeout = true;
	}

	public override void OnProcess(float delta)
	{
		// Equivalent to _on_process
	}

	public override void OnPhysicsProcess(float delta)
	{
		// Equivalent to _on_physics_process
	}

	public override void OnNextTransitions()
	{
		if (idleStateTimeout)
		{
			EmitSignal(SignalName.Transition, "NpcWalkState");
		}
	}

	public override void OnEnter()
	{
		AnimatedSprite2D.Play("idle");
		idleStateTimeout = false;
		idleStateTimer.Start();
	}

	public override void OnExit()
	{
		AnimatedSprite2D.Stop();
		idleStateTimer.Stop();
	}
}
