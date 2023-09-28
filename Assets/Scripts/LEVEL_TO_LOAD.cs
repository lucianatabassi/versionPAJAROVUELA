using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LEVEL_TO_LOAD : MonoBehaviour
{
    public string levelToLoad;
    private float timer = 10f;
   
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
   
        if(timer <= 0)
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
