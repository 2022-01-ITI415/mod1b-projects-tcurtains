using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nerf : MonoBehaviour {
    public GameObject ball;

    void Update () {
        if (Input.GetMouseButtonDown(0)) {
            Instantiate(ball, transform.position, Quaternion.identity);
        }
    }
}
