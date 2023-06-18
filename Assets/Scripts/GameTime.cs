using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTime : MonoBehaviour
{

    public int Time { get; set;}
    public GameObject playerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Time = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Time++;
        if (Time == 500)
        {
            
            foreach (var player in FindObjectsOfType<SetAsPlayer>())
            {
                if (player.GetComponent<PlayerMovement>().enabled)
                {
                    var newPlayer = Instantiate(playerPrefab, player.transform.position, player.transform.rotation);
                    newPlayer.GetComponent<SetAsPlayer>().IsPlayer(true);
                    player.GetComponent<SetAsPlayer>().IsPlayer(false);
                    break;
                }
            }
            Time = 0;
            Debug.Log("Jump");
        }
    }
}
