using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class winUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("allwalk").GetComponent<Text>().text = "Total: " + Allwalk.waco.ToString();
    }

    public void btnbackclick()
    {
        SceneManager.LoadScene(0);
    }

    public void btnrestart()
    {
        SceneManager.LoadScene(1);
    }
}
