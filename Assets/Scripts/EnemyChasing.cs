using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyChasing : MonoBehaviour
{

    public Transform Player;
    float MoveSpeed = 0.65f;
    float MaxDist = 0.4f;
    float MinDist = 0.3f;
    private float range;
    private float angle;
    CharacterRenderer isoRenderer;
    int lDir = 0;
    //public Rigidbody2d rb;

    private void Awake()
    {
        isoRenderer = GetComponentInChildren<CharacterRenderer>();
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    void chaseChar()
    {
        Vector2 inputVector = Vector2.ClampMagnitude((Vector2)(-(transform.position - Player.position)), 1);
        if (Vector2.Distance(transform.position, Player.position) <= MaxDist)
        {
            //Here Call any function U want Like Shoot at here or something
            Debug.Log("hai");
            attackChar();

        }
        else
        {
            isoRenderer.SetDirection(inputVector);
            transform.position = Vector2.MoveTowards(transform.position, Player.position, MoveSpeed * Time.deltaTime);
        }
    }

    void attackChar()
    {
        Vector2 inputVector = Vector2.ClampMagnitude((Vector2)(-(transform.position - Player.position)), 1);
        isoRenderer.attackAnimation(inputVector);
        //isoRenderer.SetDirection(inputVector);
    }

    // Update is called once per frame
    void Update()
    {
        range = Vector2.Distance(transform.position, Player.position);
        angle = Vector2.Angle(transform.up, Player.position - transform.position);

        lDir = isoRenderer.getDirection();
        //Debug.Log(range);

        if (range <= 1.5f && range >= MinDist)
        {
            if (lDir == 0 && angle < 45.0f)
            {
                chaseChar();
            }
            else if ((lDir == 1 || lDir == 7) && angle < 90.0f && angle > 0)
            {
                chaseChar();
            }
            else if ((lDir == 2 || lDir == 6) && angle < 135.0f && angle > 45.0f)
            {
                chaseChar();
            }
            else if ((lDir == 3 || lDir == 5) && angle < 180.0f && angle > 90.0f)
            {
                chaseChar();
            }
            else if (lDir == 4 && angle > 135.0f)
            {
                chaseChar();
            }
            else if (Vector2.Distance(transform.position, Player.position) <= MaxDist)
            {
                //Here Call any function U want Like Shoot at here or something
                Debug.Log("hai");
                attackChar();

            }
            //Move();

            //Vector2 inputVector = Vector2.ClampMagnitude((Vector2)(-(transform.position - Player.position)), 1);
            //isoRenderer.SetDirection(inputVector);
            //transform.position = Vector2.MoveTowards(transform.position, Player.position, MoveSpeed * Time.deltaTime);



        }
        else
        {
            isoRenderer.SetDirection(new Vector2(0, 0));
        }
    }

    //private void Move()
    //{
    //    rb.velocity = new Vector2(Player.position.x, Player.position.y);
    //}
}