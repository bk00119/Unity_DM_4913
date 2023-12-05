using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Instruction : MonoBehaviour {
    static TextMeshProUGUI message;
    static string blackTurn = "Black's turn: \n";
    static string whiteTurn = "White's turn: \n";
    static string pasMsg = "Please pick up a passive stone";
    static string agrMsg = "Please pick up an aggressive stone";
    static string movMsg = "Please select a space to move stones";


    // Start is called before the first frame update
    void Start() {
        message = gameObject.GetComponent<TextMeshProUGUI>();
        message.text = blackTurn + pasMsg;
    }

    // Update is called once per frame
    void Update() {
        
    }

    static void SetTurnMsg() {
        if (Board.turn == 1) {
            message.text = whiteTurn;
        } else {
            message.text = blackTurn;
        }
    }

    public static void SetPasMsg() {
        SetTurnMsg();
        message.text += pasMsg;
    }

    public static void SetAgrMsg() {
        SetTurnMsg();
        message.text += agrMsg;
    }

    public static void SetMovMsg() {
        SetTurnMsg();
        message.text += movMsg;
    }

}
