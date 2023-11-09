using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {
    bool isSelected;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void OnMouseDown() {
        //gameObject.transform.position = new Vector3(-27, -0, 6);
        //Destroy(Board.Stones[2, 0, 0]);
        //if (gameObject.tag == "White Stone") {
        //    //isSelected = true;
        //    Board.pasStone = gameObject;
        //} else {
        //    Board.agrStone = gameObject;
        //    //isSelected = false;
        //}
        //GameObject clickedStone = GameObject.Find("Transparent Pebble");
        //clickedStone.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        Destroy(gameObject);
    }
}
