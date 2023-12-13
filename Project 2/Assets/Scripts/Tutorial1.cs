using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Tutorial1 : MonoBehaviour {
    public GameObject black_1, black_2, white_1, white_2;
    bool isMove1Over, isMove2Over;
    float currTime;
    public float animationTime = 3f;
    public TextMeshProUGUI instructionText;

    // Start is called before the first frame update
    void Start() {
        currTime = animationTime;
    }

    // Update is called once per frame
    void Update() {
        if (isMove2Over && Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene(4);
        }
        currTime -= Time.deltaTime;
        if (currTime < 0) {
            if (!isMove1Over) {
                black_1.transform.position = new Vector3(-16.38f, -0.21f, 2.3f);
                Destroy(white_1);
                isMove1Over = true;
                currTime = animationTime;
            } else {
                black_2.transform.position = new Vector3(-4.38f, -0.21f, 6.3f);
                Destroy(white_2);
                isMove2Over = true;
                instructionText.text = "Black wins. Click on the screen to check the next tutorial";
            }
                
        }
        
    }
}
