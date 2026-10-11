using UnityEngine;

public class InputReader : MonoBehaviour
{
    private Spawner spawner;

    private void Start()
    {
        spawner = GetComponent<Spawner>();
    }

    public void Reader(Camera camera)
    {
        Ray _ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(_ray, out RaycastHit hit) && hit.collider.gameObject.TryGetComponent(out Cube cube))
            {
                if (Random.Range(0, 100) < cube.DivisionChance)
                {
                    int count = Random.Range(2, 7);

                    for (int i = 0; i < count; i++)
                    {
                        spawner.Divide(cube);
                    }
                }

                Destroy(hit.collider.gameObject);

            }

        }
    }
}
