using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IJump
{
    public void Jump();
}

public class GameTime : MonoBehaviour
{

    public int Time { get; set;}
    public GameObject playerPrefab;
    public List<IJump> jumpObjects = new List<IJump>();
    private bool timeJump = false;

    public delegate void AfterTimeUpdate();

    public event AfterTimeUpdate afterTimeUpdate;

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
                    newPlayer.GetComponent<SetAsPlayer>().IsPlayer(true);
                    player.gameObject.SetActive(false);
                    player.GetComponent<Recorder>().Record();
                    player.GetComponent<SetAsPlayer>().IsPlayer(false);
                    break;
                }
            }
            Time = 0;
            Debug.Log("Jump");

            foreach(IJump jumpObject in jumpObjects)
            {
                jumpObject.Jump();
            }
        }
        afterTimeUpdate?.Invoke();

    }
}
