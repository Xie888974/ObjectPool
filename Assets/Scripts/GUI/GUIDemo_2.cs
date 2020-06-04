using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIDemo_2 : MonoBehaviour
{
    public GUISkin skin;

    private void OnGUI()
    {
        GUI.skin = skin;
        //GUI.Button(new Rect(0, 0, 100, 50), "", skin.GetStyle("Call"));
        //GUI.Label(new Rect(0, 60, 200, 50), "Hello World!!");

        for (int i = 0; i < 5; i++) {

            for (int j = 0; j < 5; j++) {

                if (GUI.Button(new Rect(100 * j, 100 * i, 80, 80), "", skin.GetStyle("Call"))) {

                    //ButtonClicked(i * 5 + j);
                }
            }
        }
    }
}
