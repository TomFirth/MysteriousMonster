using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter : MonoBehaviour
{
    public Transform movePoint;
    public LayerMask grass;

    void FixedUpdate()
    {
        if (Physics2D.OverlapCircle(movePoint.position, .2f, grass))
        {
            Debug.Log("Encounter");
            // set random chance to start encounter
        }
    }
}
