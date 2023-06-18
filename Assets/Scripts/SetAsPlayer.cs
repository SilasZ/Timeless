using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SetAsPlayer : MonoBehaviour
{
    public List<Behaviour> activateForPlayer = new List<Behaviour>();
    public List<Behaviour> deactivateForPlayer = new List<Behaviour>();

    public void IsPlayer(bool setAsPlayer)
    {
        foreach (var item in activateForPlayer)
        {
            item.enabled = setAsPlayer;
        }

        foreach (var item in deactivateForPlayer)
        {
            item.enabled = !setAsPlayer;
        }
    }
}
