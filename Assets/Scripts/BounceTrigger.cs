using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceTrigger : MonoBehaviour
{

    public float bouncePower;

    private Rigidbody player;

    //private GameObject bounceObj;
    //private Vector3 bounceDir;

    // Start is called before the first frame update
    void Start()
    {
        //bounceObj = GameObject.FindWithTag("bounceTrigger");
        //bounceDir = bounceObj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        player = other.GetComponentInParent<Rigidbody>();
        player.AddForce(new Vector3(0, 1, 1) * bouncePower, ForceMode.Impulse);     
    }
}
