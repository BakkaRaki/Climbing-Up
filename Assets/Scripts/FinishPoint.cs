using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    private GameObject player;
    private GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        gameManagerScript = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        gameManagerScript.SavePassTime(gameManagerScript.playerTime);
        gameManagerScript.Goal();
    }
}
