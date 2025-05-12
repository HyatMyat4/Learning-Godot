using Godot;
using System;

public partial class InteractableComponent : Area2D
{
	[Signal]
	public delegate void InteractableActivatedEventHandler();

	[Signal]
	public delegate void InteractableDeactivatedEventHandler();

	public override void _Ready()
	{
		BodyEntered += OnBodyEntered;
		BodyExited += OnBodyExited;
	}

	private void OnBodyEntered(Node2D body)
	{
		EmitSignal(SignalName.InteractableActivated);
	}

	private void OnBodyExited(Node2D body)
	{
		EmitSignal(SignalName.InteractableDeactivated);
	}
}
