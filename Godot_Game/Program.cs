using Godot;
using System.Numerics;
using System.Runtime.InteropServices.JavaScript;

public partial class Ball : Area2D
{
    [Export] public float Speed = 300f;

    private Vector2 _direction = new Vector2(1, -1).Normalized();

    public override void _Process(double delta)
    {
        Position += _direction * Speed * (float)delta;

        // screen borders
        if (Position.X < 0 || Position.X > 800)
            _direction.X *= -1;

        if (Position.Y < 0)
            _direction.Y *= -1;
    }

    private void _on_area_entered(Area2D area)
    {
        if (area.IsInGroup("paddle"))
        {
            _direction.Y *= -1;
        }

        if (area.IsInGroup("bricks"))
        {
            _direction.Y *= -1;
            area.QueueFree();
        }
    }
}