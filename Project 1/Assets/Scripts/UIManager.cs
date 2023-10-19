using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour {
    TextMeshProUGUI playerScore;
    public static float score;

    public static float highScore;

    // Start is called before the first frame update
    void Start() {
        playerScore = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        score = 0;
    }

    // Update is called once per frame
    void Update() {
        score += Time.deltaTime;
        highScore = score;
        playerScore.text = "Score: " + Mathf.RoundToInt(score).ToString();
    }
}
