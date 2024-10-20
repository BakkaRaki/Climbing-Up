using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UIElements;

public class SavePoint : MonoBehaviour
{

    private GameObject player;
    private GameManager gameManagerScript;

    private float rotateSpeed = 60f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        gameManagerScript = GameObject.FindWithTag("GameController").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed, Space.Self);    //make if self auto rotated
       
        //should add particals around when rotate
    }

    //Save current position when triggered
    private void OnTriggerEnter(Collider other)
    {
        gameManagerScript.SavePosition(other.transform.position);
        Destroy(gameObject);
    }


        



}
