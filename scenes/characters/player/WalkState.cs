using Godot;
using System;

public partial class WalkState : NodeState
{
	[Export]
	public Player Player { get; set; }

	[Export]
	public AnimatedSprite2D AnimatedSprite2D { get; set; }

	[Export]
	public int Speed { get; set; } = 50;

	private Vector2 Direction = Vector2.Zero;

	public override void OnProcess(float delta)
	{
		// Early exit if required components are missing
		if (Player == null || AnimatedSprite2D == null)
		{
			//GD.PrintErr("WalkState: Player or AnimatedSprite2D is not assigned!");
			return;
		}

		Direction = GameInputEvents.MovementInput();

		if (Direction == Vector2.Up)
			AnimatedSprite2D.Play("walk_back");
		else if (Direction == Vector2.Right)
			AnimatedSprite2D.Play("walk_right");
		else if (Direction == Vector2.Down)
			AnimatedSprite2D.Play("walk_front");
		else if (Direction == Vector2.Left)
			AnimatedSprite2D.Play("walk_left");
		else
			AnimatedSprite2D.Play("walk_front");

		if (Direction != Vector2.Zero)
		{
			Player.PlayerDirection = Direction;
		}

		Player.Velocity = Direction * Speed;
		Player.MoveAndSlide();
	}
	public override void OnPhysicsProcess(float delta) { }

	public override void OnNextTransitions()
	{
		if (!GameInputEvents.IsMovementInput()) // No movement input
		{
			EmitSignal(SignalName.Transition, "Idle");
		}
	}
	public override void OnEnter() { }
	public override void OnExit()
	{
		AnimatedSprite2D.Stop();
	}
}
