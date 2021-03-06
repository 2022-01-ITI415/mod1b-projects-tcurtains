using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLine : MonoBehaviour
{
    static public ProjectileLine S; // Singleton
    [Header("Set in Inspector")]
    public float minDist = 0.1f;

    private LineRenderer line;
    private GameObject _poi;
    private List<Vector3> points;

    void Awake() {
        S = this; // set the singleton
        // get a reference to LineRenderer
        line = GetComponent<LineRenderer>();
        // diasble LineRenderer until its needed
        line.enabled = false;
        // initiate points list
        points = new List<Vector3>();
    }

    // this is a property (that is, a method masquerading as a field)
    public GameObject poi {
        get {
            return(_poi);
        }
        set {
            _poi = value;
            if (_poi != null) {
                // when _poi is set to something new, resets everything
                line.enabled = false;
                points = new List<Vector3>();
                AddPoint();
            }
        }
    }

    // this can be used to clear the line directly
    public void Clear() {
        _poi = null;
        line.enabled = false;
        points = new List<Vector3>();
    }

    public void AddPoint() {
        // this is called to add a point to the line
        Vector3 pt = _poi.transform.position;
        if (points.Count > 0 && (pt - lastPoint).magnitude < minDist) {
            // if point isnt far enough from last point, it returns
            return;
        }
        if (points.Count == 0) { // if this launch point...
            Vector3 launchPosDiff = pt - Slingshot.LAUNCH_POS; // to be defined
            // .. it adds an extra bit of line to aid aiming later
            points.Add(pt + launchPosDiff);
            points.Add(pt);
            line.positionCount = 2;
            //set first two points
            line.SetPosition(0, points[0]);
            line.SetPosition(1, points[1]);
            //enables the LineRenderer
            line.enabled = true;
        }else {
            // normal behavior of adding a point
            points.Add(pt);
            line.positionCount = points.Count;
            line.SetPosition(points.Count-1, lastPoint);
        }
    }

    // returns the location of the most recently added point
    public Vector3 lastPoint {
        get {
            if (points == null) {
                // if there are no points, return Vector3.zero
                return(Vector3.zero);
            }
            return(points[points.Count-1]);
        }
    }

    void FixedUpdate() {
        if (poi == null) {
            // if there is no poi, search for one
            if (FollowCam.POI != null) {
                if (FollowCam.POI.tag == "Projectile") {
                    poi = FollowCam.POI;
                } else {
                    return; // return if we didnt find a poi
                }
            }else {
                return; // return if we didnt find a poi
            }
        }
        // if there is a poi, its loc is added every FixedUpdate
        AddPoint();
        if (FollowCam.POI == null) {
            // once FollowCam.POI is null, make local poi null too
            poi = null;
        }
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
