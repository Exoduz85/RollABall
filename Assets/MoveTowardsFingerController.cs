using UnityEngine;

public class MoveTowardsFingerController : MonoBehaviour {
    public float speed = 1f;
    public Rigidbody rb;

    void Update() {
        if (Input.GetMouseButton(0)){
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(myRay, out var hitInfo, 200);
            var lockedY = new Vector3(hitInfo.point.x, 2.5f, hitInfo.point.z);
            this.rb.MovePosition(Vector3.MoveTowards(transform.position, lockedY, speed * Time.deltaTime));
        }
    }
}