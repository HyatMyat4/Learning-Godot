using Godot;
using System;

public static class DataTypes
{
	public enum Tools
	{
		None,
		AxeWood,
		TillGround,
		WaterCrops,
		PlantCorn,
		PlantTomato
	}

	public enum GrowthStates
	{
		Seed,
		Germination,
		Vegetative,
		Reproduction,
		Maturity,
		Harvesting
	}
}
