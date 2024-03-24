using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//2d射线检测
public class RayCastTest : MonoBehaviour
{
    // Start is called before the first frame update
    Ray2D ray;
    RaycastHit2D hit;

    public LayerMask layerMask;
    //2d专属射线检测变量
    public ContactFilter2D contactFilter2D;
    

    private void Start()
    {
        //ray = new Ray2D(transform.position, Vector2.right);
        hit = Physics2D.Raycast(ray.origin, ray.direction, 10, layerMask);
        hit = Physics2D.Raycast(ray.origin, ray.direction, 10, layerMask.value);

        hit = Physics2D.BoxCast(ray.origin, new Vector2(1, 1), 0, ray.direction, 10, layerMask);
        hit = Physics2D.CircleCast(ray.origin, 1, ray.direction, 10, layerMask);
        hit = Physics2D.CapsuleCast(ray.origin, new Vector2(1, 1), CapsuleDirection2D.Vertical, 0, ray.direction, 10, layerMask);
        hit = Physics2D.Linecast(ray.origin, ray.origin + ray.direction * 10, layerMask);
        hit =Physics2D.Raycast(ray.origin, ray.direction, 10, layerMask, 0, 0);
        //bool isGround = Physics2D.OverlapArea(point1,point2);
        //bool isGround = Physics2D.OverlapBox(groundCheck.position, groundCheck.localScale, 0, layerMask);
        //bool isGround = Physics2D.OverlapCapsule(point1, point2, CapsuleDirection2D.Vertical, 0, layerMask);
        //bool isGround = Physics2D.OverlapCircle(point, 1, layerMask);
        //bool isGround = Physics2D.OverlapPoint(point, layerMask);
    }

    //绘制射线
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(ray.origin, ray.origin + ray.direction * 10);
        Gizmos.DrawCube(hit.point, Vector3.one);
        Gizmos.DrawRay(ray.origin, ray.direction * 10);

    }
}
