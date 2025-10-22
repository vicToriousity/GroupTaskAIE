using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadlvlTwO : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadthLVLTWO()
    {
        SceneManager.LoadScene("LevelTwo", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
