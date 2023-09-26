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
    int jumpCount; // init: 0
    static int maxJumpCount = 2;
    bool onGround; // init: false
    public int score;

    // Start is called before the first frame update
    void Start() {
        rb = gameObject.GetComponent<Rigidbody2D>();
        cc = gameObject.GetComponent<CircleCollider2D>();
        //jumpSpeed = 430;
    }

    // Update is called once per frame
    void Update() {
        // Jump
        if ((Input.GetKeyDown(KeyCode.UpArrow) && jumpCount < maxJumpCount && onGround==false) || (Input.GetKeyDown(KeyCode.UpArrow) && onGround)) {  //GetKey: everytime, GetKeyDown: only the first time pressed
            rb.AddForce(Vector2.up * jumpSpeed);
            jumpCount++;
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
            //SceneManager.LoadScene(1); //CHANGE THIS
            SceneManager.LoadScene(2); //2: Game Over Scene
        }

        if (collision.gameObject.tag == "Ground") {
            onGround = true;
            jumpCount = 0;
        }

        if (collision.gameObject.tag == "Star") {
            score++;
            //Destroy(GetComponent<PolygonCollider2D>());
            Destroy(collision.gameObject);
        }

    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            onGround = false;
        }
    }

}
