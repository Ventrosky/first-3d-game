using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour{
    // deg
    public float rotateSpeed;

    // Update is called once per frame
    void Update(){
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")){
            other.GetComponent<Player>().AddScore(1);
            Destroy(gameObject);
        }
    }
}
