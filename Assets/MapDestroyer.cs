using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapDestroyer : MonoBehaviour {
    public Tilemap tilemap;

    public Tile wallTile;
    public Tile destructableTile;
    public GameObject explosionPrefab;


    public void Explode(Vector2 pos) {
        var originCell = tilemap.WorldToCell(pos);

        ExplodeCell(originCell);
    }

    void ExplodeCell(Vector3Int cell) {
        var tile = tilemap.GetTile<Tile>(cell);
        
        if (tile == wallTile) {
            return;
        }

        if (tile == destructableTile) {
            tilemap.SetTile(cell, null);
        }

        var cellCenterPos = tilemap.GetCellCenterWorld(cell);
        Instantiate(explosionPrefab, cellCenterPos, Quaternion.identity);
    }
}
