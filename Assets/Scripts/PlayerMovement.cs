using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public BombSpawner spawner;
    public float speed = 50f;
    Rigidbody2D rb2d;

    private void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        var movementVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb2d.MovePosition(rb2d.position + movementVector.normalized * speed * Time.deltaTime);

        if (Input.GetKeyDown("space")) {
            spawner.PlaceBombAtPos(transform.position);
        }
    }
}
