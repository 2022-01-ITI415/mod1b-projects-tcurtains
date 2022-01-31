using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject applePrefab;
    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    public float chanceToChangeDirections = 0.1f;
    public float secondsBetweenAppleDrops = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Basic Movement 
        Vector3 pos = transform.position; //b
        pos.x += speed * Time .deltaTime; //c
        transform.position = pos; //d
        //Changing Direction
        if ( pos.x < -leftAndRightEdge ) { // a
        speed = Mathf .Abs(speed); // Move right // b
        } else if ( pos.x > leftAndRightEdge ) { // c
        speed = - Mathf .Abs(speed); // Move left // c
        }
        
    }
}
