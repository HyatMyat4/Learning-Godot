using Godot;
using System;
using System.Threading.Tasks;

public partial class Rock : Sprite2D
{
	private HurtComponent _hurtComponent;
	private DamageComponent _damageComponent;

	private readonly PackedScene _stoneScene = GD.Load<PackedScene>("res://scenes/objects/rocks/stone.tscn");

	public override void _Ready()
	{
		_hurtComponent = GetNode<HurtComponent>("HurtComponent");
		_damageComponent = GetNode<DamageComponent>("DamageComponent");

		_hurtComponent.OnHurt += OnHurt;
		_damageComponent.MaxDamagedReached += OnMaxDamageReached;
	}

	private async void OnHurt(int hitDamage)
	{
		GD.Print('#', hitDamage, '#');
		_damageComponent.ApplyDamage(hitDamage);

		if (Material is ShaderMaterial shaderMaterial)
		{

			await ToSignal(GetTree().CreateTimer(0.50f), SceneTreeTimer.SignalName.Timeout);
			shaderMaterial.SetShaderParameter("shake_intensity", 0.3f);

			await ToSignal(GetTree().CreateTimer(0.50f), SceneTreeTimer.SignalName.Timeout);

			shaderMaterial.SetShaderParameter("shake_intensity", 0.0f);
		}
	}


	private void OnMaxDamageReached()
	{
		GD.Print("OnMaxDamageReached");
		CallDeferred(nameof(AddStoneScene));
		QueueFree();
	}
	private void AddStoneScene()
	{
		try
		{
			if (_stoneScene == null)
				throw new NullReferenceException("_stoneScene is null. Make sure the PackedScene is loaded properly.");

			var instance = _stoneScene.Instantiate();

			if (instance is Node2D stoneInstance)
			{
				stoneInstance.GlobalPosition = GlobalPosition;

				var parent = GetParent();
				if (parent == null)
					throw new InvalidOperationException("Parent node is null. Cannot add stone instance.");

				parent.AddChild(stoneInstance);
				GD.Print("AddStoneScene - Stone added successfully.");
			}
			else
			{
				throw new InvalidCastException("Instantiated scene is not a Node2D.");
			}
		}
		catch (Exception ex)
		{
			GD.PrintErr("AddStoneScene - Error: ", ex.Message);
		}
	}


}
