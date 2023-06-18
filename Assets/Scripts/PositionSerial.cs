using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformSerial : MonoBehaviour, ITimeSerial
{
    public void Deserialize(byte[] data)
    {
        Vector3 position = Vector3.zero;
        position.x = BitConverter.ToSingle(data, 0 * sizeof(float));
        position.y = BitConverter.ToSingle(data, 1 * sizeof(float));
        position.z = BitConverter.ToSingle(data, 2 * sizeof(float));
        transform.position = position;
    }

    public byte[] Serialize()
    {
        byte[] buffer = new byte[sizeof(float) * 3];
        Buffer.BlockCopy(BitConverter.GetBytes(transform.position.x), 0, buffer, 0 * sizeof(float), sizeof(float));
        Buffer.BlockCopy(BitConverter.GetBytes(transform.position.y), 0, buffer, 1 * sizeof(float), sizeof(float));
        Buffer.BlockCopy(BitConverter.GetBytes(transform.position.z), 0, buffer, 2 * sizeof(float), sizeof(float));
        return buffer;
    }
}
