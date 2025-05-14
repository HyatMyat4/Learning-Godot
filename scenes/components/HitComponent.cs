using Godot;
using System;

public partial class HitComponent : Area2D
{
	[Export]
	public DataTypes.Tools CurrentTool { get; set; } = DataTypes.Tools.None;

	[Export]
	public int HitDamage { get; set; } = 1;

	// Optional: Called when the node enters the scene tree for the first time
	public override void _Ready()
	{
		// Initialization logic if needed
	}

	// Optional: Called every frame
	public override void _Process(double delta)
	{
		// Frame update logic if needed
	}
}
