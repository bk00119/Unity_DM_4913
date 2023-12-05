using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    //public int turn;
    public static bool rotateCamera;
    public float transitionDuration = 3f;
    float elapsedTime = 0f;

    Vector3 blackCamPos = new Vector3(0.6f, 22, 19);
    Quaternion blackCamRot = Quaternion.Euler(59, 180, 0);
    Vector3 whiteCamPos = new Vector3(0.6f, 22, -18);
    Quaternion whiteCamRot = Quaternion.Euler(121, 180, 180);


    // Start is called before the first frame update
    void Start() {
        //turn = 0;
    }

    // Update is called once per frame
    void Update() {
        if (rotateCamera) {
            // Update the elapsed time
            elapsedTime += Time.deltaTime;

            if (Board.turn == 1) {
                // Black's turn is over
                RotateAndMoveCamera(1, blackCamPos, whiteCamPos, blackCamRot, whiteCamRot);

            } else {
                // White's turn is over
                RotateAndMoveCamera(0, whiteCamPos, blackCamPos, whiteCamRot, blackCamRot);
                
            }
        }

    }

    private void RotateAndMoveCamera(int newTurn, Vector3 posA, Vector3 posB, Quaternion rotA, Quaternion rotB) {
        // Calculate the interpolation factor based on elapsed time and transition duration
        float t = Mathf.Clamp01(elapsedTime / transitionDuration);

        // Lerp between blackCamPos and whiteCamPos
        transform.position = Vector3.Lerp(posA, posB, t);

        // Slerp between blackCamRot and whiteCamRot
        transform.rotation = Quaternion.Slerp(rotA, rotB, t);

        // Check if the transition is complete
        if (t >= 1f) {
            // Set the final position and rotation
            transform.position = posB;
            transform.rotation = rotB;

            rotateCamera = false;

            //Board.turn = newTurn;
            elapsedTime = 0f;
        }
    }

}
