using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Tutorial4 : MonoBehaviour {
    public TextMeshProUGUI instructionText;
    float currTime;
    public float animationTime = 3f;
    bool instructionOver;

    // Start is called before the first frame update
    void Start() {
        currTime = animationTime;    
    }

    // Update is called once per frame
    void Update() {
        if (instructionOver && Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene(7);
        }
        currTime -= Time.deltaTime;
        if (currTime < 0) {
            instructionText.text = "Click on the screen to check the next tutorial";
            instructionOver = true;
        }
    }
}
