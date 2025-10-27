using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SceneManager.LoadScene("Level1", LoadSceneMode.Single);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadScene("Adamo", LoadSceneMode.Single);
        }
    }
}
