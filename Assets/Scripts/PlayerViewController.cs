using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerViewController : MonoBehaviour
{
    public Transform rotatedObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 playerToMouseDirection = mouseWorldPosition - transform.position;
        float angle = Vector2.Angle(Vector2.right, playerToMouseDirection);
        float correctionPresign = mouseWorldPosition.y < rotatedObject.position.y ? -1 : 1;
        Quaternion rot = Quaternion.Euler(0, 0, correctionPresign * angle);
        rotatedObject.rotation = rot;
    }
}
