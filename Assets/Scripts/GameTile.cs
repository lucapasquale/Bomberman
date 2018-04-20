using UnityEngine;
using System.Collections;
using UnityEngine.Tilemaps;

public class GameTile : MonoBehaviour
{
    public Bomb bombPlaced;


    public void ExplodeTile() {
        if (bombPlaced != null) {
            MapDestroyer.instance.Explode(bombPlaced);
        }
    }
}
