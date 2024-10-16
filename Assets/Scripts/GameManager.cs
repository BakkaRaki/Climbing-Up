using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject player;

    private Vector3 initPlayerPos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        initPlayerPos = new Vector3(0, 2, 0);
        player.transform.position = initPlayerPos;
    }

    // Update is called once per frame
    void Update()
    {
        ResetPlayer();
    }

    //Reset poisition when player drop
    private void ResetPlayer()
    {
        if(player.transform.position.y < 0)
        {
            player.transform.position = initPlayerPos;
        }
    }

    public void SavePosition(Vector3 pos)
    {
        initPlayerPos = pos;
    }
}
