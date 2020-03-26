using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QPathFinder
{
    public class CustomController : MonoBehaviour
    {
        public GameObject player;
        public float speed = 5.0f;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Debug.Log(string.Format("Co-ords of mouse is [X: {0} Y: {0}]", pos.x, pos.y));
            }
        }
    }

}