using System;
using UnityEngine;

public class CompassBallMove : MonoBehaviour{
    public float speed = 1f;
    private void Awake(){
        Input.location.Start();
    }

    private void Start(){
        Input.compass.enabled = true;
    }
    void Update() {
        float currentMagneticHeading = (float)Math.Round(Input.compass.trueHeading, 2);
        transform.rotation = Quaternion.Euler(0,currentMagneticHeading,0);
        transform.position += transform.forward * Time.deltaTime * speed;
    }
}
