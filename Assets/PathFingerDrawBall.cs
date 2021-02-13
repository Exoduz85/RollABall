using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class PathFingerDrawBall : MonoBehaviour{
    public LineRenderer lr;
    private Queue<Vector3> vectorPoints;
    private RaycastHit hitInfo;
    private Vector3 velocity = Vector3.zero;
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            vectorPoints = new Queue<Vector3>();
        }
        if (Input.GetMouseButton(0)){
            if (Camera.main is { }){
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (!Physics.Raycast(ray, out this.hitInfo)) return;
            }
            if (!(GetDistanceFromLastToCurrentPoint(hitInfo.point) > .5f)) return;
            vectorPoints.Enqueue(hitInfo.point);
            lr.positionCount = vectorPoints.Count;
            lr.SetPositions(vectorPoints.ToArray());
        }
        if (Input.GetMouseButtonUp(0)){
            StartCoroutine(PlayRecordedInput());
        }
    }
    IEnumerator PlayRecordedInput() {
        while (vectorPoints.Count > 0){
            ApplyIgnoreYPosition(vectorPoints.Dequeue());
            yield return new WaitForSeconds(0.05f);
            lr.SetPositions(vectorPoints.ToArray());
        }
    }
    void ApplyIgnoreYPosition(Vector3 targetPosition) {
        targetPosition.y = this.transform.position.y;
        this.transform.position = Vector3.SmoothDamp(this.transform.position, targetPosition, ref this.velocity, 0.01f);
    }
    float GetDistanceFromLastToCurrentPoint(Vector3 point){
        return !vectorPoints.Any() ? Mathf.Infinity : Vector3.Distance(vectorPoints.Last(), point);
    }
}