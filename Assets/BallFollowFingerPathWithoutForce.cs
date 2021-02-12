using System.Collections.Generic;
using UnityEngine;

public class BallFollowFingerPathWithoutForce : MonoBehaviour{
    public Queue<Vector3> pathList = new Queue<Vector3>();
    Vector3 velocity = Vector3.zero;
    void Update(){
        if (Input.GetMouseButton(0)){
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo);
            pathList.Enqueue(new Vector3(hitInfo.point.x, 2, hitInfo.point.z));
        }
        else if (Input.GetMouseButtonUp(0)){
            var path = this.pathList;
            this.pathList = new Queue<Vector3>();
            Vector3 target = path.Peek();
            while (Vector3.Distance(this.transform.position, path.Peek()) > .1f && path.Count != 0){
                if (Vector3.Distance(this.transform.position, path.Peek()) < .1f){
                    target = path.Dequeue();
                }
                this.transform.position =
                    Vector3.SmoothDamp(this.transform.position, target, ref velocity, .1f);
            }
        }
    }
}