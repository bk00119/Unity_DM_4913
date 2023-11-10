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
        // Order: Select pasStone --> agrStone --> newPos
        if (Board.pasStone == null) {
            // pasStone selected

            // Check if blank selector or enemy's stone is selected
            if (stone == null || stone.color != Board.turn) {
                print("You must select your stone for a passive move");
                return;
            }

            ObjectPos stonePos = Custom.findIndexOfSelectors(Board.selectors, this);
            if (Board.turn == 0) {
                // Black's passive move must be made from Board 3(2) or 4(3)
                if (stonePos.boardPos == 0 || stonePos.boardPos == 1) {
                    print("pasStone must be selected from your side.");
                    return;
                }
            } else { // turn: 1; White's turn
                // White's passive move must be made from Board 1(0) or 2(1)
                if (stonePos.boardPos == 2 || stonePos.boardPos == 3) {
                    print("pasStone must be selected from your side.");
                    return;
                }
            }
            Board.pasStone = this;
        } else if (Board.agrStone == null) {
            // agrStone selected
            if (stone == null || stone.color != Board.turn) {
                print("You must select your stone for an agressive move");
                return;
            }

            ObjectPos pasStonePos = Custom.findIndexOfSelectors(Board.selectors, Board.pasStone);
            ObjectPos agrStonePos = Custom.findIndexOfSelectors(Board.selectors, this);

            if (Custom.onSameBoard(pasStonePos, agrStonePos)) {
                // Reset both stones to null
                //Board.pasStone = null;
                print("pasStone and agrStone are on the same board");
                return;
            }

            // Black's aggressive move must be made from the different color of the board
            if ((agrStonePos.boardPos == 0 && pasStonePos.boardPos == 3) ||
                (agrStonePos.boardPos == 1 && pasStonePos.boardPos == 2) ||
                (agrStonePos.boardPos == 2 && pasStonePos.boardPos == 1) ||
                (agrStonePos.boardPos == 3 && pasStonePos.boardPos == 0)) {
                print("agrStone must be selected from the different color of the board.");
                return;
            }

            Board.agrStone = this;
        } else if (Board.newPos == null) { //EDIT THIS
            // newPos selected

            Board.newPos = this;
        }

        // When the new move position is selected
        // FOR LATER...the order of selecting pasStone and agrStone could change.
        if (Board.pasStone && Board.agrStone && Board.newPos) {
            ObjectPos pasStonePos = Custom.findIndexOfSelectors(Board.selectors, Board.pasStone);
            ObjectPos agrStonePos = Custom.findIndexOfSelectors(Board.selectors, Board.agrStone);
            ObjectPos newPos = Custom.findIndexOfSelectors(Board.selectors, Board.newPos);

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

            // check if the move isn't valid
            if(!Custom.isValidMove(Board.selectors, pasStonePos, agrStonePos, newPos)) {
                print("the move is not valid");
                Board.pasStone = null;
                Board.agrStone = null;
                Board.newPos = null;
                return;
            }

            // change the position of pasStone and agrStone
            if (newPos.boardPos == pasStonePos.boardPos) {
                // newPos made from pasStone's board
                // change pasStone's position
                Vector3 pasSelectorPos = Board.selectors[newPos.boardPos, newPos.boardRow, newPos.boardCol].transform.position;
                Board.pasStone.stone.transform.position = new Vector3(pasSelectorPos.x, pasSelectorPos.y, pasSelectorPos.z);
                // update selector's stone
                Board.selectors[newPos.boardPos, newPos.boardRow, newPos.boardCol].stone = Board.pasStone.stone;
                Board.selectors[pasStonePos.boardPos, pasStonePos.boardRow, pasStonePos.boardCol].stone = null;

                // change agrStone's position
                ObjectPos newAgrPos = Custom.getAnotherNewPos(pasStonePos, newPos, agrStonePos);
                Vector3 agrSelectorPos = Board.selectors[newAgrPos.boardPos, newAgrPos.boardRow, newAgrPos.boardCol].transform.position;
                Board.agrStone.stone.transform.position = new Vector3(agrSelectorPos.x, agrSelectorPos.y, agrSelectorPos.z);
                // push enemy's stone
                Custom.pushStone(Board.selectors, agrStonePos, newAgrPos);

                // update selector's stone
                Board.selectors[newAgrPos.boardPos, newAgrPos.boardRow, newAgrPos.boardCol].stone = Board.agrStone.stone;
                Board.selectors[agrStonePos.boardPos, agrStonePos.boardRow, agrStonePos.boardCol].stone = null;

            } else {
                // newPos made from agrStone's board
                // change agrStone's position
                Vector3 agrSelectorPos = Board.selectors[newPos.boardPos, newPos.boardRow, newPos.boardCol].transform.position;
                Board.agrStone.stone.transform.position = new Vector3(agrSelectorPos.x, agrSelectorPos.y, agrSelectorPos.z);
                // push enemy's stone
                Custom.pushStone(Board.selectors, agrStonePos, newPos);

                // update selector's stone
                Board.selectors[newPos.boardPos, newPos.boardRow, newPos.boardCol].stone = Board.agrStone.stone;
                Board.selectors[agrStonePos.boardPos, agrStonePos.boardRow, agrStonePos.boardCol].stone = null;

                // change pasStone's position
                ObjectPos newPasPos = Custom.getAnotherNewPos(agrStonePos, newPos, pasStonePos);
                Vector3 pasSelectorPos = Board.selectors[newPasPos.boardPos, newPasPos.boardRow, newPasPos.boardCol].transform.position;
                Board.pasStone.stone.transform.position = new Vector3(pasSelectorPos.x, pasSelectorPos.y, pasSelectorPos.z);
                // update selector's stone
                Board.selectors[newPasPos.boardPos, newPasPos.boardRow, newPasPos.boardCol].stone = Board.pasStone.stone;
                Board.selectors[pasStonePos.boardPos, pasStonePos.boardRow, pasStonePos.boardCol].stone = null;

            }

            // reset the selections
            Board.pasStone = null;
            Board.agrStone = null;
            Board.newPos = null;
            // CHANGE THE TURN
            //Board.isBlackTurn = !(Board.isBlackTurn);

            Custom.printSelectors(Board.selectors); // REMOVE THIS
        }
    }
}
