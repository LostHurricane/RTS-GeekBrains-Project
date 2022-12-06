using Commands;
using UnityEngine;

public class MoveCommand : IMoveCommand
{
    public Vector3 Point => _point;
    private Vector3 _point;

    public MoveCommand(Vector3 point)
    {
        _point = point;
    }
}
