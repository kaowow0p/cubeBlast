using UnityEngine;
using UnityEngine.UIElements;

public class Explaoder : MonoBehaviour
{
    public static void Explosion(Cube cube, float _explosionForce, Vector3 position, float _explosionRadius)
    {
        Rigidbody rb = cube.GetComponent<Rigidbody>();
        rb.AddExplosionForce(_explosionForce, position, _explosionRadius);
    }
}
