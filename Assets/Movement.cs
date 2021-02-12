using UnityEngine;
public class Movement : MonoBehaviour{
    private Quaternion startingRot;
    private void Start(){
        startingRot = new Quaternion(0,0,0,1);
    }
    private void Update(){
        Quaternion rot = Input.gyro.attitude;
        transform.rotation = new Quaternion(-rot.x, 0, -rot.y, rot.w) * startingRot;
    }
}