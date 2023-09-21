using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public int speed = 3;

    public GameObject platform;
    public GameObject enemy_platform;
    public GameObject star_platform;

    float default_timer;
    float enemy_timer;
    float star_timer;

    Vector3 platform_vector;
    Vector3 enemy_vector;
    Vector3 star_vector;

    //Camera cam;
    //float camHeight;
    //float camWidth;

    // Start is called before the first frame update
    void Start() {
        //cam = Camera.main;
        //camHeight = 2f * cam.orthographicSize;
        //camWidth = camHeight * cam.aspect;

        default_timer = Random.Range(2f, 5f);
        enemy_timer = Random.Range(6f, 12f);
        star_timer = Random.Range(7f, 14f);
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
        default_timer -= Time.deltaTime;
        enemy_timer -= Time.deltaTime;
        star_timer -= Time.deltaTime;

        if (default_timer < 0) {
            platform_vector = new Vector3(Random.Range(-10f, 10f), transform.position.y + 5, 0); // LATEST PLATFORM'S VECTOR
            //Instantiate(platform, new Vector3(Random.Range(-10f, 10f), transform.position.y+5, 0), Quaternion.identity);
            Instantiate(platform, platform_vector, Quaternion.identity);
            default_timer = Random.Range(2f, 5f);
        }

        if (enemy_timer < 0) {
            enemy_vector = new Vector3(Random.Range(-10f, 10f), transform.position.y + 5, 0); // LATEST ENEMY PLATFORM'S VECTOR
            //Instantiate(enemy_platform, new Vector3(Random.Range(-10f, 10f), transform.position.y + 5, 0), Quaternion.identity);
            Instantiate(enemy_platform, enemy_vector, Quaternion.identity);
            enemy_timer = Random.Range(2f, 5f);
        }

        if (star_timer < 0) {
            star_vector = new Vector3(Random.Range(-10f, 10f), transform.position.y + 5, 0); // LATEST STAR PLATFORM'S VECTOR
            //Instantiate(star_platform, new Vector3(Random.Range(-10f, 10f), transform.position.y + 5, 0), Quaternion.identity);
            Instantiate(star_platform, star_vector, Quaternion.identity);
            star_timer = Random.Range(2f, 5f);
        }
    }
}   
