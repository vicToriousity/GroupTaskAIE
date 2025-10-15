using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loadmenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Loadthemenu()
    {
        SceneManager.LoadScene("Adamo", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
