using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {
    public void StartGameScene() {
        SceneManager.LoadScene(1);
    }

    public void ToTitleMenuScene() {
        SceneManager.LoadScene(0);
    }

    public void StartTutorialScene() {
        SceneManager.LoadScene(3);
    }
}
