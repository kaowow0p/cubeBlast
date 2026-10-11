using UnityEngine;

public class Cube : MonoBehaviour
{
    private Renderer _renderer;

    public int DivisionChance = 100;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void SetRandomColor()
    {
        _renderer.material.color = Random.ColorHSV();
    }
}