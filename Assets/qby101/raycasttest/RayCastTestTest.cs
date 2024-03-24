using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastTestTest : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(this.transform.position, Vector2.up);
        RaycastHit2D hit2 = Physics2D.BoxCast(this.transform.position, new Vector2(1, 1), 0, Vector2.up);
        foreach (RaycastHit2D h in hit)
        {
            Debug.Log(h.collider.gameObject.name);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        //Debug.DrawLine(this.transform.position, this.transform.position + Vector3.up * 10, Color.red);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(this.transform.position, new Vector3(1, 1, 1));
    }
}
