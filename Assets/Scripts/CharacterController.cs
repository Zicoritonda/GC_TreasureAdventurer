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
    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<CharacterRenderer>();
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
        if(attack == false)
        {
            Vector2 currentPos = rbody.position;
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
            //Debug.Log(inputVector);
            inputVector = Vector2.ClampMagnitude(inputVector, 1);
            Vector2 movement = inputVector * movementSpeed;
            Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
            isoRenderer.SetDirection(movement);
            rbody.MovePosition(newPos);
        }
 
        if (this.transform.Find("Canvas").gameObject.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.E))
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

        if(contack == true)
        {
            Vector2 inputVector = Vector2.ClampMagnitude((Vector2)(-(transform.position - CharacterNotice.enemy.transform.position)), 1);
            //Vector2 inputVector = Vector2.ClampMagnitude((Vector2)(-(transform.position - Player.position)), 1);
            isoRenderer.attack2Animation(inputVector);
            CharacterNotice.enemy.SetActive(false);
            attack = false;
            contack = false;
        }
    }
}
