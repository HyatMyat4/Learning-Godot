using Godot;
using System;

public partial class Cow : NonePlayableCharacter
{
	public override void _Ready()
	{
		WalkCycles = (int)GD.Randi() % (MaxWalkCycle - MinWalkCycle + 1) + MinWalkCycle;

	}
}
