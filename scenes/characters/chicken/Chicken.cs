using Godot;
using System;

public partial class Chicken : NonePlayableCharacter
{
	public override void _Ready()
	{
		WalkCycles = (int)GD.Randi() % (MaxWalkCycle - MinWalkCycle + 1) + MinWalkCycle;

	}
}
