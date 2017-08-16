using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generatePipe : MonoBehaviour {
    public GameObject pipe_down;
    public GameObject pipe_up;

    private float speed=0.0f;
    private float time = 0.0f;
    private float lastTime;
    private float initialCd = 1.5f;//初始速度
    private float cd;
    private float scoreCd=200.0f;//每scoreCd分数,减少1.0cd

    private void Start()
    {
        cd = initialCd;
    }
    private void Update()
    {
        if (cd > 0.5f)
        {
            cd = initialCd - gameController.instance.Score / scoreCd;
        }
        time += UnityEngine.Time.deltaTime;
        if (time >= lastTime)
        {
            lastTime = time + cd;
            float downPositionY = 0.0f;
            float upPositionY = 0.0f;
            while (downPositionY-upPositionY<6)
            {
                upPositionY = Random.Range(-5f, -0.8f);
                downPositionY = Random.Range(2.6f, 7);
            }
            Instantiate(pipe_up, new Vector3(4.5f,upPositionY , 0.0f), Quaternion.identity).transform.parent=this.transform;//-5.....-0.8
            Instantiate(pipe_down, new Vector3(4.5f, downPositionY, 0.0f), Quaternion.identity).transform.parent = this.transform;//2.6.....7
        }
    }

}
