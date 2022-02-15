using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
    public int score = 0;
    public float speed = 2f;
    public Transform leftPoint;
    public Transform rightPoint;
    bool movingRight = false;

    Rigidbody2D rb;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update () {
        if (transform.position.x <= leftPoint.position.x) {
            movingRight = true;
        }
        if (transform.position.x >= rightPoint.position.x) {
            movingRight = false;
        }
    }

    void FixedUpdate () {
        if (movingRight) {
            rb.MovePosition(rb.position + new Vector2(rightPoint.position.x + speed, 0f) * Time.fixedDeltaTime);
        } else {
            rb.MovePosition(rb.position + new Vector2(leftPoint.position.x - speed, 0f) * Time.fixedDeltaTime);

        }
    }

    void OnCollisionEnter2D (Collider2D col) {
        if (col.gameObject.tag == "Ball") {
            score++;
            speed += 0.25f;
            Destroy(col.gameObject);
        }
    }
}
