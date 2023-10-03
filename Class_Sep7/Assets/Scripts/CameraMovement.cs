using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public int speed = 3;

    public GameObject platform;
    public GameObject enemy_platform;
    public GameObject star_platform;
    public GameObject platformGroup1;

    float group1_timer;

    Vector3 platform_vector;
    Vector3 enemy_vector;
    Vector3 star_vector;

    const float DEFAULT_TIMER = 7f;

    // Start is called before the first frame update
    void Start() {
        //group1_timer = Random.Range(10f, 15f);
        group1_timer = DEFAULT_TIMER;
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
        group1_timer -= Time.deltaTime;

        if (group1_timer < 0) {
            platform_vector = new Vector3(Random.Range(-10f, 10f), transform.position.y + 5, 0); // LATEST PLATFORM'S VECTOR

            //Instantiate(platform, platform_vector, Quaternion.identity);
            Instantiate(platformGroup1, platform_vector, Quaternion.identity);

            //group1_timer = Random.Range(10f, 15f);
            group1_timer = DEFAULT_TIMER;
        }
    }
}   
