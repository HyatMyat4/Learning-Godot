using Godot;
using System;

public partial class WateringState : NodeState
{

	[Export]
	public Player Player { get; set; }

	[Export]
	public AnimatedSprite2D AnimatedSprite2D { get; set; }

	public override void OnProcess(float delta) { }
	public override void OnPhysicsProcess(float delta) { }
	public override void OnNextTransitions()
	{
		if (!AnimatedSprite2D.IsPlaying())
		{
			EmitSignal(SignalName.Transition, "idle");
		}
	}
	public override void OnEnter()
	{
		if (Player.PlayerDirection == Vector2.Up)
		{
			AnimatedSprite2D.Play("watering_back");
		}
		else if (Player.PlayerDirection == Vector2.Right)
		{
			AnimatedSprite2D.Play("watering_right");
		}
		else if (Player.PlayerDirection == Vector2.Down)
		{
			AnimatedSprite2D.Play("watering_front");
		}
		else if (Player.PlayerDirection == Vector2.Left)
		{
			AnimatedSprite2D.Play("watering_left");
		}
		else
		{
			AnimatedSprite2D.Play("watering_front");
		}
	}
	public override void OnExit()
	{
		AnimatedSprite2D.Stop();
	}
}
