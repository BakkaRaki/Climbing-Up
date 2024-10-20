using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSPlayerCamera : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Rigidbody rb;

    public float rotationSpeed;

    public Transform combatLookAt;

    public GameObject basicCam;
    public GameObject combatCam;
    public GameObject topDownCam;
    public GameObject uiCam;


    public CameraStyle currentStyle;

    public enum CameraStyle
    {
        Basic,
        Combat, //not used 
        Topdown,    //not used
        UI
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //switch styles on keyboard
        if(Input.GetKeyDown(KeyCode.Alpha1))    SwitchCameraStyle(CameraStyle.Basic);
        if (Input.GetKeyDown(KeyCode.Alpha2))   SwitchCameraStyle(CameraStyle.Combat);
        if (Input.GetKeyDown(KeyCode.Alpha3))   SwitchCameraStyle(CameraStyle.Topdown);

        //rotate orientation
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        //rotate player object
        if (currentStyle == CameraStyle.Basic || currentStyle == CameraStyle.Topdown)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

            if (inputDir != Vector3.zero)
            {
                playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
            }
        }

        else if (currentStyle == CameraStyle.Combat)
        {
            Vector3 dirToCombatLookAt = combatLookAt.position - new Vector3(transform.position.x, combatLookAt.position.y, transform.position.z);
            orientation.forward = dirToCombatLookAt.normalized;

            playerObj.forward = dirToCombatLookAt.normalized;
        }


    }

    public void SwitchCameraStyle(CameraStyle newStyle)
    {
        combatCam.SetActive(false);
        basicCam.SetActive(false);
        topDownCam.SetActive(false);
        uiCam.SetActive(false);

        if (newStyle == CameraStyle.Basic) { basicCam.SetActive(true); }
        if (newStyle == CameraStyle.Combat) { combatCam.SetActive(true); }
        if (newStyle == CameraStyle.Topdown) { topDownCam.SetActive(true); }
        if(newStyle == CameraStyle.UI) { uiCam.SetActive(true);}

        currentStyle = newStyle;
    }
}
