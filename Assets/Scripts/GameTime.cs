using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTime : MonoBehaviour
{

    public int Time { get; set;}
    public GameObject playerPrefab;

    private bool timeJump = false;

    // Start is called before the first frame update
    void Start()
    {
        Time = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) timeJump = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Time++;
        if (timeJump)
        {
            timeJump = false;
            foreach (var player in FindObjectsOfType<SetAsPlayer>())
            {
                if (player.GetComponent<PlayerMovement>().enabled)
                {
                    var newPlayer = Instantiate(playerPrefab, player.transform.position, player.transform.rotation);
                    newPlayer.GetComponentInChildren<SetAsPlayer>().IsPlayer(true);
                    player.gameObject.SetActive(false);
                    player.GetComponentInParent<Recorder>().Record();
                    player.GetComponentInChildren<SetAsPlayer>().IsPlayer(false);
                    break;
                }
            }
            Time = 0;
            Debug.Log("Jump");
        }
    }
}
