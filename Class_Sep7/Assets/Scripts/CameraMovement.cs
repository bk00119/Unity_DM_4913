using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public int speed = 3;

    public GameObject[] platformGroup = new GameObject[5];
    float[] platform_timer = { 7.0f, 5.0f, 4.0f, 7.0f, 3.0f };
    const float START_TIMER = 6.0f;
    float timer;
    int platform_type;

    Vector3 platform_vector;

    // Start is called before the first frame update
    void Start() {
        timer = START_TIMER;
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
        timer -= Time.deltaTime;

        if (timer < 0) {
            platform_vector = new Vector3(Random.Range(-10f, 10f), transform.position.y + 5, 0); // LATEST PLATFORM'S 
            platform_type = Random.Range(0, platform_timer.Length);
            Instantiate(platformGroup[platform_type], platform_vector, Quaternion.identity);
            timer = platform_timer[platform_type];
        }

    }
}   
