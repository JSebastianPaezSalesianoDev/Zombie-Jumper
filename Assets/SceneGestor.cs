using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGestor : MonoBehaviour
{
    public static SceneGestor instance;

    public void Awake()
    {
        if(instance == null){

            instance = this;
            DontDestroyOnLoad(gameObject);
        }    
        else{
            
            Destroy(gameObject);
        }
    }
/*     public void NextLevel(){
        
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(1);
    } */

    public void NextLevel()
{   
    string currentSceneName = SceneManager.GetActiveScene().name;
    if (currentSceneName == "SampleScene") // Nombre de la escena actual
    {
        SceneManager.LoadScene("lvl2"); // Nombre de la escena del Level 2
    }
    else if (currentSceneName == "lvl2")
    {
        SceneManager.LoadScene("lvl4"); // Nombre de la escena del Level 3
    }
}
    public void LoadScene(string sceneName)
    {

    }
}
