using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
    public float speed = 2f;
    public Transform leftPoint;
    public Transform rightPoint;
    bool movingRight = false;

    Rigidbody2D rb;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }

}
