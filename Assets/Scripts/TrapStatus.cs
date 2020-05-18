using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapStatus : MonoBehaviour
{

    public int idtype;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name.Contains("Enemy"))
        {
            col.gameObject.GetComponent<EnemyStatus>().health -= 25.0f;
            col.gameObject.GetComponent<EnemyChasing>().stun = true;
            //stun = true;
            //enemy play stun
            //play trap animation
            this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Item/" + idtype.ToString() + "_2");
            Invoke("Stun", 2.0f);
        }
    }

    void Stun()
    {
        Destroy(this.gameObject);
    }

    void Update()
    {
        
    }
}
