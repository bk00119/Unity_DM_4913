using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Tutorial2 : MonoBehaviour {
    public TextMeshProUGUI instructionText;
    public GameObject arrows;
    bool instructionOver;

    // Start is called before the first frame update
    void Start() {
        arrows.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if (instructionOver) {
                SceneManager.LoadScene(5);
            } else {
                arrows.SetActive(true);
                instructionText.text = "A passive stone can move up to 2 spaces in any direction but it can't push" +
                    "\n any stone nor jump over. Click on the screen to check the next step.";
                instructionOver = true;
            }

        }
    }
}
