using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public const string BOMB_EXPLODED_NOTIFICATION = "bomb_exploded";

    public int power;
    public Vector3Int pos;

    public float countdown = 20f;
    public GameObject explosionPrefab;


    void Update () {
        countdown -= Time.deltaTime;

        if (countdown <= 0f) {
            this.PostNotification(BOMB_EXPLODED_NOTIFICATION, this);
            MapDestroyer.instance.Explode(this);
        }
	}

    private void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            var bc2d = GetComponent<Collider2D>();
            bc2d.isTrigger = false;
        }
    }
}
