using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapDestroyer : MonoBehaviour
{
    public const string CELL_EXPLODED_NOTIFICATION = "cell_exploded";

    #region Singleton
    public static MapDestroyer instance;
    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }
    #endregion

    public Tilemap tilemap;
    public Tile wallTile;

    public GameObject explosionPrefab;
    List<Bomb> explodingBombs = new List<Bomb>();


    public void Explode(Bomb bomb) {
        if (explodingBombs.Contains(bomb)) {
            return;
        }

        explodingBombs.Add(bomb);

        ExplodeDirection(bomb, Directions.Right);
        ExplodeDirection(bomb, Directions.Up);
        ExplodeDirection(bomb, Directions.Left);
        ExplodeDirection(bomb, Directions.Down);

        explodingBombs.Remove(bomb);
        Destroy(bomb.gameObject);
    }


    void ExplodeDirection(Bomb bomb, Directions direction) {
        var originCell = tilemap.WorldToCell(bomb.transform.position);

        var cellToExplode = originCell;
        var currentPower = 0;

        while (CanExplode(cellToExplode) && currentPower <= bomb.power) {
            ExplodeCell(cellToExplode);

            currentPower++;
            cellToExplode = originCell + direction.ToVector3Int() * currentPower;
        }
    }

    bool CanExplode(Vector3Int cell) {
        var tile = tilemap.GetTile<Tile>(cell);
        return tile != wallTile;
    }

    void ExplodeCell(Vector3Int cell) {
        tilemap.SetTile(cell, null);

        var cellCenterPos = tilemap.GetCellCenterWorld(cell);
        var explosion = Instantiate(explosionPrefab, cellCenterPos, Quaternion.identity);
        Destroy(explosion, 1f);

        this.PostNotification(CELL_EXPLODED_NOTIFICATION, cell);
    }
}
