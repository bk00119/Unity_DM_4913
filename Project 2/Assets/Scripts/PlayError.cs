using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayError : MonoBehaviour {
    static TextMeshProUGUI message;
    static string pasOpponentSelectError = "Error: You must select your stone for a passive move";
    static string pasBoardSelectError = "Error: The passive stone must be selected from your side";
    static string agrOpponentSelectError = "Error: You must select your stone for an aggressive move";
    static string agrBoardSelectError = "Error: The aggressive stone must be selected from the different color of the board";
    static string movSamePosError = "Error: Your stones must move";
    static string movBoardError = "Error: The move must be made from one of your selected stone's board";
    static string movOverTwoError = "Error: The move must be less than 2";
    static string movDiagonalError = "Error: The diagonal move must have the same horizontal move and vertical move";
    static string movBoardPosOBError = "Error: The stone position is out of bounds (Board)";
    static string movBoardRowOBError = "Error: The stone position is out of bounds (Row)";
    static string movBoardColOBError = "Error: The stone position is out of bounds (Column)";
    static string movPasPushError = "Error: The passive stone can't push any stone";
    static string movAgrPushAllyError = "Error: The aggressive stone can't push any ally stones";
    static string movAgrPushTwoError = "Error: The aggresive stone can't push two enemy stones";
    static string movBoardWithNoStoneError = "Error: The new move position is made from the board where no stone is selected on";



    // Start is called before the first frame update
    void Start() {
        message = gameObject.GetComponent<TextMeshProUGUI>();
        message.text = "";
    }

    // Update is called once per frame
    void Update() {
        
    }

    public static void Reset() {
        message.text = "";
    }

    public static void SetPasOpponentSelectError() {
        message.text = pasOpponentSelectError;
    }

    public static void SetPasBoardSelectError() {
        message.text = pasBoardSelectError;
    }

    public static void SetAgrOpponentSelectError() {
        message.text = agrOpponentSelectError;
    }

    public static void SetAgrBoardSelectError() {
        message.text = agrBoardSelectError;
    }

    public static void SetMovSamePosError() {
        message.text = movSamePosError;
    }

    public static void SetMovBoardError() {
        message.text = movBoardError;
    }

    public static void SetMovOverTwoError() {
        message.text = movOverTwoError;
    }

    public static void SetMovDiagonalError() {
        message.text = movDiagonalError;
    }

    public static void SetMovBoardPosOBError() {
        message.text = movBoardPosOBError;
    }

    public static void SetMovBoardRowOBError() {
        message.text = movBoardRowOBError;
    }

    public static void SetMovBoardColOBError() {
        message.text = movBoardColOBError;
    }

    public static void SetMovPasPushError() {
        message.text = movPasPushError;
    }

    public static void SetMovAgrPushAllyError() {
        message.text = movAgrPushAllyError;
    }

    public static void SetMovAgrPushTwoError() {
        message.text = movAgrPushTwoError;
    }

    public static void SetMovBoardWithNoStoneError() {
        message.text = movBoardWithNoStoneError;
    }
}
