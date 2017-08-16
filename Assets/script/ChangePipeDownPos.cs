using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePipeDownPos : MonoBehaviour {
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "backGround")
        {
            Destroy(this.gameObject);
        }
    }
}
