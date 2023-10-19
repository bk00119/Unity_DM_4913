using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour {
    TextMeshProUGUI score;


    // Start is called before the first frame update
    void Start() {
        score = gameObject.GetComponent<TextMeshProUGUI>();
        score.text = Mathf.RoundToInt(UIManager.highScore).ToString();
    }

    // Update is called once per frame
    void Update() {
        
    }
}
