using UnityEngine;

public class PlayerController : Controller
{
    private void Update()
    {
        if (_isWorking)
        {
            MoveAxis = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            IsAtacking = Input.GetKeyDown(KeyCode.Space);

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
