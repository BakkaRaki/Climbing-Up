using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using static TPSPlayerCamera;

public class GameManager : MonoBehaviour
{

    public bool isGameActive; 
    private int roundTime;
    private int playerTime;

    [Header("UI")]
    public GameObject titleScreen;
    public Button restartButton;
    public Button startButton;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI roundTimeText;
    public TextMeshProUGUI playerTimeText;   

    [Header("Player")]
    private GameObject player;
    private Vector3 initPlayerPos;

    [Header("Sounds")]
    public AudioClip deathSound;
    public AudioClip saveSound;
    private AudioSource managerAudio;

    [Header("Cameras")]
    public TPSPlayerCamera cameraScript;




    // Start is called before the first frame update
    void Start()
    {
        titleScreen.gameObject.SetActive(true);
        managerAudio = GetComponent<AudioSource>();
        cameraScript = GameObject.FindWithTag("UICamera").GetComponent<TPSPlayerCamera>();
        cameraScript.SwitchCameraStyle(CameraStyle.UI);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
            ResetPlayer();
        }

    }

    //Reset poisition when player drop
    private void ResetPlayer()
    {
        if(player.transform.position.y < 0 )
        {
            player.transform.position = initPlayerPos;
            managerAudio.PlayOneShot(deathSound, 3.0f);
            //GameOver();
        }
    }

    public void SavePosition(Vector3 pos)
    {
        initPlayerPos = pos;
        managerAudio.PlayOneShot(saveSound, 1.0f);
    }

    private void ChangeMouseState()
    {
        if(isGameActive)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if(!isGameActive)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    IEnumerator RoundTimer()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(1);
            roundTime--;
            roundTimeText.text = "Time Left: " + roundTime;
            if (roundTime <= 0)
            {
                GameOver();
                yield break;
            }
        }
    }

    IEnumerator PlayerTimer()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(1);
            playerTime++;
            playerTimeText.text = "Your Time: " + playerTime;
            if (roundTime <= 0)
            {
                GameOver();
                yield break;
            }
        }
    }

    public void StartMyGame()
    {
        isGameActive = true;

        // camera ready
        ChangeMouseState();
        cameraScript.SwitchCameraStyle(CameraStyle.Basic);

        //UI ready
        roundTimeText.gameObject.SetActive(true);
        playerTimeText.gameObject.SetActive(true);
        titleScreen.gameObject.SetActive(false);

        //initialize time setting
        roundTime = 600;
        playerTime = 0;
        StartCoroutine(RoundTimer());
        StartCoroutine(PlayerTimer());

        //initialize player and its position
        player = GameObject.FindWithTag("Player");
        initPlayerPos = new Vector3(0, 2, 0);
        player.transform.position = initPlayerPos;

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        isGameActive = false;
        ChangeMouseState();
        cameraScript.SwitchCameraStyle(CameraStyle.UI);
        roundTimeText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }
}
