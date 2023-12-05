using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPos {
    public int boardPos;
    public int boardRow;
    public int boardCol;
}

public class Custom : MonoBehaviour {
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
            //print("Move must be less than 2");
            PlayError.SetMovOverTwoError();
            return false;
        }

        // the diagonal move be the same for row and col ex) up+2 and left+1 --> Invalid
        if ((distance[0] == 1 && distance[1] == 2) || (distance[0] == 2 && distance[1] == 1)) {
            //print("Diagonal move must have the same row move and col move");
            PlayError.SetMovDiagonalError();
            return false;
        }
        return true;
    }

    public static bool isPositionValid(Selector[,,] selectors, ObjectPos pos) {
        // board position is invalid
        if(pos.boardPos < 0 || pos.boardPos >= selectors.GetLength(0)) {
            //print("Board position is out of boud");
            PlayError.SetMovBoardPosOBError();
            return false;
        }

        // board row is invalid
        if(pos.boardRow < 0 || pos.boardRow >= selectors.GetLength(1)) {
            //print("Board row is out of bound");
            PlayError.SetMovBoardRowOBError();
            return false;
        }

        // board col is invalid
        if(pos.boardCol < 0 || pos.boardCol >= selectors.GetLength(2)) {
            //print("Board col is out of bound");
            PlayError.SetMovBoardColOBError();
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

    public static int getRowDirection(ObjectPos pos, ObjectPos newPos) {
        int res = newPos.boardRow - pos.boardRow;
        if (res < 0) {
            return -1;
        }
        if (res > 0) {
            return 1;
        }
        return 0;
    }

    public static int getColDirection(ObjectPos pos, ObjectPos newPos) {
        int res = newPos.boardCol - pos.boardCol;
        if (res < 0) {
            return -1;
        }
        if (res > 0) {
            return 1;
        }
        return 0;
    }

    public static bool posOutOfBound(Selector[,,] selectors, ObjectPos pos) {
        return pos.boardRow < 0 || pos.boardRow >= selectors.GetLength(1) ||
            pos.boardCol < 0 || pos.boardCol >= selectors.GetLength(2);
    }

    public static int numAllyOnWay(Selector[,,] selectors, ObjectPos pos, ObjectPos newPos) {
        // 0: none, 1: one ally stone, 2: two ally stones
        int numAlly = 0;
        int[] distance = getDistance(newPos, pos);

        // check if the move is +2 and there's an ally in between the current position and the new position
        if (Mathf.Max(distance[0], distance[1]) == 2) {
            int midRow = newPos.boardRow;
            if (newPos.boardRow != pos.boardRow) {
                //midRow = Mathf.Max(newPos.boardRow, pos.boardRow) - Mathf.Min(newPos.boardRow, pos.boardRow);
                //midRow = Mathf.Abs(newPos.boardRow - pos.boardRow);
                midRow = Mathf.Max(newPos.boardRow, pos.boardRow) - 1;
            }
            int midCol = newPos.boardCol;
            if (newPos.boardCol != pos.boardCol) {
                //midCol = Mathf.Max(newPos.boardCol, pos.boardCol) - Mathf.Min(newPos.boardCol, pos.boardCol);
                //midCol = Mathf.Abs(newPos.boardCol - pos.boardCol);
                midCol = Mathf.Max(newPos.boardCol, pos.boardCol) - 1;
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
                //midRow = Mathf.Max(newPos.boardRow, pos.boardRow) - Mathf.Min(newPos.boardRow, pos.boardRow);
                midRow = Mathf.Max(newPos.boardRow, pos.boardRow) - 1;
            }
            int midCol = newPos.boardCol;
            if (newPos.boardCol != pos.boardCol) {
                //midCol = Mathf.Max(newPos.boardCol, pos.boardCol) - Mathf.Min(newPos.boardCol, pos.boardCol);
                midCol = Mathf.Max(newPos.boardCol, pos.boardCol) - 1;
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

    public static bool hasAStoneOnFurtherWay(Selector[,,] selectors, ObjectPos pos, ObjectPos newPos) {
        // check if there's any stone next to that would get pushed off
        int adjRow = newPos.boardRow + getRowDirection(pos, newPos); 
        int adjCol = newPos.boardCol + getColDirection(pos, newPos);

        // index out of bound --> the newPos is the last one by the end of the board
        if (adjRow < 0 || adjRow >= selectors.GetLength(1) ||
            adjCol < 0 || adjCol >= selectors.GetLength(2)) {
            return false;
        }

        // no stone on the further way
        if (selectors[newPos.boardPos, adjRow, adjCol].stone == null) {
            return false;
        }

        return true;
    }

    public static bool isValidPassiveMove(Selector[,,] selectors, ObjectPos pasPos, ObjectPos newPos) {
        // passive move can't push any stone
        if ((numAllyOnWay(selectors, pasPos, newPos) + numEnemyOnWay(selectors, pasPos, newPos)) > 0) {
            //print("Passive move can't push any stone");
            PlayError.SetMovPasPushError();
            return false;
        }

        return true;
    }

    public static bool isValidAggressiveMove(Selector[,,] selectors, ObjectPos agrPos, ObjectPos newPos) {
        // any allystone is between agrPos and newPos or on newPos
        if (numAllyOnWay(selectors, agrPos, newPos) > 0) {
            //print("Aggressive move can't push any ally stones");
            PlayError.SetMovAgrPushAllyError();
            return false;
        }

        // two enemy stones are on the way or on new Pos
        if (numEnemyOnWay(selectors, agrPos, newPos) > 1) {
            //print("Aggresive move can't push two enemy stones");
            PlayError.SetMovAgrPushTwoError();
            return false;
        }

        // pushing two stones
        if (numEnemyOnWay(selectors, agrPos, newPos) > 0 && hasAStoneOnFurtherWay(selectors, agrPos, newPos)) {
            PlayError.SetMovAgrPushTwoError();
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
            //print("new move position is made from the board where no stone is selected on");
            PlayError.SetMovBoardWithNoStoneError();
            return false;
        }
        // every edgecase passed
        return true;
    }

    public static ObjectPos getMidPos(ObjectPos pos, ObjectPos newPos) {
        int[] distance = getDistance(newPos, pos);
        // check if the move is +2
        if (Mathf.Max(distance[0], distance[1]) < 2) {
            return null;
        }

        ObjectPos midPos = new ObjectPos();
        int midRow = newPos.boardRow;
        if (newPos.boardRow != pos.boardRow) {
            //midRow = Mathf.Max(newPos.boardRow, pos.boardRow) - Mathf.Min(newPos.boardRow, pos.boardRow);
            midRow = Mathf.Max(newPos.boardRow, pos.boardRow) - 1;
        }
        int midCol = newPos.boardCol;
        if (newPos.boardCol != pos.boardCol) {
            //midCol = Mathf.Max(newPos.boardCol, pos.boardCol) - Mathf.Min(newPos.boardCol, pos.boardCol);
            midCol = Mathf.Max(newPos.boardCol, pos.boardCol) - 1;
        }
        midPos.boardPos = pos.boardPos;
        midPos.boardRow = midRow;
        midPos.boardCol = midCol;

        return midPos;
    }

    public static ObjectPos getEnemyPos(Selector[,,] selectors, ObjectPos pos, ObjectPos newPos) {
        ObjectPos enemyPos = new ObjectPos();
        enemyPos.boardPos = pos.boardPos;

        int[] distance = getDistance(newPos, pos);

        // check if the move is +2 and there's an enemy in between the current position and the new position
        if (Mathf.Max(distance[0], distance[1]) == 2) {
            ////int midRow = Mathf.Max(newPos.boardRow, pos.boardRow) - Mathf.Min(newPos.boardRow, pos.boardRow);
            ////int midCol = Mathf.Max(newPos.boardCol, pos.boardCol) - Mathf.Min(newPos.boardCol, pos.boardCol);
            //int midRow = newPos.boardRow;
            //if (newPos.boardRow != pos.boardRow) {
            //    midRow = Mathf.Max(newPos.boardRow, pos.boardRow) - Mathf.Min(newPos.boardRow, pos.boardRow);
            //}
            //int midCol = newPos.boardCol;
            //if (newPos.boardCol != pos.boardCol) {
            //    midCol = Mathf.Max(newPos.boardCol, pos.boardCol) - Mathf.Min(newPos.boardCol, pos.boardCol);
            //}
            //int boardPos = pos.boardPos;

            ObjectPos midPos = getMidPos(pos, newPos);
            if (selectors[midPos.boardPos, midPos.boardRow, midPos.boardCol].stone != null &&
                selectors[pos.boardPos, pos.boardRow, pos.boardCol].stone != null &&
                selectors[midPos.boardPos, midPos.boardRow, midPos.boardCol].stone.color != selectors[pos.boardPos, pos.boardRow, pos.boardCol].stone.color) {
                // not the same color --> enemy stone is in between
                enemyPos.boardRow = midPos.boardRow;
                enemyPos.boardCol = midPos.boardCol;
                return enemyPos;
            }

            //if (selectors[boardPos, midRow, midCol].stone != null &&
            //    selectors[boardPos, pos.boardRow, pos.boardCol].stone != null &&
            //    selectors[boardPos, midRow, midCol].stone.color != selectors[boardPos, pos.boardRow, pos.boardCol].stone.color) {
            //    // not the same color --> enemy stone is in between
            //    enemyPos.boardRow = midRow;
            //    enemyPos.boardCol = midCol;
            //    return enemyPos;
            //}
        }

        // check if on the new move's position has an enemy stone
        if (selectors[newPos.boardPos, newPos.boardRow, newPos.boardCol].stone != null &&
            selectors[pos.boardPos, pos.boardRow, pos.boardCol].stone != null &&
            selectors[newPos.boardPos, newPos.boardRow, newPos.boardCol].stone.color != selectors[pos.boardPos, pos.boardRow, pos.boardCol].stone.color) {
            // not the same color --> enemy stone is in between
            enemyPos.boardRow = newPos.boardRow;
            enemyPos.boardCol = newPos.boardCol;
            return enemyPos;
        }

        return null;
    }

    public static ObjectPos getNewEnemyPos(Selector[,,] selectors, ObjectPos enemyPos, ObjectPos pos, ObjectPos newPos) {
        ObjectPos newEnemyPos = new ObjectPos();
        newEnemyPos.boardPos = enemyPos.boardPos;
        //newEnemyPos.boardRow = newEnemyPos.boardRow + getRowDirection(pos, newPos);
        //newEnemyPos.boardCol = newEnemyPos.boardCol + getColDirection(pos, newPos);
        newEnemyPos.boardRow = newPos.boardRow + getRowDirection(pos, newPos);
        newEnemyPos.boardCol = newPos.boardCol + getColDirection(pos, newPos);

        // check index out of bound
        if (posOutOfBound(selectors, newEnemyPos)) {
            return null;
        }

        return newEnemyPos;
    }

    public static void pushStone(Selector[,,] selectors, ObjectPos pos, ObjectPos newPos) {
        // this function gets called after checking the validity of the move

        // no enemy stone found
        int numEnemyStones = numEnemyOnWay(selectors, pos, newPos);
        if (numEnemyStones == 0) {
            return;
        }



        ObjectPos enemyPos = getEnemyPos(selectors, pos, newPos);
        ObjectPos newEnemyPos = getNewEnemyPos(selectors, enemyPos, pos, newPos);
        // if the enemy stone is pushed off
        if (newEnemyPos == null) {
            // ref the enemy stone object
            Stone temp = selectors[enemyPos.boardPos, enemyPos.boardRow, enemyPos.boardCol].stone;

            // update Player's stone arr
            if (temp.color == 0) {
                // black player loses its stone
                Board.blackPlayer.stones[enemyPos.boardPos] -= 1;

            } else {
                // white player loses its stone
                Board.whitePlayer.stones[enemyPos.boardPos] -= 1;
            }

            // unattach the enemy stone from selector
            selectors[enemyPos.boardPos, enemyPos.boardRow, enemyPos.boardCol].stone = null;

            // destroy the enemy stone object
            Destroy(temp.gameObject);
            return;
        }

        // push the enemy stone to newEnemyPos
        Vector3 newEnemySelectorPos = selectors[newEnemyPos.boardPos, newEnemyPos.boardRow, newEnemyPos.boardCol].transform.position;
        selectors[enemyPos.boardPos, enemyPos.boardRow, enemyPos.boardCol].stone.transform.position = new Vector3(newEnemySelectorPos.x, newEnemySelectorPos.y, newEnemySelectorPos.z);
        selectors[newEnemyPos.boardPos, newEnemyPos.boardRow, newEnemyPos.boardCol].stone = selectors[enemyPos.boardPos, enemyPos.boardRow, enemyPos.boardCol].stone;
        selectors[enemyPos.boardPos, enemyPos.boardRow, enemyPos.boardCol].stone = null;

    }

    public static void liftStone(Selector selector) {
        // lift the stone up
        selector.stone.transform.position = new Vector3(selector.stone.transform.position.x, 1.0f, selector.stone.transform.position.z);

        // scale up the height of selector
        selector.transform.localScale = new Vector3(selector.transform.localScale.x, 4.1f, selector.stone.transform.localScale.z);

    }

    public static void dropStone(Selector selector) {
        // drop the stone
        selector.stone.transform.position = new Vector3(selector.stone.transform.position.x, -0.21f, selector.stone.transform.position.z);

        // scale down the height of selector
        selector.transform.localScale = new Vector3(selector.transform.localScale.x, 2.1f, selector.stone.transform.localScale.z);

    }

    public static void printSelectors(Selector[,,] selectors) {
        string arr = "";
        for (int i = 0; i < selectors.GetLength(0); i++) {
            for (int j = 0; j < selectors.GetLength(1); j++) {
                for (int k = 0; k < selectors.GetLength(2); k++) {
                    if (selectors[i, j, k].stone == null) {
                        arr += " 2 ";
                    } else {
                        if (selectors[i, j, k].stone.color == 0) {
                            arr += " 0 ";
                        } else {
                            arr += " 1 ";
                        }
                    }
                }
                arr += "\n";
            }
            arr += "\n\n";
        }
        print(arr);
    }
 
}