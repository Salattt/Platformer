using UnityEngine;

public class PlayerInput : Input
{
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";

    private void Update()
    {
        if (IsWorking)
        {
            MoveAxis = new Vector2(UnityEngine.Input.GetAxis(HorizontalAxis), UnityEngine.Input.GetAxis(VerticalAxis));
            IsAtacking = UnityEngine.Input.GetKeyDown(KeyCode.Space);

            if (IsAtacking)
                MoveAxis = Vector2.zero;
        }
        else
        {
            MoveAxis = Vector2.zero;
            IsAtacking = false;
        }
    }
}
