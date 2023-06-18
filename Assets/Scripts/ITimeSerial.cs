using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITimeSerial
{
    public byte[] Serialize();
    public int Deserialize(byte[] data, int index);
}
