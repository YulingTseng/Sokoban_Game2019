using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mapcreat : MonoBehaviour
{

    public string[] map;

    public GameObject player;
    public GameObject box;
    public GameObject target;
    public GameObject wall;
    //public GameObject ground;
    

    public Dictionary<int, GameObject> box_pos = new Dictionary<int, GameObject>();
    public HashSet<int> wall_pos = new HashSet<int>();
    public List<int> targets = new List<int>();

    public const int size = 100;   //二維轉一維

    void awake()
    {
        int v_row = 0;

        foreach (var row in map)
        {
            int v_col = 0;
            for (int i = 0; i < row.Length; i++)
            {
                Vector3 objV = new Vector3(v_row, v_col);


                if (row[i] == 'P')
                {
                    Instantiate(player, objV, Quaternion.identity);
                }

                if (row[i] == 'W')
                {
                    Instantiate(wall, objV, Quaternion.identity);
                    wall_pos.Add(array(v_row,v_col));
                }

                if (row[i] == 'B')
                {
                    GameObject newbox = Instantiate(box, objV, Quaternion.identity);
                    box_pos.Add(array(v_row,v_col), newbox);
                }

                if (row[i] == 'T')
                {
                    Instantiate(target, objV, Quaternion.identity);
                    targets.Add(array(v_row,v_col));
                }

                //Instantiate(ground, objV, Quaternion.identity);

                v_col++;
            }
            v_row++;
        }

    }

    public int array(int x,int y)
    {
        return size * x + y;
    }

    
    

    // Start is called before the first frame update
    void Start()
    {
        awake();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
