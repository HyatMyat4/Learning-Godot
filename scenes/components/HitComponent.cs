using Godot;
using System;

public partial class HitComponent : Area2D
{

	[Export]
	public DataTypes.Tools CurrentTool { get; set; } = DataTypes.Tools.None;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
