using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    private const int ReductionFactor = 2;

    public List<Cube> Spawn(Cube parent, int count)
    {
        List<Cube> cubes = new List<Cube>();

        for (int i = 0; i < count; i++)
        {
            Cube newCube = Instantiate(_cubePrefab, parent.transform.position, Random.rotation);
            newCube.transform.localScale = parent.transform.localScale / ReductionFactor;
            newCube.Init(parent.DivisionChance / ReductionFactor);
            newCube.SetRandomColor();

            cubes.Add(newCube);
        }

        return cubes;
    }

    public void Remove(Cube cube)
    {
        Destroy(cube.gameObject);
    }
}