using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {
    public event Del mouseClick;


    // Update is called once per frame
    void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            mouseClick();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            mouseClick();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            ButtonEvent.pauseBtn();
        }
    }
}
