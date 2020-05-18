using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemHandler : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name.Contains("Detector"))
        {
            //Debug.Log("hai");
            transform.Find("ItemCanvas").gameObject.SetActive(true);
            //enemy = col.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.name.Contains("Detector"))
        {
            //Debug.Log("bye");
            transform.Find("ItemCanvas").gameObject.SetActive(false);
            //enemy = null;
        }
    }

    public int idtype = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.Find("ItemCanvas").gameObject.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                for(int i = 0; i < CharacterStatus.item.Length; i++)
                {
                    if(CharacterStatus.item[i] == 0)
                    {
                        CharacterStatus.item[i] = idtype;
                        Debug.Log(CharacterStatus.item[i]);
                        GameObject.Find("item" + i.ToString()).GetComponent<Image>().sprite = Resources.Load<Sprite>("Item/"+idtype.ToString() + "_1");
                        Destroy(this.gameObject);
                        break;
                    }
                }
            }
        }
    }
}
