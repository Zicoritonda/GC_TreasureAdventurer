using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public static float health = 50.0f;
    public static bool dead = false;
    CharacterRenderer isoRenderer;

    public RectTransform healthbar;

    // Start is called before the first frame update
    void Start()
    {
        isoRenderer = GetComponentInChildren<CharacterRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (health <= 0)
        {
            healthbar.sizeDelta = new Vector2(0.37f * (health / 50), healthbar.rect.height);
            dead = true;
            isoRenderer.dieAnimation();
            Destroy(this.gameObject, 3.0f);
            Debug.Log("destroy");
        }
        else
        {
            healthbar.sizeDelta = new Vector2(0.37f * (health / 50), healthbar.rect.height);
            //Debug.Log("health: " + health);
        }
    }
}
