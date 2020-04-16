using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavWithCollider : MonoBehaviour
{
    public string sceneName;
    public string colliderName;

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(this.gameObject.name + " collided with " + col.name);
        if(col.name == colliderName)
        {
            CharacterController.mapBefore = SceneManager.GetActiveScene().name;
            //Debug.Log()
            SceneManager.LoadScene(sceneName);
        }

    }
}
