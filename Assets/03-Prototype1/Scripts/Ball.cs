using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public float speed;
    Rigidbody2D rb;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate () {
        rb.velocity = new Vector2(0f, speed * Time.fixedDeltaTime);
    }
}