using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {
    public int[] stones = new int[4] { 4, 4, 4, 4 };
    //public int[] stones = new int[4] { 1, 1, 1, 1 }; // REMOVE THIS

    public bool hasNoStoneOnBoard() {
        for (int i = 0; i < stones.GetLength(0); i++) {
            if (stones[i] == 0) {
                return true;
            }
        }
        return false;
    }

}
