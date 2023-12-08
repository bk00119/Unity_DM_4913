using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Tutorial5 : MonoBehaviour {
    public TextMeshProUGUI instructionText;
    public GameObject pasArrows, agrArrows, pasStone, agrStone, whiteStone;
    float currTime;
    public float animationTime = 3f;
    public float longAnimationTime = 5f;
    bool isPasSelected, isAgrSelected, isNewPosSelected, instructionOver;

    // Start is called before the first frame update
    void Start() {
        currTime = animationTime;
        pasArrows.SetActive(false);
        agrArrows.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if(instructionOver && Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene(0);
        } else {
            currTime -= Time.deltaTime;
            if (currTime < 0) {
                if (isNewPosSelected) {
                    instructionText.text = "Click on the screen to end the tutorial";
                    instructionOver = true;
                } else if (isAgrSelected) {
                    pasStone.transform.position = new Vector3(6.6f, -0.21f, 2.3f);
                    agrStone.transform.position = new Vector3(-4.38f, -0.21f, 6.3f);
                    whiteStone.transform.position = new Vector3(-4.38f, -0.21f, 2.3f);
                    pasArrows.SetActive(true);
                    agrArrows.SetActive(true);
                    instructionText.text = "4. The opponent player takes the turn";
                    isNewPosSelected = true;
                    currTime = animationTime;

                } else if (isPasSelected) {
                    Vector3 agrStonePos = agrStone.transform.position;
                    agrStone.transform.position = new Vector3(agrStonePos.x, agrStonePos.y + 1, agrStonePos.z);
                    instructionText.text = "3. Select a position for passive move or aggressive move" +
                        "\nOR Deselect(drop) an aggressive stone";
                    isAgrSelected = true;
                    currTime = longAnimationTime;

                } else {
                    Vector3 pasStonePos = pasStone.transform.position;
                    pasStone.transform.position = new Vector3(pasStonePos.x, pasStonePos.y + 1, pasStonePos.z);
                    instructionText.text = "2. Select (pick up) an AGGRESSIVE stone" +
                        "\nOR Deselect(drop) a passive stone";
                    isPasSelected = true;
                    currTime = longAnimationTime;
                }
            }
        }
        
    }
}
