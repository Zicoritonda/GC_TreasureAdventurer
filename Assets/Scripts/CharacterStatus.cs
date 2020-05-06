using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatus : MonoBehaviour
{
    public static float health = 100.0f;
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
            healthbar.sizeDelta = new Vector2(520 * (health / 100), healthbar.rect.height);
            dead = true;
            isoRenderer.dieAnimation();
        }
        else
        {
            healthbar.sizeDelta = new Vector2(520 * (health / 100), healthbar.rect.height);
            //Debug.Log("health: " + health);
        }
    }
}
