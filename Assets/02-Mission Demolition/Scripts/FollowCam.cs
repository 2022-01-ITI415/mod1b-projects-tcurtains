using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
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
        // force destination.z to be camZ to keep cam far away
        destination.z = camZ;
        // set camera to destination
        transform.position = destination;
    }


    


}
