using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {
    Rigidbody2D rb;
    CircleCollider2D cc;
    public int jumpSpeed; // public: can be edited in Unity
    public int movementSpeed;
    int jumpCount; // init: 0
    static int maxJumpCount = 2;
    bool onGround; // init: false
    public int score;
    public float jumpMaxVelocity;
    AudioSource jumpSFX, impactSFX, gameOverSFX, coinSFX;
    GameObject AM;

    // Start is called before the first frame update
    void Start() {
        rb = gameObject.GetComponent<Rigidbody2D>();
        cc = gameObject.GetComponent<CircleCollider2D>();
        jumpSFX = gameObject.GetComponents<AudioSource>()[0];
        impactSFX = gameObject.GetComponents<AudioSource>()[1];
        //gameOverSFX = gameObject.GetComponents<AudioSource>()[2];

        AM = GameObject.FindGameObjectWithTag("AM");
        gameOverSFX = AM.transform.GetChild(1).gameObject.GetComponent<AudioSource>();
        coinSFX = AM.transform.GetChild(2).gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        // Jump
        if ((Input.GetKeyDown(KeyCode.UpArrow) && jumpCount < maxJumpCount && onGround==false) || (Input.GetKeyDown(KeyCode.UpArrow) && onGround)) {  //GetKey: everytime, GetKeyDown: only the first time 
            rb.AddForce(Vector2.up * jumpSpeed);
            jumpCount++;
            jumpSFX.Play();
        }

        // Move to the right
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            rb.AddForce(Vector2.right * movementSpeed);
        }

        // Move to the left
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            rb.AddForce(Vector2.left * movementSpeed);
        }

        //customize it
        if (rb.velocity.y > jumpMaxVelocity) {
            rb.velocity = new Vector2(rb.velocity.x, jumpMaxVelocity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Coin") {
            coinSFX.Play();
            UIManager.score += 10;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Bullet") {
            gameOverSFX.Play();
            GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Enemy1") {
            gameOverSFX.Play();
            GameOver();
            //Invoke("GameOver", 1f); // FIX THIS: THIS CAUSES A DELAY ON THE PLAYER DYING
        }

        if (collision.gameObject.tag == "Ground") {
            onGround = true;
            jumpCount = 0;
            impactSFX.Play();
        }

    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            onGround = false;
        }
    }

    void GameOver() {
        SceneManager.LoadScene(2); //2: Game Over Scene
    }

}
