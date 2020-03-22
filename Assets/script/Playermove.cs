using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Playermove : MonoBehaviour
{
    public mapcreat M;

    private Animator anim;

    private int dirX = 0;
    private int dirY = 0;

    
    /*int nowtime;
    bool istimer = true;*/

    public int walkcount = 0;  //紀錄移動次數
    
    
    private void awake()
    {
        M = FindObjectOfType<mapcreat>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        awake();
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("deltaX", dirX);
        anim.SetFloat("deltaY", dirY);

        int Vx = 0;
        int Vy = 0;

        if(Input.GetKeyDown(KeyCode.A))
        {
            Vx--;
            walkcount++;
            Allwalk.waco++;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Vx++;
            walkcount++;
            Allwalk.waco++;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Vy++;
            walkcount++;
            Allwalk.waco++;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Vy--;
            walkcount++;
            Allwalk.waco++;
        }


        if (Vx != 0 || Vy != 0)
        {
            dirX = Vx;
            dirY = Vy;
        }

        int x = (int)transform.position.x;
        int y = (int)transform.position.y;

        int nextX = x + Vx;
        int nextY = y + Vy;

        if(isWall(nextX,nextY))
        {
            return;
        }

        if(isBox(nextX,nextY))
        {
            int nnextX = nextX + Vx;
            int nnextY = nextY + Vy;

            if (isBox(nnextX, nnextY) || isWall(nnextX, nnextY))
            {
                return;
            }

            GameObject Obj = getbox(nextX, nextY);
            Obj.transform.position = new Vector3(nnextX, nnextY);

            M.box_pos.Remove(nextX * 100 + nextY);
            M.box_pos.Add(nnextX * 100 + nnextY, Obj);
        }

        transform.position = new Vector3(nextX, nextY);


        GameObject.Find("walktxt").GetComponent<Text>().text = "Walk: " + walkcount.ToString();
        //StartCoroutine("timer");

        win();
        
    }

    /*---計算時間---*/

    /*void showtime()
    {
        nowtime = Time.time - starttime;
        GameObject.Find("timetxt").GetComponent<Text>().text = "Time: " + nowtime.ToString("F1");   //取到小數第一
        
    }*/

    /*IEnumerator timer()
    {
        yield return new WaitForSeconds(1);
        nowtime++;
        istimer = true;
        GameObject.Find("timetxt").GetComponent<Text>().text = "Time: " + nowtime.ToString();
    }*/
    
    /*---轉陣列2-->1---*/
    bool isWall(int x,int y)
    {
        return M.wall_pos.Contains(x * 100 + y);
    }

    bool isBox(int x,int y)
    {
        return M.box_pos.ContainsKey(x * 100 + y);
    }

    GameObject getbox(int x,int y)
    {
        return M.box_pos[x * 100 + y];
    }
    
    /*---Win---*/
    void win()
    {
        int count = 0;
        foreach(var target in M.targets)
        {
            if(M.box_pos.ContainsKey(target))
            {
                count++;
            }
        }

        int index = SceneManager.GetActiveScene().buildIndex;

        if (count==M.targets.Count)
        {
            Debug.Log("Win");
            
            if (index==1)
            {
                SceneManager.LoadScene(2);
            }
            else if(index==2)
            {
                SceneManager.LoadScene(3);
            }
            else if(index==3)
            {
                SceneManager.LoadScene(4);
            }
        }
    }
}
