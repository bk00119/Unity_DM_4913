using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {
    public GameObject[] stoneType = new GameObject[2]; // 0: Black Stone, 1: White Stone
    public Selector selector;
    //public static GameObject[,,] stones;
    public static int[,,] stones;
    public static Selector[,,] selectors;

    public static Selector pasStone, agrStone, pasNewPos, agrNewPos, newPos;
    public static Vector3 pasPos, agrPos;

    // Start is called before the first frame update 
    void Start() {
        selectors = new Selector[4, 4, 4] {
            // Board 1 (Top-Right)
            {
                {
                    Instantiate(selector, new Vector3(-4.38f, -0.21f, -16.6f), Quaternion.identity),
                    Instantiate(selector, new Vector3(-8.38f, -0.21f, -16.6f), Quaternion.identity),
                    Instantiate(selector, new Vector3(-12.38f, -0.21f, -16.6f), Quaternion.identity),
                    Instantiate(selector, new Vector3(-16.38f, -0.21f, -16.6f), Quaternion.identity),

                    //Instantiate(selector, new Vector3(-4.38f, -0.21f, -16.6f), Quaternion.identity),
                    //new GameObject(),
                    //new GameObject(),
                    //new GameObject()
                },
                {
                    Instantiate(selector, new Vector3(-4.38f, -0.21f, -12.6f), Quaternion.identity),
                    Instantiate(selector, new Vector3(-8.38f, -0.21f, -12.6f), Quaternion.identity),
                    //null,
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

        //print(Custom.findIndexOfSelectors(selectors, selectors[1, 2, 2])[0]);
        //print(Custom.findIndexOfSelectors(selectors, selectors[1, 2, 2])[1]);
        //print(Custom.findIndexOfSelectors(selectors, selectors[1, 2, 2])[2]);

        selectors[0, 0, 0].stone = Instantiate(stoneType[0], new Vector3(-4.38f, -0.21f, -16.6f), Quaternion.identity);

        stones = new int[4, 4, 4] {
            {
                { 1, 1, 1, 1 },
                { 2, 2, 2, 2 },
                { 2, 2, 2, 2 },
                { 0, 0, 0, 0 }
            },
            {
                { 1, 1, 1, 1 },
                { 2, 2, 2, 2 },
                { 2, 2, 2, 2 },
                { 0, 0, 0, 0 }
            },
            {
                { 1, 1, 1, 1 },
                { 2, 2, 2, 2 },
                { 2, 2, 2, 2 },
                { 0, 0, 0, 0 }
            },
            {
                { 1, 1, 1, 1 },
                { 2, 2, 2, 2 },
                { 2, 2, 2, 2 },
                { 0, 0, 0, 0 }
            }
        };
    }

    // Update is called once per frame
    void Update() {
        //if (pasStone.tag == "White Stone" && agrStone.tag == "Black Stone") {
        //    pasStone.transform.position = new Vector3(-27, -0, 6);
        //    agrStone.transform.position = new Vector3(-30, -0, 6);

        //    pasStone = null;
        //    agrStone = null;
        //}
    }
}
