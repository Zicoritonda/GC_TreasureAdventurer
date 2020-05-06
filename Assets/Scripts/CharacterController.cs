using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public static string mapBefore = "SampleScene";
    public float movementSpeed = 1f;
    CharacterRenderer isoRenderer;

    Rigidbody2D rbody;

    bool attack = false;
    bool contack = false;

    Vector2 target;
    int attackcount = 0;
    float demage = 10.0f;
    int attackAnim = 0;

    Vector3 mousePos;
    Vector2 mousePos2D;
    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<CharacterRenderer>();
        target = rbody.position;
    }

    void Start()
    {
        
        /*GameObject teleport = GameObject.Find("Teleport - " + mapBefore);
        Debug.Log(teleport.name);*/
        /*Vector3 startPos = teleport.GetComponent<CompositeCollider2D>().bounds.center;
        Debug.Log(startPos);
        this.transform.position = startPos;*/
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(CharacterStatus.dead == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //currentPos = rbody.position;
                //target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //attack = false;
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos2D = new Vector2(mousePos.x, mousePos.y);
                RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
                if (hit.collider != null)
                {
                    if (hit.collider.isTrigger)
                    {
                        if (hit.transform.name.Contains("Enemy"))
                        {
                            attack = true;
                            //Debug.Log("enemy");

                            attackAnim++;
                            if (attackAnim > 1) attackAnim = 0;
                            if (Vector2.Distance(transform.position, CharacterNotice.enemy.transform.position) < 1f)
                            {
                                EnemyStatus.health -= demage;
                                //contack = true;
                                //attackChar(CharacterNotice.enemy.transform);
                            }
                        }
                        else
                        {
                            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                            attack = false;
                        }
                    }
                }
                else
                {
                    target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    attack = false;
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                attack = true;

                /*RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
                if (hit.collider != null)
                {
                    if (hit.collider.isTrigger)
                    {
                        if (hit.transform.name.Contains("Enemy"))
                        {
                            Debug.Log("serang cuy" + hit.transform.name);
                            Vector2 inputVector = Vector2.ClampMagnitude((Vector2)(-(transform.position - hit.transform.position)), 1);
                            if (attackAnim == 0)
                            {
                                isoRenderer.attack1Animation(inputVector);
                                //attackAnim++;
                            }
                            else
                            {
                                isoRenderer.attack2Animation(inputVector);
                                //attackAnim=0;
                            }
                            //attack = true;
                        }
                    }
                }*/
                Debug.Log("enemy");
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos2D = new Vector2(mousePos.x, mousePos.y);

                attackAnim++;
                if (attackAnim > 1) attackAnim = 0;
                if (Vector2.Distance(transform.position, CharacterNotice.enemy.transform.position) < 1f)
                {
                    EnemyStatus.health -= demage;
                    //contack = true;
                    //attackChar(CharacterNotice.enemy.transform);
                }
            }
            if (attack == false)
            {
                if(Vector2.Distance(rbody.position, target) >= 0.05f && target != null)
                {
                    Vector2 inputVector = Vector2.ClampMagnitude((Vector2)(-(rbody.position - target)), 1);
                    //Vector2 movement = inputVector * movementSpeed;
                    //Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
                    isoRenderer.SetDirection(inputVector);
                    //rbody.MovePosition(newPos);
                    rbody.position = Vector2.MoveTowards(rbody.position, target, movementSpeed * Time.deltaTime);
                }
                else
                {
                    isoRenderer.idleAnimation();
                }
                
                //float horizontalInput = Input.GetAxis("Horizontal");
                //float verticalInput = Input.GetAxis("Vertical");
                //Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
                //Debug.Log(inputVector);
                //inputVector = Vector2.ClampMagnitude(inputVector, 1);
                
            }

            /*if (this.transform.Find("Canvas").gameObject.activeSelf)
            {
                if (Input.GetKeyDown(KeyCode.T))
                {
                    attack = true;
                }
            }*/
            if (attack == true)
            {
                //Debug.Log("serang cuy");
                Vector2 inputVector = Vector2.ClampMagnitude((-((Vector2)transform.position - mousePos2D)), 1);
                if (attackAnim == 0)
                {
                    isoRenderer.attack1Animation(inputVector);
                    //attackAnim++;
                }
                else
                {
                    isoRenderer.attack2Animation(inputVector);
                    //attackAnim=0;
                }
                
                //attack = false;
                /*Vector2 inputVector = Vector2.ClampMagnitude((Vector2)(-(transform.position - CharacterNotice.enemy.transform.position)), 1);
                /*//*/Vector2 inputVector = Vector2.ClampMagnitude((Vector2)(-(transform.position - Player.position)), 1);
                isoRenderer.SetDirection(inputVector);
                transform.position = Vector2.MoveTowards(transform.position, CharacterNotice.enemy.transform.position, 3.0f * Time.deltaTime);

                if (Vector2.Distance(transform.position, CharacterNotice.enemy.transform.position) < 1f)
                {
                    //contack = true;
                    attackChar(CharacterNotice.enemy.transform);
                }
                //transform.position = CharacterNotice.enemy.transform.position;
                Debug.Log("hai beb");*/
            }

            if (contack == true)
            {
                Vector2 inputVector = Vector2.ClampMagnitude((Vector2)(-(transform.position - CharacterNotice.enemy.transform.position)), 1);
                //Vector2 inputVector = Vector2.ClampMagnitude((Vector2)(-(transform.position - Player.position)), 1);
                isoRenderer.attack2Animation(inputVector);
                CharacterNotice.enemy.SetActive(false);
                target = rbody.position;
                attack = false;
                contack = false;
            }
        }
    }
    void attackChar(Transform Enemy)
    {
        Vector2 inputVector = Vector2.ClampMagnitude((Vector2)(-(transform.position - Enemy.position)), 1);
        if(attackAnim == 0)
        {
            isoRenderer.attack1Animation(inputVector);
            //attackAnim++;
        }
        else
        {
            isoRenderer.attack2Animation(inputVector);
            //attackAnim=0;
        }
        attackcount++;
        if (attackcount == 26)
        {
            EnemyStatus.health -= demage;
            attackcount = 0;
        }
        //Debug.Log(attackcount);
        //isoRenderer.SetDirection(inputVector);
    }
}
