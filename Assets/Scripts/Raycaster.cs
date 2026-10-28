using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private InputReader _inputReader;

    public event Action<Cube> CubeHit;

    private void OnEnable()
    {
        _inputReader.Clicked += OnClicked;
    }

    private void OnDisable()
    {
        _inputReader.Clicked -= OnClicked;
    }

    private void OnClicked(Vector2 mousePosition)
    {
        Ray _ray = _camera.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(_ray, out RaycastHit hit) && hit.collider.gameObject.TryGetComponent(out Cube cube))
        {
            CubeHit?.Invoke(cube);
        }
    }
}
