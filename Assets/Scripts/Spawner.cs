using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    public void Divide(Cube oldCube)
    {
        Cube newCube = Instantiate(_cubePrefab, oldCube.transform.position, Random.rotation);
        newCube.transform.localScale = oldCube.transform.localScale * 0.5f;
        newCube.DivisionChance = oldCube.DivisionChance / 2;
        newCube.SetRandomColor();

        Explaoder.Explosion(newCube, _explosionForce, oldCube.transform.position, _explosionRadius);
    }
}
