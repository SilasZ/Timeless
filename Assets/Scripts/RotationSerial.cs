using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSerial : MonoBehaviour, ITimeSerial
{
    public int Deserialize(byte[] data, int index)
    {
        transform.rotation = Quaternion.Euler(0, 0, BitConverter.ToSingle(data, index));
        return 4;
    }

    public byte[] Serialize()
    {
        byte[] buffer = new byte[sizeof(float)];
        Buffer.BlockCopy(BitConverter.GetBytes(transform.rotation.eulerAngles.z), 0, buffer, 0, sizeof(float));
        return buffer;
    }
}
