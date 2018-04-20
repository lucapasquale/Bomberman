using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    #region Singleton
    public static GameController instance;
    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }
    #endregion

    public Tilemap gameTilemap;
    public GameObject baseGameTile;
    Dictionary<Vector3Int, GameObject> gameTiles = new Dictionary<Vector3Int, GameObject>();

    private void Start() {
        var origin = gameTilemap.origin;
        var size = gameTilemap.size;

        for (int x = origin.x; x < origin.x + size.x; x++) {
            for (int y = origin.y; y < origin.y + size.y; y++) {
                var pos = new Vector3Int(x, y, 0);
                var tile = Instantiate(baseGameTile, pos, Quaternion.identity, transform);
                tile.name = $"Tile ({pos.x}, {pos.y})";

                gameTiles.Add(pos, tile);
            }
        }
    }


    private void OnEnable() {
        this.AddObserver(BombPlaced, BombSpawner.BOMB_PLACED_NOTIFICATION);
        this.AddObserver(CellExploded, MapDestroyer.CELL_EXPLODED_NOTIFICATION);
    }

    void BombPlaced(object sender, object args) {
        var bomb = args as Bomb;
  
        var gameTile = gameTiles[bomb.pos].GetComponent<GameTile>();
        if (gameTile.bombPlaced != null) {
            Destroy(bomb.gameObject);
            return;
        }

        gameTile.bombPlaced = bomb;
    }

    void CellExploded(object sender, object args) {
        var cell = args as Vector3Int?;

        var gameTile = gameTiles[cell.Value].GetComponent<GameTile>();
        gameTile.ExplodeTile();
    }
}
