using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 5f;
    [SerializeField] private float _explosionRadius = 5f;
    [SerializeField] private float _initialCubeScale = 1f;

    public void Explosion(List<Cube> cubes, Vector3 position)
    {
        PushCubes(cubes, position, _explosionForce, _explosionRadius);
    }

    public void Explode(Vector3 position, float cubeScale)
    {
        float multiplier = _initialCubeScale / cubeScale;
        float force = _explosionForce * multiplier;
        float radius = _explosionRadius * multiplier;

        List<Cube> cubes = FindCubesInRadius(position, radius);

        PushCubes(cubes, position, force, radius);
    }

    private List<Cube> FindCubesInRadius(Vector3 position, float radius)
    {
        List<Cube> cubes = new List<Cube>();

        foreach (Collider foundCollider in Physics.OverlapSphere(position, radius))
        {
            if (foundCollider.TryGetComponent(out Cube cube))
            {
                cubes.Add(cube);
            }
        }

        return cubes;
    }

    private void PushCubes(List<Cube> cubes, Vector3 center, float force, float radius)
    {
        foreach (Cube cube in cubes)
        {
            cube.Rigidbody.AddExplosionForce(force, center, radius);
        }
    }
}