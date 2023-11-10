using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPos {
    public int boardPos;
    public int boardRow;
    public int boardCol;
}

public static class Custom {
    public static ObjectPos findIndexOfSelectors(Selector[,,] selectors, Selector selector) {
        //int[] index = { -1, -1, -1 };
        // index[0] = Board Position
        // index[1] = Board Row
        // index[2] = Board Col

        ObjectPos pos = new ObjectPos();

        for (int i = 0; i < selectors.GetLength(0); i++) {
            for (int j = 0; j < selectors.GetLength(1); j++) {
                for (int k = 0; k < selectors.GetLength(2); k++) {
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

    public static int[] getDistance(ObjectPos posA, ObjectPos posB) {
        // [row, col]
        int[] res = { Mathf.Abs(posA.boardRow - posB.boardRow), Mathf.Abs(posA.boardCol - posB.boardCol) };
        return res;
    }

    public static bool isMoveDistanceValid(int[] distance) {
        // max move is +/- 2 in any direction
        if (distance[0] > 2 || distance[1] > 2) {
            return false;
        }

        // the diagonal move be the same for row and col ex) up+2 and left+1 --> Invalid
        if ((distance[0] == 1 && distance[1] == 2) || (distance[0] == 2 && distance[1] == 1)) {
            return false;
        }
        return true;
    }

    public static bool isPositionValid(Selector[,,] selectors, ObjectPos pos) {
        // board position is invalid
        if(pos.boardPos < 0 || pos.boardPos >= selectors.GetLength(0)) {
            return false;
        }

        // board row is invalid
        if(pos.boardRow < 0 || pos.boardRow >= selectors.GetLength(1)) {
            return false;
        }

        // board col is invalid
        if(pos.boardCol < 0 || pos.boardCol >= selectors.GetLength(2)) {
            return false;
        }

        return true;
    }

    public static ObjectPos getAnotherNewPos(ObjectPos posA, ObjectPos newPosA, ObjectPos posB) {
        ObjectPos newPosB = new ObjectPos();
        int rowMove = posA.boardRow - newPosA.boardRow;
        int colMove = posA.boardCol - newPosA.boardCol;

        newPosB.boardPos = posB.boardPos;
        newPosB.boardRow = posB.boardRow - rowMove;
        newPosB.boardCol = posB.boardCol - colMove;
        return newPosB;
    }

    public static int numAllyOnWay(Selector[,,] selectors, ObjectPos pos, ObjectPos newPos) {
        // 0: none, 1: one ally stone, 2: two ally stones
        int numAlly = 0;
        int[] distance = getDistance(newPos, pos);

        // check if the move is +2 and there's an ally in between the current position and the new position
        if (Mathf.Max(distance[0], distance[1]) == 2) {
            int midRow = newPos.boardRow;
            if (newPos.boardRow != pos.boardRow) {
                midRow = Mathf.Max(newPos.boardRow, pos.boardRow) - Mathf.Min(newPos.boardRow, pos.boardRow);
            }
            int midCol = newPos.boardCol;
            if (newPos.boardCol != pos.boardCol) {
                midCol = Mathf.Max(newPos.boardCol, pos.boardCol) - Mathf.Min(newPos.boardCol, pos.boardCol);
            }
            int boardPos = pos.boardPos;

            if (selectors[boardPos, midRow, midCol].stone != null &&
                selectors[boardPos, pos.boardRow, pos.boardCol].stone != null &&
                selectors[boardPos, midRow, midCol].stone.color == selectors[boardPos, pos.boardRow, pos.boardCol].stone.color) {
                // the same color --> ally stone is in between
                numAlly++;
            }
        }

        // check if on the new move's position has an ally stone
        if (selectors[newPos.boardPos, newPos.boardRow, newPos.boardCol].stone != null &&
            selectors[pos.boardPos, pos.boardRow, pos.boardCol].stone != null &&
            selectors[newPos.boardPos, newPos.boardRow, newPos.boardCol].stone.color == selectors[pos.boardPos, pos.boardRow, pos.boardCol].stone.color) {
            // the same color --> ally stone is in between
            numAlly++;
        }

        return numAlly;
    }

    public static int numEnemyOnWay(Selector[,,] selectors, ObjectPos pos, ObjectPos newPos) {
        // 0: none, 1: one enemy stone, 2: two enemy stones
        int numEnemy = 0;
        int[] distance = getDistance(newPos, pos);

        // check if the move is +2 and there's an enemy in between the current position and the new position
        if (Mathf.Max(distance[0], distance[1]) == 2) {
            //int midRow = Mathf.Max(newPos.boardRow, pos.boardRow) - Mathf.Min(newPos.boardRow, pos.boardRow);
            //int midCol = Mathf.Max(newPos.boardCol, pos.boardCol) - Mathf.Min(newPos.boardCol, pos.boardCol);
            int midRow = newPos.boardRow;
            if (newPos.boardRow != pos.boardRow) {
                midRow = Mathf.Max(newPos.boardRow, pos.boardRow) - Mathf.Min(newPos.boardRow, pos.boardRow);
            }
            int midCol = newPos.boardCol;
            if (newPos.boardCol != pos.boardCol) {
                midCol = Mathf.Max(newPos.boardCol, pos.boardCol) - Mathf.Min(newPos.boardCol, pos.boardCol);
            }
            int boardPos = pos.boardPos;

            if (selectors[boardPos, midRow, midCol].stone != null &&
                selectors[boardPos, pos.boardRow, pos.boardCol].stone != null &&
                selectors[boardPos, midRow, midCol].stone.color != selectors[boardPos, pos.boardRow, pos.boardCol].stone.color) {
                // not the same color --> enemy stone is in between
                numEnemy++;
            }
        }
        
        // check if on the new move's position has an enemy stone
        if (selectors[newPos.boardPos, newPos.boardRow, newPos.boardCol].stone != null &&
            selectors[pos.boardPos, pos.boardRow, pos.boardCol].stone != null &&
            selectors[newPos.boardPos, newPos.boardRow, newPos.boardCol].stone.color != selectors[pos.boardPos, pos.boardRow, pos.boardCol].stone.color) {
            // not the same color --> enemy stone is in between
            numEnemy++;
        }

        return numEnemy;
    }

    public static bool isValidPassiveMove(Selector[,,] selectors, ObjectPos pasPos, ObjectPos newPos) {
        // passive move can't push any stone
        if ((numAllyOnWay(selectors, pasPos, newPos) + numEnemyOnWay(selectors, pasPos, newPos)) > 0) {
            return false;
        }

        return true;
    }

    public static bool isValidAggressiveMove(Selector[,,] selectors, ObjectPos agrPos, ObjectPos newPos) {
        // any allystone is between agrPos and newPos or on newPos
        if (numAllyOnWay(selectors, agrPos, newPos) > 0) {
            return false;
        }

        // two enemy stones are on the way or on new Pos
        if (numEnemyOnWay(selectors, agrPos, newPos) > 1) {
            return false;
        }

        return true;
    }

    public static bool isValidMove(Selector[,,] selectors, ObjectPos pasPos, ObjectPos agrPos, ObjectPos newPos) {
        if (newPos.boardPos == pasPos.boardPos) {
            // if the new move was made from the passive stone's board

            // check if moving distance is invalid
            int[] distance = getDistance(newPos, pasPos);
            if (!isMoveDistanceValid(distance)) {
                return false;
            }

            // check if passive move is invalid
            if (!isValidPassiveMove(selectors, pasPos, newPos)) {
                return false;
            }

            // check if aggressive move is invalid
            ObjectPos newAgrPos = getAnotherNewPos(pasPos, newPos, agrPos);
            // 1) check if aggressive move's new position is out of bound (suicide)
            if (!isPositionValid(selectors, newAgrPos)) {
                return false;
            }
            // 2) check if agrStone pushes any allystone or two enemy stones
            if (!isValidAggressiveMove(selectors, agrPos, newAgrPos)) {
                return false;
            }

        } else if (newPos.boardPos == agrPos.boardPos) {
            // if the new move was made from the aggressive stone's board

            // check if moving distance is invalid
            int[] distance = getDistance(newPos, agrPos);
            if (!isMoveDistanceValid(distance)) {
                return false;
            }

            // check if aggressive move is invalid
            if (!isValidAggressiveMove(selectors, agrPos, newPos)) {
                return false;
            }

            // check if passive move is invalid
            ObjectPos newPasPos = getAnotherNewPos(agrPos, newPos, pasPos);
            // 1) check if passive move's new position is out of bound (suicide)
            if (!isPositionValid(selectors, newPasPos)) {
                return false;
            }
            // 2) check if pasStone pushes any stone
            if (!isValidPassiveMove(selectors, pasPos, newPasPos)) { // ERROR: INDEX OUF OF BOUND
                return false;
            }

        } else {
            // if the new move was made from the board where no stone is selected on
            return false;
        }
        // every edgecase passed
        return true;
    }
}