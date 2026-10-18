using System.Collections.Generic;
using UnityEngine;

public class Coordinator : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _explorer;
    [SerializeField] private Reycaster _reycaster;

    private const int _minCube = 2;
    private const int _maxCube = 6;

    private void OnEnable()
    {
        _reycaster.CubeHit += OnCubeHit;
    }

    private void OnDisable()
    {
        _reycaster.CubeHit -= OnCubeHit;
    }

    private void OnCubeHit(Cube cube)
    {
        if (Random.Range(0, 100) < cube.DivisionChance)
        {
            int count = Random.Range(_minCube, _maxCube + 1);

            List<Cube> newCubes = _spawner.Spawn(cube, count);
            _explorer.Explosion(newCubes, cube.transform.position);
        }

        _spawner.Remove(cube);
    }
}