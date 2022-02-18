using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour {
    public float speed;
    Rigidbody2D rb;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate () {
        rb.velocity = new Vector2(0f, speed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D (Collision2D col) {
        if (col.gameObject.tag == "BackWall") {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
