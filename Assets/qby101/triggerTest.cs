using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerTest : MonoBehaviour
{
    public LayerMask layerMask;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer==6)
        {
            Debug.Log("Player Trigger Enter");
            var colorGreen = new Color(0, 1, 0, 0.3f);
            this.GetComponent<SpriteRenderer>().color = colorGreen;
        }
        else
        {
            Debug.Log("Trigger Enter");
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    var colorRed = new Color(1, 0, 0, 0.3f);
    //    this.GetComponent<SpriteRenderer>().color = colorRed;
    //    Debug.Log("Trigger Exit");
    //}
}
