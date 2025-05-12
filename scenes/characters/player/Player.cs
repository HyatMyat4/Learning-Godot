using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export]
	public DataTypes.Tools CurrentTool { get; set; } = DataTypes.Tools.None;

	public Vector2 PlayerDirection { get; set; }

}
