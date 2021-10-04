using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour{
    public float moveSpeed;
    public Rigidbody rig;
    public float jumpForce;
    public int score;

    private bool isGrounded;

    public UI ui;

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

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded){
            isGrounded = false;
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if(transform.position.y < -10){
            GameOver();
        }
    }

    private void OnCollisionEnter(Collision other) {
        // since using capsule collider there is only
        // one contact point
        if (other.contacts[0].normal == Vector3.up){
            isGrounded = true;
        }
    }

    public void GameOver(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScore(int amount){
        score += amount;
        ui.SetScoreText(score);
    }
}
