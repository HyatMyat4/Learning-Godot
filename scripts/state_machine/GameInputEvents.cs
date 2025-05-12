using Godot;

public static class GameInputEvents
{
	public static Vector2 Direction = Vector2.Zero;

	public static Vector2 MovementInput()
	{
		if (Input.IsActionPressed("walk_left"))
		{
			Direction = Vector2.Left;
		}
		else if (Input.IsActionPressed("walk_right"))
		{
			Direction = Vector2.Right;
		}
		else if (Input.IsActionPressed("walk_up"))
		{
			Direction = Vector2.Up;
		}
		else if (Input.IsActionPressed("walk_down"))
		{
			Direction = Vector2.Down;
		}
		else
		{
			Direction = Vector2.Zero;
		}

		return Direction;
	}

	public static bool IsMovementInput()
	{
		return Direction != Vector2.Zero;
	}

	public static bool UseTool()
	{
		return Input.IsActionJustPressed("hit");
	}

	
}
