using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action<Vector2> Clicked;

    private const int ActionButton = 0;


    private void Update()
    {
        if (Input.GetMouseButtonDown(ActionButton))
        {
            Clicked?.Invoke(Input.mousePosition);
        }
    }
}
