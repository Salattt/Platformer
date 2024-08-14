using UnityEngine;

public class Controller : MonoBehaviour
{
    public Vector2 MoveAxis { get; protected set; }
    public bool IsAtacking { get; protected set; }
    protected bool _isWorking { get; private set; } = true;

    public void TurnOff()
    {
        _isWorking = false;
    }
}
