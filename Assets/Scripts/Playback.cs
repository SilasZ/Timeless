using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playback : MonoBehaviour
{
    
    Dictionary<int, List<Transform>> history;

    // Start is called before the first frame update
    void Start()
    {
        history = new Dictionary<int, List<Transform>>();
    }

    private void FixedUpdate()
    {

    }

    public void AddRecord(Transform transform)
    {
        int instanceID = GetInstanceID();
        if (!history.ContainsKey(instanceID)) history.Add(instanceID, new List<Transform>());
        history[instanceID].Add(transform);
    }
}
