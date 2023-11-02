using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
    public void SwitchScenes(int sceneIndex)
    {
        GameManager.Singleton.GoToScene(sceneIndex);
    }
}
