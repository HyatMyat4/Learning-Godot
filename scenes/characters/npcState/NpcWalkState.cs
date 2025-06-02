using Godot;
using System;
using System.Threading.Tasks;

public partial class NpcWalkState : NodeState
{

	[Export]
	public NonePlayableCharacter Character { get; set; }

	[Export]
	public AnimatedSprite2D AnimatedSprite { get; set; }

	[Export]
	public NavigationAgent2D NavigationAgent { get; set; }

	[Export]
	public double MinSpeed = 9.0;

	[Export]
	public double MaxSpeed = 13;

	public double Speed;


	public override void _Ready()
	{
		CallDeferred(nameof(CharacterSetup)); // Ensures it's called after node is added
		NavigationAgent.VelocityComputed += OnSafeVelocityComputed; // Correct connection
	}

	public async void CharacterSetup()
	{
		await ToSignal(GetTree(), SceneTree.SignalName.PhysicsFrame);
		GD.Print("Character setup complete.");
		SetMovementTarget();
	}
	public void SetMovementTarget()
	{
		Vector2 targetPosition = NavigationServer2D.MapGetRandomPoint(
			NavigationAgent.GetNavigationMap(),
			NavigationAgent.NavigationLayers,
			false
		);



		NavigationAgent.TargetPosition = targetPosition;
		Speed = (float)GD.RandRange((float)MinSpeed, MaxSpeed);
	}
	public override void OnProcess(float delta)
	{



		if (NavigationAgent.IsNavigationFinished())
		{
			Character.CurrentWalkCycleCount += 1;
			SetMovementTarget();
			return;
		}
		Vector2 targetPosition = NavigationAgent.GetNextPathPosition();
		Vector2 targetDirection = Character.GlobalPosition.DirectionTo(targetPosition);
		Vector2 Velocity = targetDirection * (float)Speed;

		if (NavigationAgent.AvoidanceEnabled)
		{
			NavigationAgent.Velocity = Velocity;
			AnimatedSprite.FlipH = Velocity.X < 0;
		}
		else
		{
			Character.Velocity = Velocity;
			Character.MoveAndSlide();
		}

	}
	public override void OnPhysicsProcess(float delta) { }

	public void OnSafeVelocityComputed(Vector2 SafeVelocity)
	{
		Character.Velocity = SafeVelocity;
		AnimatedSprite.FlipH = SafeVelocity.X < 0;
		Character.MoveAndSlide();
	}
	public override void OnNextTransitions()
	{
		GD.Print($"WalkCycles: {Character.CurrentWalkCycleCount}, {Character.WalkCycles}");
		if (Character.CurrentWalkCycleCount == Character.WalkCycles)
		{
			Character.Velocity = Vector2.Zero;
			Character.CurrentWalkCycleCount = 0;
			EmitSignal(SignalName.Transition, "NpcIdleState");
		}
	}
	public override void OnEnter()
	{
		AnimatedSprite.Play("walk");
	}
	public override void OnExit()
	{
		AnimatedSprite.Stop();
	}
}
