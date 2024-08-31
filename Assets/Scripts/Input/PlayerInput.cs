using UnityEngine;

public class PlayerInput : Input
{
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";

    public bool isVampiring {  get; private set; }

    private void Update()
    {
        if (IsWorking)
        {
            MoveAxis = new Vector2(UnityEngine.Input.GetAxis(HorizontalAxis), UnityEngine.Input.GetAxis(VerticalAxis));
            IsAtacking = UnityEngine.Input.GetKeyDown(KeyCode.Space);
            isVampiring = UnityEngine.Input.GetKeyDown(KeyCode.E);

            if (IsAtacking)
                MoveAxis = Vector2.zero;
        }
        else
        {
            isVampiring = false;
            MoveAxis = Vector2.zero;
            IsAtacking = false;
        }
    }
}
