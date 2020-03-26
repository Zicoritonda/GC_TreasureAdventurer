using System;
using System.Collections.Generic;
using UnityEngine;

namespace QPathFinder
{
    public class CustomMouseClick : MonoBehaviour
    {
        public Camera _camera;   // Needed for mouse click to world position convertion. 
        public float playerSpeed = 20.0f;
        public bool autoRotateTowardsDestination = true;
        public GameObject playerObj;


        // For PathFollowerWithGroundSnap - This will snap the player to the ground while it follows the path. 
        public float playerFloatOffset;     // This is how high the player floats above the ground. 
        public float raycastOriginOffset;   // This is how high above the player u want to raycast to ground. 
        public int raycastDistanceFromOrigin = 40;   // This is how high above the player u want to raycast to ground. 
        public bool thoroughPathFinding = false;    // uses few extra steps in pathfinding to find accurate result. 

        public bool useGroundSnap = false;          // if snap to ground is not used, player goes only through nodes and doesnt project itself on the ground. 

        public QPathFinder.Logger.Level debugLogLevel;
        public float debugDrawLineDuration;


        void Awake()
        {
            QPathFinder.Logger.SetLoggingLevel(debugLogLevel);
            QPathFinder.Logger.SetDebugDrawLineDuration(debugDrawLineDuration);

        }
        void Update()
        {
            //if()
            if (Input.GetMouseButtonUp(0))
            {
                /*RaycastHit hit;
                if (Physics2D.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    if (hit.collider == collider)
                    {
                        //Do your thing.
                    }
                }*/
                CastRay();
                //MovePlayerToMousePosition();
            }

        }

        void CastRay()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hit;
            hit = Physics.RaycastAll(ray, 100);
            if (hit.Length>0)
            {
                Debug.Log(hit.Length);
                Debug.Log("Hit object: " + hit[0].collider.tag);
                if (hit.Length == 1)
                {
                    MovePlayerToMousePosition(hit[0].point);
                }
            }
        }

        void MovePlayerToMousePosition(Vector3 point)
        {
            //Debug.LogError(PathFinder.instance.graphData.groundColliderLayerName + " " + LayerMask.NameToLayer( PathFinder.instance.graphData.groundColliderLayerName ));
            LayerMask backgroundLayerMask = 1 << LayerMask.NameToLayer(PathFinder.instance.graphData.groundColliderLayerName);

            //Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            //RaycastHit hit;
            Vector3 hitPos = point;
            /*if (Physics.Raycast(ray, out hit, 10000f, backgroundLayerMask))
            {
                hitPos = point;
            }
            else
            {
                Debug.LogError("ERROR!");
                return;
            }*/

            {
                PathFinder.instance.FindShortestPathOfPoints(playerObj.transform.position, hitPos, PathFinder.instance.graphData.lineType,
                    Execution.Asynchronously,
                    thoroughPathFinding ? SearchMode.Complex : SearchMode.Simple,
                    delegate (List<Vector3> points)
                    {
                        PathFollowerUtility.StopFollowing(playerObj.transform);
                        if (useGroundSnap)
                        {
                            FollowThePathWithGroundSnap(points);
                        }
                        else
                            FollowThePathNormally(points);

                    }
                 );
            }
        }

        void FollowThePathWithGroundSnap(List<Vector3> nodes)
        {
            PathFollowerUtility.FollowPathWithGroundSnap(playerObj.transform,
                                                        nodes,
                                                        playerSpeed,
                                                        autoRotateTowardsDestination,
                                                        Vector3.down, playerFloatOffset, LayerMask.NameToLayer(PathFinder.instance.graphData.groundColliderLayerName),
                                                        raycastOriginOffset, raycastDistanceFromOrigin);
        }

        void FollowThePathNormally(List<Vector3> nodes)
        {
            PathFollowerUtility.FollowPath(playerObj.transform, nodes, playerSpeed, autoRotateTowardsDestination);
        }
    }
}
