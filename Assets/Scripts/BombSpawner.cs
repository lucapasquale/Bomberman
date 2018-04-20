using UnityEngine;
using UnityEngine.Tilemaps;

public class BombSpawner : MonoBehaviour
{
    public const string BOMB_PLACED_NOTIFICATION = "bomb_placed";

    public Tilemap tilemap;
    public GameObject bombPrefab;
	

    public void PlaceBombAtPos(Vector3 pos) {
        var cell = tilemap.WorldToCell(pos);

        var bombGO = Instantiate(bombPrefab, tilemap.GetCellCenterWorld(cell), Quaternion.identity);
        var bomb = bombGO.GetComponent<Bomb>();
        bomb.pos = cell;

        this.PostNotification(BOMB_PLACED_NOTIFICATION, bomb);
    }

	void Update () {
	    if (Input.GetMouseButtonDown(0)) {
            var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            PlaceBombAtPos(worldPos);
        }	
	}
}
