using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StagesController : MonoBehaviour
{
    public static Dictionary<string, bool> stages = new Dictionary<string, bool>
    {
        {"Stage 1-1",true}, {"Stage 1-2",false}, {"Stage 1-3",false},
        {"Stage 2-1",false}, {"Stage 2-2",false}, {"Stage 2-3",false}, {"Stage 2-4",false},
        {"Stage 3-1",false}, {"Stage 3-2",false}, {"Stage 3-3",false}, {"Stage 3-4",false},
        {"Stage 4-1",false}, {"Stage 4-2",false}, {"Stage 4-3",false},
        {"Stage 5-1",false}, {"Stage 5-2",false}, {"Stage 5-3",false}, {"Stage 5-4",false}, {"Stage 5-5",false}, {"Stage 5-6",false},
        {"Stage 6-1",false}, {"Stage 6-2",false}, {"Stage 6-3",false}, {"Stage 6-4",false}, {"Stage 6-5",false},
        {"Stage 7-1",false}, {"Stage 7-2",false}, {"Stage 7-3",false}, {"Stage 7-4",false}, {"Stage 7-5",false},
        {"Stage 8-1",false}, {"Stage 8-2",false}, {"Stage 8-3",false}, {"Stage 8-4",false}, {"Stage 8-5",false}
    };

    public static Dictionary<string, bool> castles = new Dictionary<string, bool>
    {
        {"Castle 1-4",false}, {"Castle 2-5",false}, {"Castle 3-5",false}, {"Castle 4-4",false},
        {"Castle 5-7",false}, {"Castle 6-6",false}, {"Castle 7-6",false}, {"Castle 8-6",false}
    };

    public static string stageNow = "Stage 1-1";

    public Sprite gray;
    public Sprite yellow;
    public Sprite green;

    void Start()
    {
        //img = canvas.GetComponents<Image>();
    }

    void Update()
    {
        foreach (string stage in stages.Keys)
        {
            //Sprite t = GameObject.Find(stage).GetComponent<Image>().sprite;
            if (stages[stage] == true)
            {
                   GameObject.Find(stage).GetComponent<Image>().sprite = green;
            }
            else
            {
                GameObject.Find(stage).GetComponent<Image>().sprite = gray;
            }
        }
        GameObject.Find(stageNow).GetComponent<Image>().sprite = yellow;

    }
}
