using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Tutorial2 : MonoBehaviour {
    public TextMeshProUGUI instructionText;
    public GameObject arrows;
    float currTime;
    public float animationTime = 3f;
    bool instructionOver;

    // Start is called before the first frame update
    void Start() {
        currTime = animationTime;
        arrows.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (instructionOver && Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene(5);
        }

        currTime -= Time.deltaTime;
        if(currTime < 0) {
            if (!instructionOver) {
                instructionText.text = "A passive stone can move up to 2 spaces in any direction" +
                    "\nbut it can't push any stone nor jump over";
                arrows.SetActive(true);
                instructionOver = true;
                currTime = animationTime;
            } else {
                instructionText.text = "Click on the screen to check the next tutorial";
            }   
        }
    }
}
