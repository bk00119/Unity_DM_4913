using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    //public int turn;
    public static bool rotateCamera;
    // Start is called before the first frame update
    void Start() {
        //turn = 0;
    }

    // Update is called once per frame
    void Update() {
        if (rotateCamera) {
            if (Board.turn == 0) {
                // Black's turn is over
                Board.turn = 1;

                // CHANGE THE CAMERA POSITION AND ROTATE
                transform.position = new Vector3(0.6f, 22, -18);
                transform.rotation = Quaternion.Euler(121, 180, 180);

            } else {
                // White's turn is over
                Board.turn = 0;

                // CHANGE THE CAMERA POSITION AND ROTATE
                transform.position = new Vector3(0.6f, 22, 19);
                transform.rotation = Quaternion.Euler(59, 180, 0);

            }
            rotateCamera = false;
        }

    }

}
