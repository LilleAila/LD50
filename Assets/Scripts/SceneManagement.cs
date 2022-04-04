using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void loadScene(string scene) {
        Time.timeScale = 1;
        SceneManager.LoadScene(scene);
    }
}
