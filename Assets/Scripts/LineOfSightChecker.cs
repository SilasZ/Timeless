using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSightChecker : MonoBehaviour
{
    public Transform castOrigin;
    public List<Collider2D> myOwnColliders = new List<Collider2D>();

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.GetComponentInParent<PlayerMovement>() &&
            collision.transform.GetComponentInParent<PlayerMovement>().isActiveAndEnabled)
        {
            foreach (Collider2D collider in myOwnColliders)
            {
                collider.enabled = false;
            }
            var hit = Physics2D.Raycast(castOrigin.position, collision.transform.GetComponentInParent<PlayerMovement>().transform.position - castOrigin.position);
            if (hit.collider.GetComponentInParent<PlayerMovement>() != null)
                Debug.Log("GG bro!");

            foreach (Collider2D collider in myOwnColliders)
            {
                collider.enabled = true;
            }
        }
    }

}