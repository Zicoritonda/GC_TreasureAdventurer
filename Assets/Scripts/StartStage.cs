using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStage : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform point1;
    public Transform point2;
    public Transform cam;
    public GameObject mission;

    public bool start = true;

    void Start()
    {
        cam.position = new Vector3(point1.position.x, point1.position.y, cam.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(cam.position, new Vector3(point2.position.x, point2.position.y, cam.position.z)) > 0.1 && start)
        {
            cam.position = Vector3.MoveTowards(cam.position, new Vector3(point2.position.x,point2.position.y, cam.position.z), 2f * Time.deltaTime);
        }
        else
        {
            if(start == true) mission.SetActive(true);
            //start = false;
        }
    }

    public void clicked()
    {
        start = false;
        mission.SetActive(false);
    }
}
