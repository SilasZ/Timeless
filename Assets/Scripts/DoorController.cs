using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour, IJump
{
    float timeZero = 0;
    public List<float> timeStamps = new List<float>();
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        timeZero = Time.time;
        FindObjectOfType<GameTime>().jumpObjects.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        bool closed = true;
        foreach (float time  in timeStamps)
        {
            if (Time.time > timeZero + time) closed = !closed;
        }
        door.SetActive(closed);
    }

    public void Jump()
    {
        timeZero = Time.time;
    }
}
