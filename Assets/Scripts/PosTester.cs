using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosTester : MonoBehaviour
{
    public float Y;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y + Y));
    }
}
