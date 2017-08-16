using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePipeUpPos : MonoBehaviour {

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "backGround")
        {
            Destroy(this.gameObject);
        }
        else if (collision.tag == "score")
        {
            gameController.instance.Score = gameController.instance.Score + 1;
        }
    }
}
