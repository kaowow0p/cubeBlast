using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private const int SizeReductionFactor = 2;
    private const int DivisionReductionFactor = 2;

    [SerializeField] private Cube _cubePrefab;

    public List<Cube> Spawn(Cube parent, int count)
    {
        List<Cube> cubes = new List<Cube>();

        for (int i = 0; i < count; i++)
        {
            Cube newCube = Instantiate(_cubePrefab, parent.transform.position, Random.rotation);
            newCube.transform.localScale = parent.transform.localScale / SizeReductionFactor;
            newCube.Init(parent.DivisionChance / DivisionReductionFactor , ColorGenerator.GetRandomColor());

            cubes.Add(newCube);
        }

        return cubes;   
    }

    public void Remove(Cube cube)
    {
        Destroy(cube.gameObject);
    }
}