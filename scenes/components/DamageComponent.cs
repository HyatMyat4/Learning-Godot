using Godot;
using System;

public partial class DamageComponent : Node2D
{

	[Export]
	public int MaxDamage = 3;

	[Export]
	public int CurrentDamage = 0;

	[Signal]
	public delegate void MaxDamagedReachedEventHandler();

	// Called when the node enters the scene tree for the first time.
	public void ApplyDamage(int Damage)
	{
		CurrentDamage = Math.Clamp(CurrentDamage + Damage, 0, MaxDamage);

		if (CurrentDamage == MaxDamage)
		{
			EmitSignal(SignalName.MaxDamagedReached);
		}
	}

}
