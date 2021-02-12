using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathBallCreator : MonoBehaviour{
    public Action<IEnumerable<Vector3>> OnPathCreated = delegate{ };
    public List<Vector3> pathPoints = new List<Vector3>();
    public LineRenderer ln;
    private RaycastHit hitInfo;
    private void Awake(){
        ln = GetComponent<LineRenderer>();
    }
    void Update(){
        if (Input.GetMouseButtonDown(0)){
            pathPoints.Clear();
        }
        else if (Input.GetMouseButton(0)){
            if (Camera.main is { }){
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (!Physics.Raycast(ray, out this.hitInfo)) return;
            }
            if (!(GetDistanceFromLastToCurrentPoint(hitInfo.point) > .5f)) return;
            pathPoints.Add(hitInfo.point);
            ln.positionCount = pathPoints.Count;
            ln.SetPositions(pathPoints.ToArray());
        }
        else if(Input.GetMouseButtonUp(0)){
            OnPathCreated(pathPoints);
        }
    }
    float GetDistanceFromLastToCurrentPoint(Vector3 point){
        return !pathPoints.Any() ? Mathf.Infinity : Vector3.Distance(pathPoints.Last(), point);
    }
}