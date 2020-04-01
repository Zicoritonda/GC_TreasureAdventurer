using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterNotice : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Enemy")
        {
            Debug.Log("hai");
            transform.Find("Canvas").gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("bye");
        transform.Find("Canvas").gameObject.SetActive(false);
    }
}
