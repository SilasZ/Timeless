using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITimeSerial
{
    public byte[] Serialize();
    public void Deserialize(byte[] data);
}
