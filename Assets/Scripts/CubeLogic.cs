using UnityEngine;

public class CubeLogic : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private InputReader _inputReader;

    private void Start()
    {
        _inputReader = GetComponent<InputReader>();
    }

    private void Update()
    {
        _inputReader.Reader(_camera);
    }

}