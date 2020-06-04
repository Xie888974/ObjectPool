using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIDemo : MonoBehaviour
{
    string _userName;
    string _pwd;
    int _selectIndex;
    bool _togCheck_1 = false;
    bool _togCheck_2 = false;
    float _sliderVale = 0;
    float _sliderMax = 100;
    float _sliderMin = 0;

    bool _isShowWindlow = false;

    void AddWindow(int winId) {

        if (GUILayout.Button("Exit")) {

            _isShowWindlow = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {

        if (GUILayout.Button("Show Window")) {

            _isShowWindlow = true;
        }
        if (_isShowWindlow) {

            GUILayout.Window(0, new Rect(100, 100, 200, 200), AddWindow, "MyWindow");
        }


        //GUIStyle style = new GUIStyle();
        //style.fontSize = 20;
        //style.normal.textColor = Color.black;
        //GUILayout.BeginArea(new Rect(0, 0, 200, 500));
        //GUILayout.Label("Hello");
        //GUILayout.Label("Killer");
        //GUILayout.Label("You",style);
        //GUILayout.Label("Die",style);
        //GUILayout.Button("Click", GUILayout.Width(100),GUILayout.Height(30)) ;
        //GUILayout.EndArea();

        //GUI.Label(new Rect(0, 0, 100, 30), "Welcome");
        //_userName = GUI.TextField(new Rect(0, 40, 100, 30), _userName);
        //_pwd = GUI.TextField(new Rect(0, 80, 100, 30), _pwd);
        //_selectIndex = GUI.Toolbar(new Rect(0, 120, 200, 30), _selectIndex, new string[] { "单机", "网络", "退游" });
        //_togCheck_1 = GUI.Toggle(new Rect(0, 160, 100, 30), _togCheck_1, "Cheat");
        //_togCheck_2 = GUI.Toggle(new Rect(0, 200, 100, 30), _togCheck_2, "Console");
        //_sliderVale = GUI.HorizontalSlider(new Rect(0, 240, 200, 30),_sliderVale,_sliderMin,_sliderMax);
    }
}
