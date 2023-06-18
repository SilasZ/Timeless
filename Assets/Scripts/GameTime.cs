using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTime : MonoBehaviour
{

    public int Time { get; set;}

    // Start is called before the first frame update
    void Start()
    {
        Time = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Time++;
        if (Time == 100)
        {
            FindObjectOfType<SetAsPlayer>().IsPlayer(false);
            Time = 0;
            Debug.Log("Jump");
        }
    }
}
