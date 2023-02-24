using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomMapGenerator : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase[] tiles;

    void Start()
    {
        // Recorre cada Tile en el Tilemap y llena con un Tile aleatorio
        for (int x = -5; x < 15; x++)
        {
            for (int y = -5; y < 15; y++)
            {
                Vector3Int tilePosition = new Vector3Int(x, y, 0);
                TileBase randomTile = tiles[Random.Range(0, tiles.Length)];
                tilemap.SetTile(tilePosition, randomTile);
            }
        }
    }
}
