using Godot;
using System;

public partial class CollectableComponent : Area2D
{
	[Export]
	public string CollectableName { get; set; }

	private void OnBodyEntered(Node2D body)
	{
		if (body is Player)
		{
			GetParent().QueueFree();
		}
	}
}
