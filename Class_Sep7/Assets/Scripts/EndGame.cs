using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {
    float scene_load_time;

    // Start is called before the first frame update
    void Start() {
        scene_load_time = 5f;
    }

    // Update is called once per frame
    void Update() {
        if(scene_load_time < 0) {
            SceneManager.LoadScene(0);
        }
        scene_load_time -= Time.deltaTime;
    }
}
