using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour {
    // Start is called before the first frame update
    public Stone stone;

    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void OnMouseDown() {
        // index of the game object
        //int[] currentSelectorIndex = Custom.findIndexOfSelectors(Board.selectors, this); //

        // Always select pasStone first
        if (Board.pasStone == null) {
            // CHECK IF THE STONE IS ATTACHED

            ObjectPos stonePos = Custom.findIndexOfSelectors(Board.selectors, this);
            if (Board.turn == 0) {
                // Black's passive move must be made from Board 3(2) or 4(3)
                if (stonePos.boardPos == 0 || stonePos.boardPos == 1) {
                    print("pasStone must be selected from your side.");
                    return;
                }
            } else { //Board.turn == 1
                // White's passive move must be made from Board 1(0) or 2(1)
                if (stonePos.boardPos == 2 || stonePos.boardPos == 3) {
                    print("pasStone must be selected from your side.");
                    return;
                }
            }
            Board.pasStone = this;
        } else if (Board.agrStone == null) {
            ObjectPos pasStonePos = Custom.findIndexOfSelectors(Board.selectors, Board.pasStone);
            ObjectPos agrStonePos = Custom.findIndexOfSelectors(Board.selectors, this);
            // Black's aggressive move must be made from the different color of the board
            if ((agrStonePos.boardPos == 0 && pasStonePos.boardPos == 3) ||
                (agrStonePos.boardPos == 1 && pasStonePos.boardPos == 2) ||
                (agrStonePos.boardPos == 2 && pasStonePos.boardPos == 1) ||
                (agrStonePos.boardPos == 3 && pasStonePos.boardPos == 0)) {
                print("agrStone must be selected from the different color of the board.");
                return;
            }
            //if (stonePos.boardPos == 0 || stonePos.boardPos == 1) {
            //    print("agrStone must be selected from the different color of the board.");
            //    return;
            //}
            // White's aggressive move must be made from the different color of the board
            //if (stonePos.boardPos == 2 || stonePos.boardPos == 3) {
            //    print("agrStone must be selected from the different color of the board.");
            //    return;
            //}
            Board.agrStone = this;
        } else if (Board.newPos == null) { //EDIT THIS
            Board.newPos = this;
        }

        // When two stones are selected
        if (Board.pasStone && Board.agrStone) {
            ObjectPos pasStonePos = Custom.findIndexOfSelectors(Board.selectors, Board.pasStone);
            ObjectPos agrStonePos = Custom.findIndexOfSelectors(Board.selectors, Board.agrStone);

            if (Custom.onSameBoard(pasStonePos, agrStonePos)) {
                // Reset both stones to null
                Board.pasStone = null;
                Board.agrStone = null;
                print("pasStone and agrStone are on the same board");
                return;
            }
        }

        // When the new move position is selected
        if (Board.pasStone && Board.agrStone && Board.newPos) {
            ObjectPos pasStonePos = Custom.findIndexOfSelectors(Board.selectors, Board.pasStone);
            ObjectPos agrStonePos = Custom.findIndexOfSelectors(Board.selectors, Board.agrStone);
            ObjectPos newPos = Custom.findIndexOfSelectors(Board.selectors, Board.newPos); // EDIT: IF PAS MOVE ISN'T SELECTED
            // NEED A POS FOR THE OTHER STONE;

            // If newPos and pasStonePos are on the same pos
            if(Custom.onSamePos(pasStonePos, newPos)){
                Board.newPos = null;
                print("pasStone and newPos");
                return;
            }

            // If newPos and agrStonePos are on the same pos
            if (Custom.onSamePos(agrStonePos, newPos)) {
                Board.newPos = null;
                print("agrStone and newPos");
                return;
            }

            // If newPos not on the same board with agrStone or pasStone
            if(!Custom.onSameBoard(pasStonePos, newPos) && !Custom.onSameBoard(agrStonePos, newPos)) {
                Board.newPos = null;
                print("newPos not on one of the stone's board");
                return;
            }

            //print("Passive Stone pos: " + pasStonePos.boardPos + " " + pasStonePos.boardRow + " " + pasStonePos.boardCol);
            //print("Aggressive Stone pos: " + agrStonePos.boardPos + " " + agrStonePos.boardRow + " " + agrStonePos.boardCol);
            //print("New pos: " + newPos.boardPos + " " + newPos.boardRow + " " + newPos.boardCol);

            // change the position of pasStone and agrStone
            // Board.selectors[0,0,0].stone.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            // TESTING...
            //Board.agrStone.stone.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

            // change "stones" array
            //Board.stones[currSelectorInd.boardPos, currSelectorInd.boardRow, currSelectorInd.boardCol] = 0;

            // change selector.stone

            print("Successful move"); // REMOVE THIS
            // reset the selections
            Board.pasStone = null;
            Board.agrStone = null;
            Board.newPos = null;

        }
    }
}
