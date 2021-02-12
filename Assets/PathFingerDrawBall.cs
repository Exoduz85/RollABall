using System.Collections.Generic;
using UnityEngine;

public class PathFingerDrawBall : MonoBehaviour{
    public LineRenderer lr;
    public List<Vector3> vectorPoints;
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            vectorPoints = new List<Vector3>();
        }
        if (Input.GetMouseButton(0)){
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(myRay, out var hitInfo)){
                if (Vector3.Distance(this.transform.position, hitInfo.point) > 1f){
                    vectorPoints.Add(hitInfo.point);
                }
            }
        }

        if (Input.GetMouseButtonUp(0)){
            // start moving the ball, finish recording input.
        }
    }
}
