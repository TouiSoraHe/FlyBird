using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public GameObject start;
    public GameObject ready;
    public GameObject playing;
    public GameObject gameOver;

    public void updateUI(GameState _gameState)
    {
        switch (_gameState)
        {

            case GameState.Start:
                start.SetActive(true);
                ready.SetActive(false);
                playing.SetActive(false);
                gameOver.SetActive(false);
                break;
            case GameState.Playing:
                start.SetActive(false);
                ready.SetActive(false);
                playing.SetActive(true);
                gameOver.SetActive(false);
                break;
            case GameState.Ready:
                start.SetActive(false);
                ready.SetActive(true);
                playing.SetActive(false);
                gameOver.SetActive(false);
                break;
            case GameState.GameOver:
                start.SetActive(false);
                ready.SetActive(false);
                playing.SetActive(false);
                gameOver.SetActive(true);
                break;
            default:
                break;
        }
    }
}
