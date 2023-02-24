using UnityEngine;

public class Test : MonoBehaviour
{
    public int gridSize = 1; // Tamaño del grid

    public GameObject tilePrefab; // Prefab del tile

    void Start()
    {
        // Generar el grid y posicionar los tiles
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                GameObject tile = Instantiate(tilePrefab, transform);
                tile.transform.position = new Vector3(x, 0f, y);
            }
        }
    }
}
