using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TreasureHandler : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name.Contains("Detector"))
        {
            //Debug.Log("hai");
            transform.Find("TreasureCanvas").gameObject.SetActive(true);
            //enemy = col.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.name.Contains("Detector"))
        {
            //Debug.Log("bye");
            transform.Find("TreasureCanvas").gameObject.SetActive(false);
            //enemy = null;
        }
    }

    //public int idtype = 1;
    public Sprite newimg;
    // Start is called before the first frame update
    void Start()
    {

    }

    public GameObject player;
    public GameObject win;
    public string next;

    // Update is called once per frame
    void Update()
    {
        if (transform.Find("TreasureCanvas").gameObject.activeSelf)
        {
            bool key = false;
            foreach(int i in player.GetComponent<CharacterStatus>().item)
            {
                if (i == 2)
                {
                    key = true;
                }
            }
            if (Input.GetKeyDown(KeyCode.T) && key)
            {
                GameObject.Find("Treasure").GetComponent<SpriteRenderer>().sprite = newimg;
                player.GetComponent<CharacterStatus>().quest[1] = true;
                if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
                {
                    player.GetComponent<CharacterStatus>().quest[2] = true;
                }

                //menang
                int tquest = 0;
                foreach(bool i in player.GetComponent<CharacterStatus>().quest)
                {
                    if (i)
                    {
                        tquest++;
                    }
                }
                if (SceneManager.GetActiveScene().name.Contains("Stage"))
                {
                    StagesController.stages[SceneManager.GetActiveScene().name] = true;
                    if (StagesController.stagesStar[SceneManager.GetActiveScene().name] != 3 && StagesController.stagesStar[SceneManager.GetActiveScene().name] < tquest) {
                        StagesController.stagesStar[SceneManager.GetActiveScene().name] = tquest;
                        StagesController.stageNow = next;
                    }
                    
                }
                else
                {
                    StagesController.castles[SceneManager.GetActiveScene().name] = true;
                    StagesController.castlesStar[SceneManager.GetActiveScene().name] = tquest;
                }

                //menu
                win.SetActive(true);
            }
        }
    }
}
