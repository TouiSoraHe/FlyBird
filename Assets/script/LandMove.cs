using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMove : MonoBehaviour {
    private float landSpeed;
    private float initialSpeed = 2.0f;
    private Vector3 startPosition;
    private float x = 0.0f;//增加速度时的修正x+=Time.time*速度的增量
    private float time = 0.0f;
    private bool isMove = true;
    private float scoreSpeed = 70.0f;

    public bool IsMove
    {
        get
        {
            return isMove;
        }

        set
        {
            isMove = value;
            if (value == true)
            {
                this.enabled = true;
            }
            else
            {
                time = 0.0f; 
                this.enabled = false;
            }
        }
    }


    // Use this for initialization
    void Start () {
        startPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        time += UnityEngine.Time.deltaTime;
        x += ((gameController.instance.Score / scoreSpeed + initialSpeed) - landSpeed) * time;
        landSpeed = (gameController.instance.Score / scoreSpeed) + initialSpeed;
        float position = Mathf.Repeat(time*landSpeed-x, 10.0f);
        this.transform.position = startPosition - Vector3.right * position;
    }
}
