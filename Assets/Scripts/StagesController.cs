using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StagesController : MonoBehaviour
{
    public static Dictionary<string, bool> stages = new Dictionary<string, bool>
    {
        {"Stage 1-1",false}, {"Stage 1-2",false}, {"Stage 1-3",false},
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

    public static Dictionary<string, int> stagesStar = new Dictionary<string, int>
    {
        {"Stage 1-1",0}, {"Stage 1-2",0}, {"Stage 1-3",0},
        {"Stage 2-1",0}, {"Stage 2-2",0}, {"Stage 2-3",0}, {"Stage 2-4",0},
        {"Stage 3-1",0}, {"Stage 3-2",0}, {"Stage 3-3",0}, {"Stage 3-4",0},
        {"Stage 4-1",0}, {"Stage 4-2",0}, {"Stage 4-3",0},
        {"Stage 5-1",0}, {"Stage 5-2",0}, {"Stage 5-3",0}, {"Stage 5-4",0}, {"Stage 5-5",0}, {"Stage 5-6",0},
        {"Stage 6-1",0}, {"Stage 6-2",0}, {"Stage 6-3",0}, {"Stage 6-4",0}, {"Stage 6-5",0},
        {"Stage 7-1",0}, {"Stage 7-2",0}, {"Stage 7-3",0}, {"Stage 7-4",0}, {"Stage 7-5",0},
        {"Stage 8-1",0}, {"Stage 8-2",0}, {"Stage 8-3",0}, {"Stage 8-4",0}, {"Stage 8-5",0}
    };

    public static Dictionary<string, int> castlesStar = new Dictionary<string, int>
    {
        {"Castle 1-4",0}, {"Castle 2-5",0}, {"Castle 3-5",0}, {"Castle 4-4",0},
        {"Castle 5-7",0}, {"Castle 6-6",0}, {"Castle 7-6",0}, {"Castle 8-6",0}
    };

    public static string stageNow = "Stage 1-1";

    public Sprite gray;
    public Sprite yellow;
    public Sprite green;
    public Sprite starGold;
    public Sprite starGray;

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
                //GameObject.Find(stage).GetComponent<Image>().sprite = green;
                Image[] star = GameObject.Find(stage).GetComponentsInChildren<Image>();
                int gold = stagesStar[stage];
                //int abu = 3 - gold;
                for(int i = 1; i <= 3; i++)
                {
                    if(i<=gold) star[i].sprite = starGold;
                    else star[i].sprite = starGray;
                }
                GameObject.Find(stage).GetComponent<Image>().sprite = green;
            }
            else
            {
                GameObject.Find(stage).GetComponent<Image>().sprite = gray;
            }
        }
        /*Image[] star2 = GameObject.Find(stageNow).GetComponentsInChildren<Image>();
        foreach(Image i in star2)
        {
            i.sprite = starGray;
        }*/
        GameObject.Find(stageNow).GetComponent<Image>().sprite = yellow;

    }
}
