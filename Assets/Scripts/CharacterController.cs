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
            if (attack == false)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    //currentPos = rbody.position;
                    target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }
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

            if (this.transform.Find("Canvas").gameObject.activeSelf)
            {
                if (Input.GetKeyDown(KeyCode.T))
                {
                    attack = true;
                }
            }

            if (attack == true)
            {
                Vector2 inputVector = Vector2.ClampMagnitude((Vector2)(-(transform.position - CharacterNotice.enemy.transform.position)), 1);
                //Vector2 inputVector = Vector2.ClampMagnitude((Vector2)(-(transform.position - Player.position)), 1);
                isoRenderer.attack1Animation(inputVector);
                transform.position = Vector2.MoveTowards(transform.position, CharacterNotice.enemy.transform.position, 3.0f * Time.deltaTime);

                if (Vector2.Distance(transform.position, CharacterNotice.enemy.transform.position) < 0.14f)
                {
                    contack = true;
                }
                //transform.position = CharacterNotice.enemy.transform.position;
                Debug.Log("hai beb");
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
}
