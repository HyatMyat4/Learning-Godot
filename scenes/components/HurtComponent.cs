using Godot;
using System;

public partial class HurtComponent : Area2D
{

	[Export]
	public DataTypes.Tools Tool { get; set; } = DataTypes.Tools.None;

	[Signal]
	public delegate void OnHurtEventHandler();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	private void OnAreaEntered(Node2D body)
	{

	}


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
