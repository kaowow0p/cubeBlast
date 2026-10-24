using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    private Renderer _renderer;
    public Rigidbody Rigidbody;

    public int DivisionChance { get;  private set; }  = 100;

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