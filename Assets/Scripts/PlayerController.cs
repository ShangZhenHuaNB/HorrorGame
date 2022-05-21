using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class PlayerController : MonoBehaviour
{
    private CurveControlledBob headBob = new CurveControlledBob();

    [Header("JoyStick")]
    public FixedJoystick leftJoyStick;
    public DynamicJoystick rightJoyStick;
    [Header("Move")]
    public float moveSpeed;
    [Header("Rotation")]
    public float rotaSpeed;
    public float rotaMax;
    public float rotaMin;
    private float rota;

    public AudioSource walkAudio;
    public AudioClip walkAudioClip;


    private Rigidbody playerRig;
    private Vector3 dir;


    // Start is called before the first frame update
    void Start()
    {
        headBob.Setup(Camera.main,1.0f);
        playerRig = GetComponent<Rigidbody>();
   
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void Update()
    {
        float h = leftJoyStick.Horizontal * moveSpeed;
        float v = leftJoyStick.Vertical * moveSpeed;
        if (h!=0 || v!= 0)
        {
            dir = transform.forward * v + transform.right * h;
            playerRig.velocity = dir;
            if (!walkAudio.isPlaying)
            {
                walkAudio.PlayOneShot(walkAudioClip);
            }
            
            Debug.Log("need to play");

        } else
        {
            playerRig.velocity = Vector3.zero;
            walkAudio.Stop();
        }

        float h_ro = rightJoyStick.Horizontal * Time.deltaTime * rotaSpeed;
        float v_ro = rightJoyStick.Vertical * Time.deltaTime * rotaSpeed;
        if (v_ro != 0)
        {
            rota += v_ro;
            rota = Mathf.Clamp(rota, rotaMin, rotaMax);
            Camera.main.transform.localRotation = Quaternion.Euler(-rota, 0, 0);
        }
        if (h_ro != 0)
        {
            transform.Rotate(transform.up, h_ro);
        }




    }
}
