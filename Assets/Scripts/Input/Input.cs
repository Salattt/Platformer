using UnityEngine;

public class Input : MonoBehaviour
{
    public Vector2 MoveAxis { get; protected set; }
    public bool IsAtacking { get; protected set; }
    protected bool IsWorking { get; private set; } = true;

    public void TurnOff()
    {
        IsWorking = false;
    }
}
