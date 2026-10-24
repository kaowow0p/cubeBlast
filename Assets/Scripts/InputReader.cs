using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const int ActionButton = 0;

    public event Action<Vector2> Clicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(ActionButton))
        {
            Clicked?.Invoke(Input.mousePosition);
        }
    }
}
