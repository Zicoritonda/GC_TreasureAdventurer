using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public static string mapBefore = "SampleScene";
    public float movementSpeed = 1f;
    CharacterRenderer isoRenderer;

    Rigidbody2D rbody;
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

        if (this.transform.Find("Canvas").gameObject.activeSelf)
        {
            if(Input.GetKeyDown(KeyCode.E)){
                transform.position = Vector2.MoveTowards(transform.position, CharacterNotice.enemy.transform.position, Vector2.Distance(transform.position, CharacterNotice.enemy.transform.position));
                
                CharacterNotice.enemy.SetActive(false);
                //transform.position = CharacterNotice.enemy.transform.position;
                Debug.Log("hai beb");
            }
        }
    }
}
