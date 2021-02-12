using UnityEngine;

public class LockBallHeight : MonoBehaviour{
    private void Update(){
        if (transform.position.y <= -50) transform.position = new Vector3(transform.position.x,2.5f
            ,transform.position.z);
        if (Time.timeScale == 0) this.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
