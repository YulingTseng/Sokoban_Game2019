using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameUI : MonoBehaviour
{
    
    public void btnreloadLEVEL1()
    {
        SceneManager.LoadScene(1);
    }

    public void btnreloadLEVEL2()
    {
        SceneManager.LoadScene(2);
    }

    public void btnreloadLEVEL3()
    {
        SceneManager.LoadScene(3);
    }

    public void btnexit()
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
