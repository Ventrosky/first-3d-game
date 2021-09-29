using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndFlag : MonoBehaviour{
    public string nextSceneName;
    public bool lastLevel;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            if (lastLevel == true){
                Debug.Log("You Win!");
            } else {
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}
