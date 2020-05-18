using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    // Update is called once per frame
    void Update()
    {
        if (transform.Find("TreasureCanvas").gameObject.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                GameObject.Find("Treasure").GetComponent<SpriteRenderer>().sprite = newimg;
            }
        }
    }
}
