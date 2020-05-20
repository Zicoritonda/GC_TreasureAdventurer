using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour
{
    public string sceneName;

    public void changeScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void reload()
    {
        Scene thisScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(thisScene.name);
    }

    public void selectStage()
    {
        if (StagesController.stageNow == sceneName || StagesController.stages[sceneName]) SceneManager.LoadScene(sceneName);
        if (StagesController.stageNow == sceneName || StagesController.castles[sceneName]) SceneManager.LoadScene(sceneName);
    }
}
