using System.Collections.Generic;
using UnityEngine;

public class Coordinator : MonoBehaviour
{
    private const int MaxDivisionChance = 100;
    private const int _minCube = 2;
    private const int _maxCube = 6;

    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _explorer;
    [SerializeField] private Reycaster _reycaster;


    private void OnEnable() =>
        _reycaster.CubeHit += OnCubeHit;

    private void OnDisable() =>  
        _reycaster.CubeHit -= OnCubeHit;

    private void OnCubeHit(Cube cube)
    {
        if (Random.Range(0, MaxDivisionChance) < cube.DivisionChance)
        {
            int count = Random.Range(_minCube, _maxCube + 1);

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