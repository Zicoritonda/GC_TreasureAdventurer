using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatus : MonoBehaviour
{
    public float health = 100.0f;
    public bool dead = false;
    CharacterRenderer isoRenderer;

    public RectTransform healthbar;

    //-1: skill, 2: key , 3: , 4: , 5:
    public int[] item = new int[5] { -1, 0, 0, 0, 0 };
    public static bool skill = true;

    public GameObject ded;

    public bool[] quest = { false, false, false };

    // Start is called before the first frame update
    void Start()
    {
        isoRenderer = GetComponentInChildren<CharacterRenderer>();
    }

    void mati()
    {
        ded.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (health <= 0)
        {
            healthbar.sizeDelta = new Vector2(520 * (health / 100), healthbar.rect.height);
            dead = true;
            isoRenderer.dieAnimation();
            Invoke("mati", 1.0f);
        }
        else
        {
            healthbar.sizeDelta = new Vector2(520 * (health / 100), healthbar.rect.height);
            //Debug.Log("health: " + health);
        }
    }
}
