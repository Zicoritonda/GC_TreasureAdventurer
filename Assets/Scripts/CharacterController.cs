using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
                                CharacterNotice.enemy.GetComponent<EnemyStatus>().health -= demage;
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

            //Skill
            if (Input.GetKeyDown(KeyCode.Space) && CharacterStatus.skill == true)
            {
                if (CharacterStatus.item[0] != 0)
                {
                    Vector2 explosionPos = new Vector2(transform.position.x,transform.position.y);
                    Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionPos, 0.5f);
                    foreach (Collider2D hit in colliders)
                    {
                        Rigidbody2D rb = hit.GetComponent<Rigidbody2D>();
                        hit.gameObject.GetComponent<EnemyStatus>().health -= 5;
                        if (rb != null)
                            AddExplosionForceCustom(rb, 150.0f, explosionPos, 2.0f);
                        
                    }
                    //EnemyStatus.health -= 5;
                    CharacterStatus.skill = false;
                    Debug.Log("shock");
                }
            }

            //Item 1
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if(CharacterStatus.item[1] != 0)
                {
                    GameObject trap = new GameObject();
                    trap.transform.position = this.gameObject.transform.position;
                    trap.name = "Trap";
                    trap.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Item/" + CharacterStatus.item[1].ToString() + "_1");
                    trap.GetComponent<SpriteRenderer>().sortingLayerName = "Ground-0";
                    trap.GetComponent<SpriteRenderer>().sortingOrder = 2;
                    trap.AddComponent<CircleCollider2D>().isTrigger = true;
                    trap.GetComponent<CircleCollider2D>().radius = 0.05f;
                    trap.AddComponent<TrapStatus>().idtype = CharacterStatus.item[1];
                    GameObject.Find("item1").GetComponent<Image>().sprite = null;
                    CharacterStatus.item[1] = 0;
                }   
            }
            //Item 2
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (CharacterStatus.item[2] != 0)
                {
                    GameObject trap = new GameObject();
                    trap.transform.position = this.gameObject.transform.position;
                    trap.name = "Trap";
                    trap.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Item/" + CharacterStatus.item[1].ToString() + "_1");
                    trap.GetComponent<SpriteRenderer>().sortingLayerName = "Ground-0";
                    trap.GetComponent<SpriteRenderer>().sortingOrder = 2;
                    trap.AddComponent<CircleCollider2D>().isTrigger = true;
                    trap.GetComponent<CircleCollider2D>().radius = 0.05f;
                    trap.AddComponent<TrapStatus>().idtype = CharacterStatus.item[2];
                    GameObject.Find("item2").GetComponent<Image>().sprite = null;
                    CharacterStatus.item[2] = 0;
                }
            }
            //Item 3
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (CharacterStatus.item[3] != 0)
                {
                    GameObject trap = new GameObject();
                    trap.transform.position = this.gameObject.transform.position;
                    trap.name = "Trap";
                    trap.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Item/" + CharacterStatus.item[3].ToString() + "_1");
                    trap.GetComponent<SpriteRenderer>().sortingLayerName = "Ground-0";
                    trap.GetComponent<SpriteRenderer>().sortingOrder = 2;
                    trap.AddComponent<CircleCollider2D>().isTrigger = true;
                    trap.GetComponent<CircleCollider2D>().radius = 0.05f;
                    trap.AddComponent<TrapStatus>().idtype = CharacterStatus.item[3];
                    GameObject.Find("item3").GetComponent<Image>().sprite = null;
                    CharacterStatus.item[3] = 0;
                }
            }
            //Item 4
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (CharacterStatus.item[4] != 0)
                {
                    GameObject trap = new GameObject();
                    trap.transform.position = this.gameObject.transform.position;
                    trap.name = "Trap";
                    trap.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Item/" + CharacterStatus.item[4].ToString() + "_1");
                    trap.GetComponent<SpriteRenderer>().sortingLayerName = "Ground-0";
                    trap.GetComponent<SpriteRenderer>().sortingOrder = 2;
                    trap.AddComponent<CircleCollider2D>().isTrigger = true;
                    trap.GetComponent<CircleCollider2D>().radius = 0.05f;
                    trap.AddComponent<TrapStatus>().idtype = CharacterStatus.item[4];
                    GameObject.Find("item4").GetComponent<Image>().sprite = null;
                    CharacterStatus.item[4] = 0;
                }
            }

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

    void AddExplosionForceCustom(Rigidbody2D body, float explosionForce, Vector3 explosionPosition, float explosionRadius)
    {
        var dir = (body.transform.position - explosionPosition);
        float wearoff = 1 - (dir.magnitude / explosionRadius);
        body.AddForce(dir.normalized * explosionForce * wearoff);
    }
}
