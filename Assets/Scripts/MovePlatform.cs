using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{

    private Vector3 initPos;

    private GameObject movePlatform;

    public int currentMoveStyle;
    public float moveLength;
    public float timeVar;


    
    // Start is called before the first frame update
    void Start()
    {
        movePlatform = GetComponent<GameObject>();
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentMoveStyle != 0 || currentMoveStyle != 1 || currentMoveStyle != 2)    Debug.Log("missing currentMoveStyle");
        if (currentMoveStyle == 0) MoveX();
        if (currentMoveStyle == 1) MoveY();
        if (currentMoveStyle == 2) MoveZ();
    }

    private void MoveX()
    {
        transform.position = new Vector3(initPos.x + Mathf.PingPong(Time.time * timeVar, moveLength), initPos.y, initPos.z);
    }

    private void MoveY()
    {
        transform.position = new Vector3(initPos.x, initPos.y + Mathf.PingPong(Time.time * timeVar, moveLength), initPos.z);
    }
    
    private void MoveZ()
    {
        transform.position = new Vector3(initPos.x, initPos.y, initPos.z + Mathf.PingPong(Time.time * timeVar, moveLength));
    }



}
