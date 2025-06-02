using Godot;
using System;

public partial class NonePlayableCharacter : CharacterBody2D
{
	[Export]
	public int MinWalkCycle = 2;

	[Export]
	public int MaxWalkCycle = 6;


	public int WalkCycles;

	public int CurrentWalkCycleCount;

}
