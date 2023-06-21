using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Transform player = null;
        foreach (var v in FindObjectsByType<PlayerMovement>(FindObjectsSortMode.None))
        {
            
            if (v.enabled)
            {
                player = v.transform;
            }
        }
        if (player != null) transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
