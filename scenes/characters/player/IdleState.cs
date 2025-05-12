using Godot;
using System;

public partial class IdleState : NodeState
{

	[Export]
	public Player Player { get; set; }

	[Export]
	public AnimatedSprite2D AnimatedSprite2D { get; set; }


	public override void OnProcess(float delta)
	{

		if (Player.PlayerDirection == Vector2.Up)
		{
			AnimatedSprite2D.Play("idle_back");
		}
		else if (Player.PlayerDirection == Vector2.Right)
		{
			AnimatedSprite2D.Play("idle_right");
		}
		else if (Player.PlayerDirection == Vector2.Down)
		{
			AnimatedSprite2D.Play("idle_front");
		}
		else if (Player.PlayerDirection == Vector2.Left)
		{
			AnimatedSprite2D.Play("idle_left");
		}
		else
		{
			AnimatedSprite2D.Play("idle_front");
		}
	}

	public override void OnPhysicsProcess(float delta)
	{
		// Your logic here
	}

	public override void OnNextTransitions()
	{
		GameInputEvents.MovementInput();

		if (GameInputEvents.IsMovementInput())
		{
			EmitSignal(SignalName.Transition, "Walk");
		}

		if (Player.CurrentTool == DataTypes.Tools.AxeWood && GameInputEvents.UseTool())
		{
			EmitSignal(SignalName.Transition, "Chopping");
		}
		if (Player.CurrentTool == DataTypes.Tools.TillGround && GameInputEvents.UseTool())
		{
			EmitSignal(SignalName.Transition, "Tilling");
		}
		if (Player.CurrentTool == DataTypes.Tools.WaterCrops && GameInputEvents.UseTool())
		{
			EmitSignal(SignalName.Transition, "Watering");
		}
	}


	public override void OnEnter()
	{
		// Your logic here
	}

	public override void OnExit()
	{
		AnimatedSprite2D.Stop();
	}
}
