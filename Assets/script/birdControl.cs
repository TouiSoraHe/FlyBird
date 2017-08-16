using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdControl : MonoBehaviour {
    private Rigidbody2D _rigidbody;
    private float height = 3.0f;
    private void Awake()
    {
        _rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
    }

    public void jump()
    {
        _rigidbody.velocity = Vector2.up * height;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "land" || collision.tag == "pipe")
        {
            gameController.instance.State = GameState.GameOver;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "backGround")
        {
            gameController.instance.State = GameState.GameOver;
        }
    }

}
