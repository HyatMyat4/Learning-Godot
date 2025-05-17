using Godot;
using System;

public partial class HurtComponent : Area2D
{
	[Export]
	public DataTypes.Tools Tool { get; set; } = DataTypes.Tools.None;

	[Signal]
	public delegate void OnHurtEventHandler(int damage);

	private void OnAreaEntered(Area2D area)
	{
		if (area is HitComponent hitComponent)
		{
			GD.Print('#', Tool, hitComponent.CurrentTool, '#');
			if (Tool == hitComponent.CurrentTool)
			{

				EmitSignal(SignalName.OnHurt, hitComponent.HitDamage); // Emit signal correctly
			}
		}
	}
}
