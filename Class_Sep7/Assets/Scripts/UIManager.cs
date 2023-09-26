using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour {
    TextMeshProUGUI playerScore;
    float score;

    // Start is called before the first frame update
    void Start() {
        playerScore = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update() {
        score += Time.deltaTime;
        playerScore.text = "Score: " + Mathf.RoundToInt(score).ToString();
    }
}
