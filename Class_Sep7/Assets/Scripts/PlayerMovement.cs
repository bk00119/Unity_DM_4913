using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {
    Rigidbody2D rb;
    CircleCollider2D cc;
    public int jumpSpeed; // public: can be edited in Unity
    //float jumpSpeedFloat = 100f; //float needs 'f' at the end of the number
    public int movementSpeed;

    // Start is called before the first frame update
    void Start() {
        rb = gameObject.GetComponent<Rigidbody2D>();
        cc = gameObject.GetComponent<CircleCollider2D>();
        jumpSpeed = 430;
    }

    // Update is called once per frame
    void Update() {
        // Jump
        if (Input.GetKeyDown(KeyCode.UpArrow)) {  //GetKey: everytime, GetKeyDown: only the first time pressed
            rb.AddForce(Vector2.up * jumpSpeed);
        }

        // Move to the right
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            rb.AddForce(Vector2.right * movementSpeed);
        }

        // Move to the left
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            rb.AddForce(Vector2.left * movementSpeed);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Enemy1") {
            SceneManager.LoadScene(0); //0: the scene reloads --> from Build Settings, the number on the right of Scenes in Build
        }
    }

}
