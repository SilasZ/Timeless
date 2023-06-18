using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSerial : MonoBehaviour, ITimeSerial
{
    public void Deserialize(byte[] data)
    {
        transform.rotation = Quaternion.AngleAxis(BitConverter.ToSingle(data, 0 * sizeof(float)), Vector3.forward);
    }

    public byte[] Serialize()
    {
        byte[] buffer = new byte[sizeof(float)];
        Buffer.BlockCopy(BitConverter.GetBytes(transform.rotation.eulerAngles.z), 0, buffer, 0 * sizeof(float), sizeof(float));
        return buffer;
    }
}
