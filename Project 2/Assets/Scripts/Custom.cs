using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Custom {
    public static ObjectPos findIndexOfSelectors(Selector[,,] selectors, Selector selector) {
        //int[] index = { -1, -1, -1 };
        // index[0] = Board Position
        // index[1] = Board Row
        // index[2] = Board Col

        ObjectPos pos = new ObjectPos();

        for(int i = 0; i < selectors.GetLength(0); i++) {
            for(int j = 0; j < selectors.GetLength(1); j++) {
                for(int k = 0; k < selectors.GetLength(2); k++) {
                    if (selectors[i, j, k].Equals(selector)) {
                        //index[0] = i;
                        //index[1] = j;
                        //index[2] = k;
                        pos.boardPos = i;
                        pos.boardRow = j;
                        pos.boardCol = k;
                    }
                }
            }
        }

        return pos;
    }


    public static bool onSamePos(ObjectPos posA, ObjectPos posB) {
        return posA.boardPos == posB.boardPos && posA.boardRow == posB.boardRow && posA.boardCol == posB.boardCol;
    }

    public static bool onSameBoard(ObjectPos posA, ObjectPos posB) {
        return posA.boardPos == posB.boardPos;
    }
}

public class ObjectPos {
    public int boardPos;
    public int boardRow;
    public int boardCol;
}