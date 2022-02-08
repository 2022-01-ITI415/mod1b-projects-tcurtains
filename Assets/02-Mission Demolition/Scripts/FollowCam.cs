using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [Header("Set in Inspector")]
    public Vector2 minXY = Vector2.zero;
    public float easing = 0.05f;
    static public GameObject POI; // static point of interest

    [Header("Set Dynamically")]
    public float camZ; //desired Z pos of the cam

    void Awake() {
        camZ = this.transform.position.z;
    }

    void FixedUpdate() {
        // if there's only line following an, it does not need braces
        if (POI == null) return; // return if there is no poi

        // get position of poi
        Vector3 destination = POI.transform.position;
        // limit the X & Y to minimum values
        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);
        //interpolate from current cam position toward destination
        destination = Vector3.Lerp(transform.position,destination, easing);
        // force destination.z to be camZ to keep cam far away
        destination.z = camZ;
        // set camera to destination
        transform.position = destination;
        // set orthographicSize of cam to keep Ground in view
        Camera.main.orthographicSize = destination.y + 10;
    }


    


}
