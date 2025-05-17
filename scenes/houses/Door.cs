using Godot;
using System;

public partial class Door : StaticBody2D
{
	private AnimatedSprite2D _animatedSprite2D;
	private CollisionShape2D _collisionShape2D;
	private InteractableComponent _interactableComponent;

	public override void _Ready()
	{
		_animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		_collisionShape2D = GetNode<CollisionShape2D>("CollisionShape2D");
		_interactableComponent = GetNode<InteractableComponent>("InteractableComponent");

		_interactableComponent.InteractableActivated += OnInteractableActivated;
		_interactableComponent.InteractableDeactivated += OnInteractableDeactivated;

		CollisionLayer = 1;
	}

	private void OnInteractableActivated()
	{
		_animatedSprite2D.Play("open_door");
		CollisionLayer = 2;

	}

	private void OnInteractableDeactivated()
	{
		_animatedSprite2D.Play("close_door");
		CollisionLayer = 1;

	}
}
