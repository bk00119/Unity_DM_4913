using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Tutorial3 : MonoBehaviour {
    public TextMeshProUGUI instructionText;
    public GameObject pasArrows, pasMovArrows, agrArrows, pasStone;
    float currTime;
    public float animationTime = 3f;
    bool isPasMoved, instructionOver, animationOver;

    // Start is called before the first frame update
    void Start() {
        currTime = animationTime;
        pasMovArrows.SetActive(false);
        agrArrows.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (animationOver) {
            if (Input.GetMouseButtonDown(0)) {
                if (instructionOver) {
                    SceneManager.LoadScene(6);
                } else {
                    instructionText.text = "The aggressive move must be made in the same direction and number" +
                        "\nof spaces as the passive move. Click on the screen to check the next tutorial.";
                    instructionOver = true;
                }
            }
            

        } else {
            currTime -= Time.deltaTime;
            if (currTime < 0) {
                if (isPasMoved) {
                    agrArrows.SetActive(true);
                    instructionText.text = "The aggressive stone must be selected from any board with the opposite color." +
                        "\nClick on the screen to check the next step.";
                    animationOver = true;
                } else {
                    pasStone.transform.position = new Vector3(6.6f, -0.21f, 2.3f);
                    instructionText.text = "and moved...";
                    pasArrows.SetActive(false);
                    pasMovArrows.SetActive(true);
                    isPasMoved = true;
                    currTime = animationTime;
                }
            }
        }
    }
}
