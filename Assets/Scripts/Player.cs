using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
    public float moveSpeed;
    public Rigidbody rig;

    // Update is called once per frame
    void Update(){
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        rig.velocity = new Vector3(x, rig.velocity.y, z);

        Vector3 vel = rig.velocity;
        vel.y = 0;

        if (vel.x != 0 || vel.y != 0) {
            transform.forward = vel;
        }
    }
}
