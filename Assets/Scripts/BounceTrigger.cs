using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceTrigger : MonoBehaviour
{

    public float bouncePower;

    private Rigidbody player;

    [Header("Sound")]
    public AudioClip bounceSound;
    private AudioSource bounceAudio;

    //private GameObject bounceObj;
    public Vector3 bounceDir;

    // Start is called before the first frame update
    void Start()
    {
        //bounceObj = GameObject.FindWithTag("bounceTrigger");
        bounceDir = new Vector3(0, 1, 0);
        bounceAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        ResetSpeedAndImpulse();
    }

    private void ResetSpeedAndImpulse()
    {
        player = GameObject.FindWithTag("Player").GetComponentInParent<Rigidbody>();
        player.velocity = Vector3.zero;
        player.AddForce(bounceDir * bouncePower, ForceMode.Impulse);
        bounceAudio.PlayOneShot(bounceSound, 1f);
}
}
