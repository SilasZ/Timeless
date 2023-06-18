using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSerial : MonoBehaviour, ITimeSerial
{
    public int Deserialize(byte[] data, int index)
    {
        Vector3 position = Vector3.zero;
        gameObject.SetActive(BitConverter.ToBoolean(data, index));
        transform.position = position;
        return sizeof(bool);
    }

    public byte[] Serialize()
    {
        byte[] buffer = new byte[sizeof(bool)];
        Buffer.BlockCopy(BitConverter.GetBytes(gameObject.activeSelf), 0, buffer, 0, sizeof(bool));
        return buffer;
    }
}
