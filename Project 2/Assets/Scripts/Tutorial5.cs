using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Tutorial5 : MonoBehaviour {
    public TextMeshProUGUI instructionText;
    public GameObject pasArrows, agrArrows, pasStone, agrStone, whiteStone;
    bool isPasSelected, isAgrSelected, instructionOver;

    // Start is called before the first frame update
    void Start() {
        pasArrows.SetActive(false);
        agrArrows.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if (instructionOver) {
                SceneManager.LoadScene(0);
            } else if (isAgrSelected) {
                pasStone.transform.position = new Vector3(6.6f, -0.21f, 2.3f);
                agrStone.transform.position = new Vector3(-4.38f, -0.21f, 6.3f);
                whiteStone.transform.position = new Vector3(-4.38f, -0.21f, 2.3f);
                pasArrows.SetActive(true);
                agrArrows.SetActive(true);
                instructionText.text = "4. The opponent player takes the turn." +
                    "\nClick on the screen to end the tutorial.";
                instructionOver = true;

            } else if (isPasSelected) {
                Vector3 agrStonePos = agrStone.transform.position;
                agrStone.transform.position = new Vector3(agrStonePos.x, agrStonePos.y + 1, agrStonePos.z);
                instructionText.text = "3. Select a position for passive move or aggressive move OR Deselect(drop)"
                    +"\nan aggressive stone.Click on the screen to check the next step.";
                isAgrSelected = true;

            } else {
                Vector3 pasStonePos = pasStone.transform.position;
                pasStone.transform.position = new Vector3(pasStonePos.x, pasStonePos.y + 1, pasStonePos.z);
                instructionText.text = "2. Select (pick up) an AGGRESSIVE stone OR Deselect(drop) a passive stone." +
                    "\nClick on the screen to check the next step.";
                isPasSelected = true;
            }
        }
        
    }
}
