using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterNotice : MonoBehaviour
{
    public static GameObject enemy = null;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name.Contains("Enemy"))
        {
            //Debug.Log("hai");
            transform.Find("Canvas").gameObject.SetActive(true);
            enemy = col.gameObject;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.name == "Enemy")
        {
            //Debug.Log("hai");
            transform.Find("Canvas").gameObject.SetActive(true);
        }
        if (col.name.Contains("Tree"))
        {
            if (col.transform.position.y < this.transform.position.y)
            {
                //Debug.Log("hai beb" + col.name);
                Color tmp = col.transform.gameObject.GetComponent<SpriteRenderer>().color;
                tmp.a = 0.5f;
                col.transform.gameObject.GetComponent<SpriteRenderer>().color = tmp;
            }
            else
            {
                Color tmp = col.transform.gameObject.GetComponent<SpriteRenderer>().color;
                tmp.a = 1.0f;
                col.transform.gameObject.GetComponent<SpriteRenderer>().color = tmp;
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.name.Contains("Enemy"))
        {
            //Debug.Log("bye");
            transform.Find("Canvas").gameObject.SetActive(false);
            enemy = null;
        }
        if (col.name.Contains("Tree"))
        {
            //Debug.Log("bye beb" + col.name);
            Color tmp = col.transform.gameObject.GetComponent<SpriteRenderer>().color;
            tmp.a = 1.0f;
            col.transform.gameObject.GetComponent<SpriteRenderer>().color = tmp;
        }

    }
}
