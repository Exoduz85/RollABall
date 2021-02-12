using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class BallFollowFingerPath : MonoBehaviour{
    public float speed = 1f;
    public Rigidbody rb;
    public List<Vector3> pathList;
    public bool startMove;
    public int currentIndex = 0;

    private void Start(){
        pathList = new List<Vector3>();
    }
    void Update() {
        if (Input.GetMouseButtonDown(0)){
            pathList.Clear();
            currentIndex = 0;
        }
        if (Input.GetMouseButton(0)) {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hitInfo)) {
                var hitpoint = new Vector3(hitInfo.point.x, 1.999987f, hitInfo.point.z);
                pathList.Add(hitpoint);
            }
        }
        if (Input.GetMouseButtonUp(0)){
            startMove = true;
        }
        if(startMove){
            this.rb.AddForce((pathList[currentIndex] - this.transform.position).normalized * this.speed * Time.fixedDeltaTime
                , ForceMode.VelocityChange);
            if(Vector3.Distance(this.transform.position, pathList[currentIndex]) < 0.5f){
                if (currentIndex + 1 >= pathList.Count){
                    startMove = false;
                    return;
                }
                currentIndex++;
            }
        }
    }
}
