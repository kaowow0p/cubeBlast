using System.Collections.Generic;
using UnityEngine;

public class Coordinator : MonoBehaviour
{
    private const int MaxDivisionChance = 100;
    private const int MinCube = 2;
    private const int MaxCube = 6;

    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _explorer;
    [SerializeField] private Raycaster _reycaster;


    private void OnEnable() =>
        _reycaster.CubeHit += OnCubeHit;

    private void OnDisable() =>  
        _reycaster.CubeHit -= OnCubeHit;

    private void OnCubeHit(Cube cube)
    {
        if (Random.Range(0, MaxDivisionChance) < cube.DivisionChance)
        {
            int count = Random.Range(MinCube, MaxCube + 1);

            List<Cube> newCubes = _spawner.Spawn(cube, count);
            _explorer.Explosion(newCubes, cube.transform.position);
        }
        else
        {
            _explorer.Explode(cube.transform.position, cube.transform.localScale.x);
        }

        _spawner.Remove(cube);
    }
}