using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour
{
    public string sceneName;

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(this.gameObject.name +" collided with " + col.name);
        SceneManager.LoadScene(sceneName);
    }
}
