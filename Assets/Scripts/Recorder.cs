using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorder : MonoBehaviour
{

    private GameTime gameTime;
    Dictionary<int, byte[]> history;
    private ITimeSerial[] timeSerials;

    // Start is called before the first frame update
    void Start()
    {
        history = new Dictionary<int, byte[]>();
        timeSerials = GetComponentsInChildren<ITimeSerial>();
        gameTime = FindObjectOfType<GameTime>();
    }

    private void FixedUpdate()
    {
        if (history.ContainsKey(gameTime.Time))
        {
            int position = 0;
            foreach (ITimeSerial timeSerial in timeSerials)
            {
                position += timeSerial.Deserialize(history[gameTime.Time], position);
            }
        }
        else
        {
            Record();
        }
    }

    public void Record()
    {
        List<byte> data = new List<byte>();
        foreach (ITimeSerial timeSerial in timeSerials) data.AddRange(timeSerial.Serialize());
        history.Add(gameTime.Time, data.ToArray());
    }

}
