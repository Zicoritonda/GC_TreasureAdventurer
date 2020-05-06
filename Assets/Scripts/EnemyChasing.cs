using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyChasing : MonoBehaviour
{

    public Transform Player;
    float MoveSpeed = 0.7f;
    float MaxDist = 0.4f;
    float MinDist = 0.3f;
    private float range;
    private float angle;
    CharacterRenderer isoRenderer;
    int lDir = 0;

    //public static bool hit;
    float demage = 5.0f;
    int attackcount = 0;
    //public Rigidbody2d rb;

    private void Awake()
    {
        isoRenderer = GetComponentInChildren<CharacterRenderer>();
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    void dieChar()
    {
        Vector2 inputVector = Vector2.ClampMagnitude((Vector2)(-(transform.position - Player.position)), 1);
        isoRenderer.attack1Animation(inputVector);
    }

    void chaseChar()
    {
        Vector2 inputVector = Vector2.ClampMagnitude((Vector2)(-(transform.position - Player.position)), 1);
        if (Vector2.Distance(transform.position, Player.position) <= MaxDist)
        {
            //Here Call any function U want Like Shoot at here or something
            //Debug.Log("hai");
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
        isoRenderer.attack1Animation(inputVector);
        attackcount++;
        if (attackcount == 26)
        {
            CharacterStatus.health -= demage;
            attackcount = 0;
        }
        //Debug.Log(attackcount);
        //isoRenderer.SetDirection(inputVector);
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemyStatus.dead != true)
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
                    //Debug.Log("hai");
                    attackChar();
                }
                else
                {
                    if (point1 != null && point2 != null) Patrol();
                }

                //Move();

                //Vector2 inputVector = Vector2.ClampMagnitude((Vector2)(-(transform.position - Player.position)), 1);
                //isoRenderer.SetDirection(inputVector);
                //transform.position = Vector2.MoveTowards(transform.position, Player.position, MoveSpeed * Time.deltaTime);



            }
            else
            {
                if (point1 != null && point2 != null) Patrol();
            }
        }
        
    }

    public Transform point1;
    public Transform point2;
    int point = 1;

    void Patrol()
    {
        if (point == 1)
        {
            Vector2 inputVector = Vector2.ClampMagnitude((Vector2)(-(transform.position - point2.position)), 1);
            isoRenderer.SetDirection(inputVector);
            transform.position = Vector2.MoveTowards(transform.position, point2.position, MoveSpeed * Time.deltaTime);
            if(Vector2.Distance(transform.position, point2.position) <= 0.2f)
            {
                point = 2;
            }
        }
        else
        {
            Vector2 inputVector = Vector2.ClampMagnitude((Vector2)(-(transform.position - point1.position)), 1);
            isoRenderer.SetDirection(inputVector);
            transform.position = Vector2.MoveTowards(transform.position, point1.position, MoveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, point1.position) <= 0.2f)
            {
                point = 1;
            }
        }
    }

    //private void Move()
    //{
    //    rb.velocity = new Vector2(Player.position.x, Player.position.y);
    //}
}