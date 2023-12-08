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
    public float longAnimationTime = 5f;
    bool isPasMoved, isAgrArrowsShowed, showLastInstruction, instructionOver;

    // Start is called before the first frame update
    void Start() {
        currTime = animationTime;
        //pasArrows.SetActive(false);
        pasMovArrows.SetActive(false);
        agrArrows.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (instructionOver && Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene(6);
        } else {
            currTime -= Time.deltaTime;
            if (currTime < 0) {
                if (showLastInstruction) {
                    instructionText.text = "Click on the screen to check the next tutorial";
                    instructionOver = true;
                } else if (isAgrArrowsShowed) {
                    instructionText.text = "The aggressive move must be made in the same" +
                        "\ndirection and number of spaces as the passive move";
                    showLastInstruction = true;
                    currTime = longAnimationTime;
                } else if (isPasMoved) {
                    agrArrows.SetActive(true);
                    instructionText.text = "The aggressive stone must be selected" +
                        "\nfrom any board with the opposite color";
                    isAgrArrowsShowed = true;
                    currTime = longAnimationTime;

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
