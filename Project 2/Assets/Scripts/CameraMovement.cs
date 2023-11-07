using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public GameObject[] StoneType = new GameObject[3];
    GameObject[,,] Stones;
    int[,,] BoardPos;
    int Turn = 0;  // 0: Black, 1: Black moving pos, 2: White, 3: White moving pos
    
  
    // Start is called before the first frame update
    void Start() {
        Stones = new GameObject[4, 4, 4] {
            // Board 1 (Top-Right)
            {
                {
                    Instantiate(StoneType[1], new Vector3(-4.38f, -0.21f, -16.6f), Quaternion.identity),
                    Instantiate(StoneType[1], new Vector3(-8.38f, -0.21f, -16.6f), Quaternion.identity),
                    Instantiate(StoneType[1], new Vector3(-12.38f, -0.21f, -16.6f), Quaternion.identity),
                    Instantiate(StoneType[1], new Vector3(-16.38f, -0.21f, -16.6f), Quaternion.identity),
                },
                {
                    Instantiate(StoneType[0], new Vector3(-4.38f, -0.21f, -12.6f), Quaternion.identity),
                    Instantiate(StoneType[0], new Vector3(-8.38f, -0.21f, -12.6f), Quaternion.identity),
                    Instantiate(StoneType[0], new Vector3(-12.38f, -0.21f, -12.6f), Quaternion.identity),
                    Instantiate(StoneType[0], new Vector3(-16.38f, -0.21f, -12.6f), Quaternion.identity),
                },
                {
                    Instantiate(StoneType[0], new Vector3(-4.38f, -0.21f, -8.6f), Quaternion.identity),
                    Instantiate(StoneType[0], new Vector3(-8.38f, -0.21f, -8.6f), Quaternion.identity),
                    Instantiate(StoneType[0], new Vector3(-12.38f, -0.21f, -8.6f), Quaternion.identity),
                    Instantiate(StoneType[0], new Vector3(-16.38f, -0.21f, -8.6f), Quaternion.identity),
                },
                {
                    Instantiate(StoneType[2], new Vector3(-4.38f, -0.21f, -4.6f), Quaternion.identity),
                    Instantiate(StoneType[2], new Vector3(-8.38f, -0.21f, -4.6f), Quaternion.identity),
                    Instantiate(StoneType[2], new Vector3(-12.38f, -0.21f, -4.6f), Quaternion.identity),
                    Instantiate(StoneType[2], new Vector3(-16.38f, -0.21f, -4.6f), Quaternion.identity),
                }
            },
            // Board 2 (Top-Left)
            {
                {
                    Instantiate(StoneType[1], new Vector3(14.6f, -0.21f, -16.6f), Quaternion.identity),
                    Instantiate(StoneType[1], new Vector3(10.6f, -0.21f, -16.6f), Quaternion.identity),
                    Instantiate(StoneType[1], new Vector3(6.6f, -0.21f, -16.6f), Quaternion.identity),
                    Instantiate(StoneType[1], new Vector3(2.6f, -0.21f, -16.6f), Quaternion.identity),
                },
                {
                    Instantiate(StoneType[0], new Vector3(14.6f, -0.21f, -12.6f), Quaternion.identity),
                    Instantiate(StoneType[0], new Vector3(10.6f, -0.21f, -12.6f), Quaternion.identity),
                    Instantiate(StoneType[0], new Vector3(6.6f, -0.21f, -12.6f), Quaternion.identity),
                    Instantiate(StoneType[0], new Vector3(2.6f, -0.21f, -12.6f), Quaternion.identity),
                },
                {
                    Instantiate(StoneType[0], new Vector3(14.6f, -0.21f, -8.6f), Quaternion.identity),
                    Instantiate(StoneType[0], new Vector3(10.6f, -0.21f, -8.6f), Quaternion.identity),
                    Instantiate(StoneType[0], new Vector3(6.6f, -0.21f, -8.6f), Quaternion.identity),
                    Instantiate(StoneType[0], new Vector3(2.6f, -0.21f, -8.6f), Quaternion.identity),
                },
                {
                    Instantiate(StoneType[2], new Vector3(14.6f, -0.21f, -4.6f), Quaternion.identity),
                    Instantiate(StoneType[2], new Vector3(10.6f, -0.21f, -4.6f), Quaternion.identity),
                    Instantiate(StoneType[2], new Vector3(6.6f, -0.21f, -4.6f), Quaternion.identity),
                    Instantiate(StoneType[2], new Vector3(2.6f, -0.21f, -4.6f), Quaternion.identity),
                }
            },
            // Board 3 (Bottom-Left)
            {
                {
                    Instantiate(StoneType[1], new Vector3(14.6f, -0.21f, 2.3f), Quaternion.identity),
                    Instantiate(StoneType[1], new Vector3(10.6f, -0.21f, 2.3f), Quaternion.identity),
                    Instantiate(StoneType[1], new Vector3(6.6f, -0.21f, 2.3f), Quaternion.identity),
                    Instantiate(StoneType[1], new Vector3(2.6f, -0.21f, 2.3f), Quaternion.identity),
                },
                {
                    Instantiate(StoneType[0], new Vector3(14.6f, -0.21f, 6.3f), Quaternion.identity),
                    Instantiate(StoneType[0], new Vector3(10.6f, -0.21f, 6.3f), Quaternion.identity),
                    Instantiate(StoneType[0], new Vector3(6.6f, -0.21f, 6.3f), Quaternion.identity),
                    Instantiate(StoneType[0], new Vector3(2.6f, -0.21f, 6.3f), Quaternion.identity),
                },
                {
                    Instantiate(StoneType[0], new Vector3(14.6f, -0.21f, 10.3f), Quaternion.identity),
                    Instantiate(StoneType[0], new Vector3(10.6f, -0.21f, 10.3f), Quaternion.identity),
                    Instantiate(StoneType[0], new Vector3(6.6f, -0.21f, 10.3f), Quaternion.identity),
                    Instantiate(StoneType[0], new Vector3(2.6f, -0.21f, 10.3f), Quaternion.identity),
                },
                {
                    Instantiate(StoneType[2], new Vector3(14.6f, -0.21f, 14.3f), Quaternion.identity),
                    Instantiate(StoneType[2], new Vector3(10.6f, -0.21f, 14.3f), Quaternion.identity),
                    Instantiate(StoneType[2], new Vector3(6.6f, -0.21f, 14.3f), Quaternion.identity),
                    Instantiate(StoneType[2], new Vector3(2.6f, -0.21f, 14.3f), Quaternion.identity),
                }
            },
            //Board 4 (Bottom-Right)
            {
                {
                    Instantiate(StoneType[1], new Vector3(-4.38f, -0.21f, 2.3f), Quaternion.identity),
                    Instantiate(StoneType[1], new Vector3(-8.38f, -0.21f, 2.3f), Quaternion.identity),
                    Instantiate(StoneType[1], new Vector3(-12.38f, -0.21f, 2.3f), Quaternion.identity),
                    Instantiate(StoneType[1], new Vector3(-16.38f, -0.21f, 2.3f), Quaternion.identity),
                },
                {
                    Instantiate(StoneType[0], new Vector3(-4.38f, -0.21f, 6.3f), Quaternion.identity),
                    Instantiate(StoneType[0], new Vector3(-8.38f, -0.21f, 6.3f), Quaternion.identity),
                    Instantiate(StoneType[0], new Vector3(-12.38f, -0.21f, 6.3f), Quaternion.identity),
                    Instantiate(StoneType[0], new Vector3(-16.38f, -0.21f, 6.3f), Quaternion.identity),
                },
                {
                    Instantiate(StoneType[0], new Vector3(-4.38f, -0.21f, 10.3f), Quaternion.identity),
                    Instantiate(StoneType[0], new Vector3(-8.38f, -0.21f, 10.3f), Quaternion.identity),
                    Instantiate(StoneType[0], new Vector3(-12.38f, -0.21f, 10.3f), Quaternion.identity),
                    Instantiate(StoneType[0], new Vector3(-16.38f, -0.21f, 10.3f), Quaternion.identity),
                },
                {
                    Instantiate(StoneType[2], new Vector3(-4.38f, -0.21f, 14.3f), Quaternion.identity),
                    Instantiate(StoneType[2], new Vector3(-8.38f, -0.21f, 14.3f), Quaternion.identity),
                    Instantiate(StoneType[2], new Vector3(-12.38f, -0.21f, 14.3f), Quaternion.identity),
                    Instantiate(StoneType[2], new Vector3(-16.38f, -0.21f, 14.3f), Quaternion.identity),
                }
            }
        };

        BoardPos = new int[4, 4, 4] {
            {
                { 1, 1, 1, 1 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 2, 2, 2, 2 }
            },
            {
                { 1, 1, 1, 1 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 2, 2, 2, 2 }
            },
            {
                { 1, 1, 1, 1 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 2, 2, 2, 2 }
            },
            {
                { 1, 1, 1, 1 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 2, 2, 2, 2 }
            }
        };
    }

    // Update is called once per frame
    void Update() {
        if(Turn == 0) {

        } else if(Turn == 1) {

        } else if(Turn == 2) {

        } else { // Turn == 3

        }
        
    }
}
