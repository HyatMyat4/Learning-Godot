using Godot;
using System;
using System.Threading.Tasks;

public partial class SmallTree : Sprite2D
{
	private HurtComponent _hurtComponent;
	private DamageComponent _damageComponent;

	private readonly PackedScene _logScene = GD.Load<PackedScene>("res://scenes/objects/trees/log.tscn");

	public override void _Ready()
	{
		_hurtComponent = GetNode<HurtComponent>("HurtComponent");
		_damageComponent = GetNode<DamageComponent>("DamageComponent");

		_hurtComponent.OnHurt += OnHurt;
		_damageComponent.MaxDamagedReached += OnMaxDamageReached;
	}

	private async void OnHurt(int hitDamage)
	{
		_damageComponent.ApplyDamage(hitDamage);

		// Material.SetShaderParameter("shake_intensity", 0.5f);

		// var timer = GetTree().CreateTimer(1.0);
		// await ToSignal(timer, SceneTreeTimer.SignalName.Timeout);

		// Material.SetShaderParameter("shake_intensity", 0.0f);
	}

	private void OnMaxDamageReached()
	{
		CallDeferred(nameof(AddLogScene));
		GD.Print("max damaged reached");
		QueueFree();
	}

	private void AddLogScene()
	{
		if (_logScene.Instantiate() is Node2D logInstance)
		{
			logInstance.GlobalPosition = GlobalPosition;
			GetParent().AddChild(logInstance);
		}
	}
}
