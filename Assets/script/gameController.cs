using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour {
    public static gameController instance;
    private GameUI gameUI;
    private GameState _state;
    private GameObject bird;
    private InputController _input;
    private GameObject _land;
    private Text _scoreText;
    private Text overScoreText;
    private Text overBestText;
    private generatePipe _generatePipe;

    private Vector3 birdPosition;
    private Vector3 landPosion;
    private float bestScore;
    private int _score;

    public GameState State
    {
        get
        {
            return _state;
        }

        set
        {
            _state = value;
            changeGameState(_state);
        }
    }

    public int Score
    {
        get
        {
            return _score;
        }

        set
        {
            _score = value;
            _scoreText.text = value.ToString();
        }
    }

    public float BestScore
    {
        get
        {
            return bestScore;
        }

        set
        {
            if(value>bestScore)
                bestScore = value;
        }
    }

    private void Awake()
    {
        //Screen.SetResolution(345, 614, false);
        Screen.SetResolution(576, 1024, false);
        instance = this;
        gameUI = GameObject.Find("gameUI").GetComponent<GameUI>();
        bird = GameObject.FindGameObjectWithTag("bird");
        _input = GetComponent<InputController>();
        _land = GameObject.Find("land");
        _scoreText = GameObject.Find("gameUI/Playing/Text").GetComponent<Text>();
        overScoreText = GameObject.Find("gameUI/GameOver/scoreBoard/score").GetComponent<Text>();
        overBestText = GameObject.Find("gameUI/GameOver/scoreBoard/best").GetComponent<Text>();
        _generatePipe = GameObject.Find("generatePipe").GetComponent<generatePipe>();
        _input.mouseClick += mouseClickEvent;
        ButtonEvent.initialization();
    }

    private void Start()
    {
        State = GameState.Start;
        birdPosition = bird.transform.position;
        landPosion = _land.transform.position;
        Score = 0;
    }

    private void mouseClickEvent()
    {
        if (State == GameState.Playing)
        {
            bird.GetComponent<birdControl>().jump();
        }
        else if (State == GameState.Ready)
        {
            State = GameState.Playing;
        }
    }

    private void changeGameState(GameState state)
    {
        gameUI.updateUI(state);
        switch (state)
        {
            case GameState.Start:
                _land.SetActive(false);
                bird.SetActive(false);
                _generatePipe.enabled = false;
                break;
            case GameState.Ready:
                _land.SetActive(false);
                bird.SetActive(false);
                _generatePipe.enabled = false;
                initialization();
                break;
            case GameState.Playing:
                _land.SetActive(true);
                _land.GetComponent<LandMove>().IsMove = true;
                bird.SetActive(true);
                _generatePipe.enabled = true; 
                break;
            case GameState.GameOver:
                _land.SetActive(false);
                _land.GetComponent<LandMove>().IsMove = false;
                bird.SetActive(false);
                _generatePipe.enabled = false;
                foreach (GameObject item in GameObject.FindGameObjectsWithTag("pipe"))
                {
                    Destroy(item);
                }

                BestScore = Score;
                overScoreText.text = Score.ToString();
                overBestText.text = BestScore.ToString();
                break;
            default:break;
        }
    }

    private void initialization()
    {
        bird.transform.position = birdPosition ;
        _land.transform.position = landPosion;
        Score = 0;
    }
}