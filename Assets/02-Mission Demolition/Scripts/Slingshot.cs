using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    // fields set in inspector pane
    [Header("Set in Inspector")]
    public GameObject prefabProjectile;

    // fields set dynamically
    [Header("Set Dynamically")]
    public GameObject launchPoint;
    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimingMode;

    void Awake() 
    {
        Transform launchPointTrans = transform.Find("LaunchPoint");
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false);
        launchPos = launchPointTrans.position;
    }
    void OnMouseEnter() 
    {
       //print("Slingshot:OnMouseEnter()");
       launchPoint.SetActive(true);
    }

    void OnMouseExit() 
    {
        //print("Slingshot:OneMouseExit()");
        launchPoint.SetActive(false);
    }

    void OnMouseDown() 
    {
        //player pressed mouse button while over slingshot
        aimingMode = true;
        // instantiate projectile
        projectile = Instantiate(prefabProjectile) as GameObject;
        //Starts it at the launchPoint
        projectile.transform.position = launchPos;
        // set to isKinematic for now
        projectile.GetComponent<Rigidbody>().isKinematic = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
