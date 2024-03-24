using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class colliderTest : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Collision Stay");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Collision Exit");
    }
    // Start is called before the first frame update
}
