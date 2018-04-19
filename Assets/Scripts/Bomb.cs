using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Bomb : MonoBehaviour {
    public int power;

    public float countdown = 2f;
    public GameObject explosionPrefab;


    void Update () {
        countdown -= Time.deltaTime;

        if (countdown <= 0f) {
            MapDestroyer.instance.Explode(this);
            Destroy(gameObject);
        }
	}
}
