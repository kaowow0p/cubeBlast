using UnityEngine;

public class CubeLogic : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    private Camera _camera;

    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;
    private void Start()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        Ray _ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(_ray, out RaycastHit hit) && hit.collider.gameObject.TryGetComponent(out Cube cube))
            {
                if (Random.Range(0, 100) < cube.DivisionChance)
                {
                    int count = Random.Range(2, 7);

                    for (int i = 0; i < count; i++)
                    {
                        Divide(cube);
                    }
                }

                Destroy(hit.collider.gameObject);

            }

        }

    }

    private void Divide(Cube oldCube)
    {
        Cube newCube = Instantiate(_cubePrefab, oldCube.transform.position, Random.rotation);

        newCube.transform.localScale = oldCube.transform.localScale * 0.5f;
        newCube.DivisionChance = oldCube.DivisionChance / 2;
        newCube.SetRandomColor();

        Rigidbody rb = newCube.GetComponent<Rigidbody>();
        rb.AddExplosionForce(_explosionForce, oldCube.transform.position, _explosionRadius);
    }

}