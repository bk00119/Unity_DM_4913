using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public int speed = 3;
    public GameObject platform;
    float timer = 2f;
    Camera cam;
    float camHeight;
    float camWidth;

    // Start is called before the first frame update
    void Start() {
        cam = Camera.main;
        camHeight = 2f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
        timer -= Time.deltaTime;
        if (timer < 0) {
            Instantiate(platform, new Vector3(Random.Range(-10f, 10f), transform.position.y+5, 0), Quaternion.identity);
            timer = 2f;
        }
    }
}   
