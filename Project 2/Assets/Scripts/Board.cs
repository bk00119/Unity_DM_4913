using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {
    public Stone[] stoneType = new Stone[2]; // 0: Black Stone, 1: White Stone
    public Selector selector;
    public static Selector[,,] selectors;

    public static Selector pasStone, agrStone, newPos; // newPasPos, newAgrPos;
    public static Vector3 pasPos, agrPos;

    public static Player blackPlayer, whitePlayer;
    public static int turn = 0; // 0: black, 1: white

    // Start is called before the first frame update 
    void Start() {
        selectors = new Selector[4, 4, 4] {
            // Board 1 (Top-Right: from Black Player's viewpoint)
            {
                {
                    Instantiate(selector, new Vector3(-4.38f, -0.21f, -16.6f), Quaternion.identity),
                    Instantiate(selector, new Vector3(-8.38f, -0.21f, -16.6f), Quaternion.identity),
                    Instantiate(selector, new Vector3(-12.38f, -0.21f, -16.6f), Quaternion.identity),
                    Instantiate(selector, new Vector3(-16.38f, -0.21f, -16.6f), Quaternion.identity)
                },
                {
                    Instantiate(selector, new Vector3(-4.38f, -0.21f, -12.6f), Quaternion.identity),
                    Instantiate(selector, new Vector3(-8.38f, -0.21f, -12.6f), Quaternion.identity),
                    Instantiate(selector, new Vector3(-12.38f, -0.21f, -12.6f), Quaternion.identity),
                    Instantiate(selector, new Vector3(-16.38f, -0.21f, -12.6f), Quaternion.identity),
                },
                {
                    Instantiate(selector, new Vector3(-4.38f, -0.21f, -8.6f), Quaternion.identity),
                    Instantiate(selector, new Vector3(-8.38f, -0.21f, -8.6f), Quaternion.identity),
                    Instantiate(selector, new Vector3(-12.38f, -0.21f, -8.6f), Quaternion.identity),
                    Instantiate(selector, new Vector3(-16.38f, -0.21f, -8.6f), Quaternion.identity),
                },
                {
                    Instantiate(selector, new Vector3(-4.38f, -0.21f, -4.6f), Quaternion.identity),
                    Instantiate(selector, new Vector3(-8.38f, -0.21f, -4.6f), Quaternion.identity),
                    Instantiate(selector, new Vector3(-12.38f, -0.21f, -4.6f), Quaternion.identity),
                    Instantiate(selector, new Vector3(-16.38f, -0.21f, -4.6f), Quaternion.identity),
                }
            },
            // Board 2 (Top-Left)
            {
                {
                    Instantiate(selector, new Vector3(14.6f, -0.21f, -16.6f), Quaternion.identity),
                    Instantiate(selector, new Vector3(10.6f, -0.21f, -16.6f), Quaternion.identity),
                    Instantiate(selector, new Vector3(6.6f, -0.21f, -16.6f), Quaternion.identity),
                    Instantiate(selector, new Vector3(2.6f, -0.21f, -16.6f), Quaternion.identity),
                },
                {
                    Instantiate(selector, new Vector3(14.6f, -0.21f, -12.6f), Quaternion.identity),
                    Instantiate(selector, new Vector3(10.6f, -0.21f, -12.6f), Quaternion.identity),
                    Instantiate(selector, new Vector3(6.6f, -0.21f, -12.6f), Quaternion.identity),
                    Instantiate(selector, new Vector3(2.6f, -0.21f, -12.6f), Quaternion.identity),
                },
                {
                    Instantiate(selector, new Vector3(14.6f, -0.21f, -8.6f), Quaternion.identity),
                    Instantiate(selector, new Vector3(10.6f, -0.21f, -8.6f), Quaternion.identity),
                    Instantiate(selector, new Vector3(6.6f, -0.21f, -8.6f), Quaternion.identity),
                    Instantiate(selector, new Vector3(2.6f, -0.21f, -8.6f), Quaternion.identity),
                },
                {
                    Instantiate(selector, new Vector3(14.6f, -0.21f, -4.6f), Quaternion.identity),
                    Instantiate(selector, new Vector3(10.6f, -0.21f, -4.6f), Quaternion.identity),
                    Instantiate(selector, new Vector3(6.6f, -0.21f, -4.6f), Quaternion.identity),
                    Instantiate(selector, new Vector3(2.6f, -0.21f, -4.6f), Quaternion.identity),
                }
            },
            // Board 3 (Bottom-Left)
            {
                {
                    Instantiate(selector, new Vector3(14.6f, -0.21f, 2.3f), Quaternion.identity),
                    Instantiate(selector, new Vector3(10.6f, -0.21f, 2.3f), Quaternion.identity),
                    Instantiate(selector, new Vector3(6.6f, -0.21f, 2.3f), Quaternion.identity),
                    Instantiate(selector, new Vector3(2.6f, -0.21f, 2.3f), Quaternion.identity),
                },
                {
                    Instantiate(selector, new Vector3(14.6f, -0.21f, 6.3f), Quaternion.identity),
                    Instantiate(selector, new Vector3(10.6f, -0.21f, 6.3f), Quaternion.identity),
                    Instantiate(selector, new Vector3(6.6f, -0.21f, 6.3f), Quaternion.identity),
                    Instantiate(selector, new Vector3(2.6f, -0.21f, 6.3f), Quaternion.identity),
                },
                {
                    Instantiate(selector, new Vector3(14.6f, -0.21f, 10.3f), Quaternion.identity),
                    Instantiate(selector, new Vector3(10.6f, -0.21f, 10.3f), Quaternion.identity),
                    Instantiate(selector, new Vector3(6.6f, -0.21f, 10.3f), Quaternion.identity),
                    Instantiate(selector, new Vector3(2.6f, -0.21f, 10.3f), Quaternion.identity),
                },
                {
                    Instantiate(selector, new Vector3(14.6f, -0.21f, 14.3f), Quaternion.identity),
                    Instantiate(selector, new Vector3(10.6f, -0.21f, 14.3f), Quaternion.identity),
                    Instantiate(selector, new Vector3(6.6f, -0.21f, 14.3f), Quaternion.identity),
                    Instantiate(selector, new Vector3(2.6f, -0.21f, 14.3f), Quaternion.identity),
                }
            },
            //Board 4 (Bottom-Right)
            {
                {
                    Instantiate(selector, new Vector3(-4.38f, -0.21f, 2.3f), Quaternion.identity),
                    Instantiate(selector, new Vector3(-8.38f, -0.21f, 2.3f), Quaternion.identity),
                    Instantiate(selector, new Vector3(-12.38f, -0.21f, 2.3f), Quaternion.identity),
                    Instantiate(selector, new Vector3(-16.38f, -0.21f, 2.3f), Quaternion.identity),
                },
                {
                    Instantiate(selector, new Vector3(-4.38f, -0.21f, 6.3f), Quaternion.identity),
                    Instantiate(selector, new Vector3(-8.38f, -0.21f, 6.3f), Quaternion.identity),
                    Instantiate(selector, new Vector3(-12.38f, -0.21f, 6.3f), Quaternion.identity),
                    Instantiate(selector, new Vector3(-16.38f, -0.21f, 6.3f), Quaternion.identity),
                },
                {
                    Instantiate(selector, new Vector3(-4.38f, -0.21f, 10.3f), Quaternion.identity),
                    Instantiate(selector, new Vector3(-8.38f, -0.21f, 10.3f), Quaternion.identity),
                    Instantiate(selector, new Vector3(-12.38f, -0.21f, 10.3f), Quaternion.identity),
                    Instantiate(selector, new Vector3(-16.38f, -0.21f, 10.3f), Quaternion.identity),
                },
                {
                    Instantiate(selector, new Vector3(-4.38f, -0.21f, 14.3f), Quaternion.identity),
                    Instantiate(selector, new Vector3(-8.38f, -0.21f, 14.3f), Quaternion.identity),
                    Instantiate(selector, new Vector3(-12.38f, -0.21f, 14.3f), Quaternion.identity),
                    Instantiate(selector, new Vector3(-16.38f, -0.21f, 14.3f), Quaternion.identity),
                }
            }
        };

        // BOARD 1(0)
        // White Stones
        selectors[0, 0, 0].stone = Instantiate(stoneType[1], new Vector3(-4.38f, -0.21f, -16.6f), Quaternion.identity);
        selectors[0, 0, 0].stone.color = 1;

        selectors[0, 0, 1].stone = Instantiate(stoneType[1], new Vector3(-8.38f, -0.21f, -16.6f), Quaternion.identity);
        selectors[0, 0, 1].stone.color = 1;

        selectors[0, 0, 2].stone = Instantiate(stoneType[1], new Vector3(-12.38f, -0.21f, -16.6f), Quaternion.identity);
        selectors[0, 0, 2].stone.color = 1;

        selectors[0, 0, 3].stone = Instantiate(stoneType[1], new Vector3(-16.38f, -0.21f, -16.6f), Quaternion.identity);
        selectors[0, 0, 3].stone.color = 1;

        // Black stones
        selectors[0, 3, 0].stone = Instantiate(stoneType[0], new Vector3(-4.38f, -0.21f, -4.6f), Quaternion.identity);
        selectors[0, 3, 0].stone.color = 0;

        selectors[0, 3, 1].stone = Instantiate(stoneType[0], new Vector3(-8.38f, -0.21f, -4.6f), Quaternion.identity);
        selectors[0, 3, 1].stone.color = 0;

        selectors[0, 3, 2].stone = Instantiate(stoneType[0], new Vector3(-12.38f, -0.21f, -4.6f), Quaternion.identity);
        selectors[0, 3, 2].stone.color = 0;

        selectors[0, 3, 3].stone = Instantiate(stoneType[0], new Vector3(-16.38f, -0.21f, -4.6f), Quaternion.identity);
        selectors[0, 3, 3].stone.color = 0;

        // BOARD 2(1)
        // White Stones
        selectors[1, 0, 0].stone = Instantiate(stoneType[1], new Vector3(14.6f, -0.21f, -16.6f), Quaternion.identity);
        selectors[1, 0, 0].stone.color = 1;

        selectors[1, 0, 1].stone = Instantiate(stoneType[1], new Vector3(10.6f, -0.21f, -16.6f), Quaternion.identity);
        selectors[1, 0, 1].stone.color = 1;

        selectors[1, 0, 2].stone = Instantiate(stoneType[1], new Vector3(6.6f, -0.21f, -16.6f), Quaternion.identity);
        selectors[1, 0, 2].stone.color = 1;

        selectors[1, 0, 3].stone = Instantiate(stoneType[1], new Vector3(2.6f, -0.21f, -16.6f), Quaternion.identity);
        selectors[1, 0, 3].stone.color = 1;

        // Black Stones
        selectors[1, 3, 0].stone = Instantiate(stoneType[0], new Vector3(14.6f, -0.21f, -4.6f), Quaternion.identity);
        selectors[1, 3, 0].stone.color = 0;

        selectors[1, 3, 1].stone = Instantiate(stoneType[0], new Vector3(10.6f, -0.21f, -4.6f), Quaternion.identity);
        selectors[1, 3, 1].stone.color = 0;

        selectors[1, 3, 2].stone = Instantiate(stoneType[0], new Vector3(6.6f, -0.21f, -4.6f), Quaternion.identity);
        selectors[1, 3, 2].stone.color = 0;

        selectors[1, 3, 3].stone = Instantiate(stoneType[0], new Vector3(2.6f, -0.21f, -4.6f), Quaternion.identity);
        selectors[1, 3, 3].stone.color = 0;

        // BOARD 3(2)
        // White Stones
        selectors[2, 0, 0].stone = Instantiate(stoneType[1], new Vector3(14.6f, -0.21f, 2.3f), Quaternion.identity);
        selectors[2, 0, 0].stone.color = 1;

        selectors[2, 0, 1].stone = Instantiate(stoneType[1], new Vector3(10.6f, -0.21f, 2.3f), Quaternion.identity);
        selectors[2, 0, 1].stone.color = 1;

        selectors[2, 0, 2].stone = Instantiate(stoneType[1], new Vector3(6.6f, -0.21f, 2.3f), Quaternion.identity);
        selectors[2, 0, 2].stone.color = 1;

        selectors[2, 0, 3].stone = Instantiate(stoneType[1], new Vector3(2.6f, -0.21f, 2.3f), Quaternion.identity);
        selectors[2, 0, 3].stone.color = 1;

        // Black Stones
        selectors[2, 3, 0].stone = Instantiate(stoneType[0], new Vector3(14.6f, -0.21f, 14.3f), Quaternion.identity);
        selectors[2, 3, 0].stone.color = 0;

        selectors[2, 3, 1].stone = Instantiate(stoneType[0], new Vector3(10.6f, -0.21f, 14.3f), Quaternion.identity);
        selectors[2, 3, 1].stone.color = 0;

        selectors[2, 3, 2].stone = Instantiate(stoneType[0], new Vector3(6.6f, -0.21f, 14.3f), Quaternion.identity);
        selectors[2, 3, 2].stone.color = 0;

        selectors[2, 3, 3].stone = Instantiate(stoneType[0], new Vector3(2.6f, -0.21f, 14.3f), Quaternion.identity);
        selectors[2, 3, 3].stone.color = 0;

        // BOARD 4(3)
        // White Stones
        selectors[3, 0, 0].stone = Instantiate(stoneType[1], new Vector3(-4.38f, -0.21f, 2.3f), Quaternion.identity);
        selectors[3, 0, 0].stone.color = 1;

        selectors[3, 0, 1].stone = Instantiate(stoneType[1], new Vector3(-8.38f, -0.21f, 2.3f), Quaternion.identity);
        selectors[3, 0, 1].stone.color = 1;

        selectors[3, 0, 2].stone = Instantiate(stoneType[1], new Vector3(-12.38f, -0.21f, 2.3f), Quaternion.identity);
        selectors[3, 0, 2].stone.color = 1;

        selectors[3, 0, 3].stone = Instantiate(stoneType[1], new Vector3(-16.38f, -0.21f, 2.3f), Quaternion.identity);
        selectors[3, 0, 3].stone.color = 1;

        // Black Stones
        selectors[3, 3, 0].stone = Instantiate(stoneType[0], new Vector3(-4.38f, -0.21f, 14.3f), Quaternion.identity);
        selectors[3, 3, 0].stone.color = 0;

        selectors[3, 3, 1].stone = Instantiate(stoneType[0], new Vector3(-8.38f, -0.21f, 14.3f), Quaternion.identity);
        selectors[3, 3, 1].stone.color = 0;

        selectors[3, 3, 2].stone = Instantiate(stoneType[0], new Vector3(-12.38f, -0.21f, 14.3f), Quaternion.identity);
        selectors[3, 3, 2].stone.color = 0;

        selectors[3, 3, 3].stone = Instantiate(stoneType[0], new Vector3(-16.38f, -0.21f, 14.3f), Quaternion.identity);
        selectors[3, 3, 3].stone.color = 0;

    }

    // Update is called once per frame
    void Update() {

    }
}
