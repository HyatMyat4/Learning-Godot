using Godot;
using System;

public partial class ChoppingState : NodeState
{

	[Export]
	public Player Player { get; set; }

	[Export]
	public AnimatedSprite2D AnimatedSprite2D { get; set; }
	[Export]
	public CollisionShape2D HitComponentCollisionShape { get; set; }


	public override void _Ready()
	{
		HitComponentCollisionShape.Disabled = true;
		HitComponentCollisionShape.Position = new Vector2(0, 0);
	}
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
			AnimatedSprite2D.Play("chopping_back");
			HitComponentCollisionShape.Position = new Vector2(0, -20);
		}
		else if (Player.PlayerDirection == Vector2.Right)
		{
			AnimatedSprite2D.Play("chopping_right");
			HitComponentCollisionShape.Position = new Vector2(9, 0);

		}
		else if (Player.PlayerDirection == Vector2.Down)
		{
			AnimatedSprite2D.Play("chopping_front");
			HitComponentCollisionShape.Position = new Vector2(0, 2);
		}
		else if (Player.PlayerDirection == Vector2.Left)
		{
			AnimatedSprite2D.Play("chopping_left");
			HitComponentCollisionShape.Position = new Vector2(-9, 0);
		}
		else
		{
			AnimatedSprite2D.Play("chopping_front");
		}

		HitComponentCollisionShape.Disabled = false;

	}
	public override void OnExit()
	{
		HitComponentCollisionShape.Disabled = true;
		AnimatedSprite2D.Stop();
	}
}
