using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public interface IJump
{
    public void Jump();
}

public class GameTime : MonoBehaviour
{

    public int Time { get; set;}
    public GameObject playerPrefab;
    public Material timeJumpMaterial;
    public Material paradoxMaterial;
    public List<IJump> jumpObjects = new List<IJump>();
    private bool timeJump = false;
    private int swirlStrength = 0;
    private bool gameOver = false;
    private float glitchStrength = 0;

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
        if (gameOver)
        {
            glitchStrength += .01f;
            paradoxMaterial.SetFloat("_Strength", glitchStrength);
            if (glitchStrength > 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                paradoxMaterial.SetFloat("_Strength", 0);
            }
            return;
        }
        if (timeJump)
        {
            swirlStrength += 2;
            timeJumpMaterial.SetFloat("_Strength", swirlStrength);
        }
        else if (swirlStrength > 0)
        {
            swirlStrength -= 2;
            timeJumpMaterial.SetFloat("_Strength", swirlStrength);
        }
        Time++;
        if (swirlStrength == 50)
        {
            timeJump = false;
            foreach (var player in FindObjectsByType<SetAsPlayer>(FindObjectsSortMode.None))
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
            

            foreach (IJump jumpObject in jumpObjects)
            {
                jumpObject.Jump();
            }
        }
        afterTimeUpdate?.Invoke();

    }

    public void GameOver()
    {
        gameOver = true;
    }
}
