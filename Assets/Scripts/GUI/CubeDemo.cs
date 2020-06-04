using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDemo : MonoBehaviour
{
    public float rotateSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(new Vector3(0, 1f * rotateSpeed *  Time.deltaTime, 0), Space.World);
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 50, 30), "Pause")) {

            Time.timeScale = 0;
            Debug.Log(Time.deltaTime);
        }
        if (GUI.Button(new Rect(0, 35, 50, 30), "Rotate")) {

            Time.timeScale = 1;
        }
        if (GUI.Button(new Rect(0, 70, 50, 30), "Speed")) {

            Time.timeScale = 2;
        }
    }
}
