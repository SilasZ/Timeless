using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorder : MonoBehaviour
{

    public GameTime gameTime;
    Dictionary<int, byte[]> history;
    private ITimeSerial[] timeSerials;

    // Start is called before the first frame update
    void Start()
    {
        history = new Dictionary<int, byte[]>();
        timeSerials = GetComponentsInChildren<ITimeSerial>();
    }

    private void FixedUpdate()
    {
        if (history.ContainsKey(gameTime.Time))
        {
            foreach(ITimeSerial timeSerial in timeSerials) timeSerial.Deserialize(history[gameTime.Time]);
            Debug.Log(history[gameTime.Time]);
        }
        else
        {
            List<byte> data = new List<byte>();
            foreach (ITimeSerial timeSerial in timeSerials) data.AddRange(timeSerial.Serialize());
            history.Add(gameTime.Time, data.ToArray());
        }
    }

}
