using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class win : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision){

        if(collision.CompareTag("Player")){
            //go to next level
            SceneManager.LoadScene("menu");
        }
    }
}
