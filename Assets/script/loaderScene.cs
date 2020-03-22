using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loaderScene : MonoBehaviour
{
    public void btnStartClick()
    {
        SceneManager.LoadScene(1);
    }

    public void btnEndClick()
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
