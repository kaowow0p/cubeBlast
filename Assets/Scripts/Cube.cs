using Unity.Collections.Tests.CoreCLR.TestJobs;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    private Renderer _renderer;
    private Rigidbody _rigidbody;

    public Rigidbody Rigidbody => _rigidbody;
    public int DivisionChance { get;  private set; }  = 100;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Init(int сhance , Color color)
    {
        DivisionChance = сhance; 
        _renderer.material.color = color;
    }

}