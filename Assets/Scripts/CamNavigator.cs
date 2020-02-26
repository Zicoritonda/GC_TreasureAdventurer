using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamNavigator : MonoBehaviour
{
    //public Camera cam;
    public Transform target;
    // Start is called before the first frame update

    void Start()
    {
    }

    void Update()
    {
        //Vector3 direction = target.position - transform.position;
 

        //transform.position = transform.position + direction;

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //transform.eulerAngles = cam.transform.eulerAngles + new Vector3(0,90,0);
            Vector3 direct = target.position - transform.position;
            float dist = Vector3.Distance(target.position, transform.position);

            //transform.position = target.position;
            transform.Translate(transform.forward + direct);
            transform.Translate(transform.right + direct);
            //direct.
            //transform.position = transform.position + new Vector3(dist, 0, 0);
            transform.LookAt(target);
        }
        /*else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            cam.transform.eulerAngles = cam.transform.eulerAngles + new Vector3(0, -90, 0);
        }*/
    }
}
