using UnityEngine;
using UnityEngine.Tilemaps;

public class BombSpawner : MonoBehaviour {

    public Tilemap tilemap;
    public GameObject bombPrefab;
	

	void Update () {
	    if (Input.GetMouseButtonDown(0)) {
            var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var cell = tilemap.WorldToCell(worldPos);
            var cellCenterPos = tilemap.GetCellCenterWorld(cell);

            Instantiate(bombPrefab, cellCenterPos, Quaternion.identity);
        }	
	}
}
