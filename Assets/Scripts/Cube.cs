using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    public Rigidbody Rigidbody { get; private set; }
    public int DivisionChance { get;  private set; }  = 100;

    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        Rigidbody = GetComponent<Rigidbody>();
    }

    public void Init(int сhance , Color color)
    {
        DivisionChance = сhance; 
        _renderer.material.color = color;
    }

}