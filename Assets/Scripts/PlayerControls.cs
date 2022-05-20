using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class PlayerControls : MonoBehaviour
{
    [Header("Playership movemnets")]
    [Tooltip("Player speed is controlled")]
    [SerializeField] float movementSpeed;
    [Tooltip("Player X-limit is controlled")] [SerializeField] float xRange;
    [Tooltip("Player Y-limit is controlled")] [SerializeField] float yRange;
    [Header("Playership tuning")]
     [SerializeField] float pitchPosition=-3f;
    [SerializeField] float controlPitch = -10;
    [SerializeField] float yawPosition = -3;
    [SerializeField] float controlRoll = -15;
    [Header("Player lasers")]
    [SerializeField] GameObject[] lasers;
    [SerializeField] AudioClip laserSound;
    [SerializeField] float gameTime;
    float timeCount;

    AudioSource AS;
    sceneloader SL;


    float xControls;
    float yControls;
   
    void Start()
    {
        AS = GetComponent<AudioSource>();
        SL = FindObjectOfType<sceneloader>();
    }



   
   
   
    void Update()
    {
        CountTime();
        PlayerMovement();
        PlayerRotation();
        PlayerFire();
    }
    void CountTime()
    {
        timeCount += Time.deltaTime;
        if (timeCount > gameTime)
        {
            SL.LoadNextScene();
        }
    }
   void PlayerRotation()
    {
       float pitchDueToPos = transform.localPosition.y * pitchPosition;
        float pitchDueToControl = yControls * controlPitch;
       float pitch =  pitchDueToPos+ pitchDueToControl;
       float yaw=transform.localPosition.x*yawPosition;
       float roll=xControls*controlRoll;
       transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }

    private void PlayerMovement()
    {
        xControls = Input.GetAxis("Horizontal");
        yControls = Input.GetAxis("Vertical");
        float xmovement = xControls * Time.deltaTime * movementSpeed;
        float xpos = transform.localPosition.x + xmovement;
        float clampXpos = Mathf.Clamp(xpos, -xRange, xRange);
        float ymovement = yControls * Time.deltaTime * movementSpeed;
        float ypos = transform.localPosition.y + ymovement;
        float clampYpos = Mathf.Clamp(ypos, -yRange, yRange);
        transform.localPosition = new Vector3(clampXpos, clampYpos, transform.localPosition.z);
    }
    private void PlayerFire()
    {
        if(Input.GetButton("Fire1"))
        {
            SetLaser(true);
            if(!AS.isPlaying)
            {
                AS.PlayOneShot(laserSound);

            }
            
        }
        else
        {
            AS.Stop();
            SetLaser(false);
        }
    }

    private void SetLaser(bool active)
    {
        foreach( GameObject laser in lasers)
        {
            var fireLaser = laser.GetComponent<ParticleSystem>().emission;
            fireLaser.enabled = active; 
        }
    }

   
}
