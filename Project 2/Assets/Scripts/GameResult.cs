using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameResult : MonoBehaviour {
    TextMeshProUGUI gameResult;

    // Start is called before the first frame update
    void Start() {
        gameResult = gameObject.GetComponent<TextMeshProUGUI>();
        gameResult.text = UIManager.result;
        
    }

    // Update is called once per frame
    void Update() {
        
    }
}
