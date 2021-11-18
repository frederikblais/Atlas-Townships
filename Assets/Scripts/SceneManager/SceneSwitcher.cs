using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player") {
            SceneManager.LoadScene(1);
        }
    }
}
