using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const int Click = 0;

    public event Action<Vector2> Clicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(Click))
        {
            Clicked?.Invoke(Input.mousePosition);
        }
    }
}
