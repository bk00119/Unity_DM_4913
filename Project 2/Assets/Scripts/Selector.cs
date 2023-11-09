using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour {
    // Start is called before the first frame update
    public GameObject stone;

    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void OnMouseDown() {
        // index of the game object
        //int[] currentSelectorIndex = Custom.findIndexOfSelectors(Board.selectors, this); //

        if (Board.pasStone == null) {
            Board.pasStone = this;
        } else if (Board.agrStone == null) {
            Board.agrStone = this;
        } else if (Board.newPos == null) { //EDIT THIS
            Board.newPos = this;
        }

        //print(Board.pasStone);
        //print(Board.agrStone);
        //print(Board.newPos);

        if (Board.pasStone && Board.agrStone && Board.newPos) {
            ObjectPos pasStonePos = Custom.findIndexOfSelectors(Board.selectors, Board.pasStone); //
            ObjectPos agrStonePos = Custom.findIndexOfSelectors(Board.selectors, Board.agrStone); //
            ObjectPos newPos = Custom.findIndexOfSelectors(Board.selectors, Board.newPos); // EDIT: IF PAS MOVE ISN'T SELECTED
            // NEED A POS FOR THE OTHER STONE;

            if(Custom.onSamePos(pasStonePos, newPos)){
                Board.newPos = null;
                print("pasStone and newPos");
                return;
            }

            if (Custom.onSamePos(agrStonePos, newPos)) {
                Board.newPos = null;
                print("agrStone and newPos");
                return;
            }

            print("Passive Stone pos: " + pasStonePos.boardPos + " " + pasStonePos.boardRow + " " + pasStonePos.boardCol);
            print("Aggressive Stone pos: " + agrStonePos.boardPos + " " + agrStonePos.boardRow + " " + agrStonePos.boardCol);
            print("Passive new pos: " + newPos.boardPos + " " + newPos.boardRow + " " + newPos.boardCol);
            // change the stone 
            // Board.selectors[0,0,0].stone.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

            // change "stones" array
            //Board.stones[currSelectorInd.boardPos, currSelectorInd.boardRow, currSelectorInd.boardCol] = 0;

            // change selector.stone

            // reset the selections
            Board.pasStone = null;
            Board.agrStone = null;
            Board.newPos = null;

        }
    }
}
