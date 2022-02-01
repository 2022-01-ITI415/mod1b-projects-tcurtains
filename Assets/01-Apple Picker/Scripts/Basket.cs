using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // get current screen pos of mouse from input
        Vector3 mousePos2D = Input.mousePosition;

        // Cams z position set how far to push mouse into 3D
        mousePos2D.z = - Camera.main.transform.position.z;

        // convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // move x pos of this basket to x pos of mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        //find what hits the basket
        GameObject collideWith = coll.gameObject;
        if (collideWith.tag == "Apple") 
        {
            Destroy(collideWith);
        }
    }
}
