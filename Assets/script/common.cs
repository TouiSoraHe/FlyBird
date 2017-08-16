using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState {
    Start,
    Ready,
    Playing,
    GameOver
}

public delegate void Del();

public static class ButtonEvent
{
    static int s = 1;
    public static void initialization()
    {
        GameObject.Find("gameUI/Start/startBtn").GetComponent<Button>().onClick.AddListener(startBtn);
        GameObject.Find("gameUI/GameOver/okBtn").GetComponent<Button>().onClick.AddListener(okBtn);
        GameObject.Find("gameUI/Playing/pauseBtn").GetComponent<Button>().onClick.AddListener(pauseBtn);
    }

    private static void startBtn()
    {
        gameController.instance.State = GameState.Ready;
    }

    private static void okBtn()
    {
        gameController.instance.State = GameState.Start;
    }

    public static void pauseBtn()
    {
        if (s == 0)
        {
            s = 1;
            Time.timeScale = 1;
            GameObject.Find("gameUI/Playing/pauseBtn").GetComponent<Button>().image.sprite = Resources.Load<Sprite>("button_pause");
        }
        else if (s == 1)
        {
            s = 0;
            Time.timeScale = 0;
            GameObject.Find("gameUI/Playing/pauseBtn").GetComponent<Button>().image.sprite = Resources.Load<Sprite>("button_resume");
        }
    }

}
