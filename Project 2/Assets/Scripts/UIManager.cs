using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour {
    TextMeshProUGUI gameResult;
    public static string result;

    // Start is called before the first frame update
    void Start() {
        gameResult = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        result = "";
    }

    // Update is called once per frame
    void Update() {
        gameResult.text = result;
    }
}
