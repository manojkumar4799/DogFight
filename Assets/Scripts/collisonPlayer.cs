using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collisonPlayer : MonoBehaviour
{
    [SerializeField] float delayTime;
    [SerializeField] ParticleSystem playerVFX;
    [SerializeField] GameObject laser1ToDestroy;
    [SerializeField] GameObject laser2ToDestroy;
    [SerializeField] AudioClip playerDeathSound;
    [SerializeField] int playerHealth;
    


    

    AudioSource AS;
   
    
    Playerlife playerlife;
    

    private void Start()
    {
        
        AS = GetComponent<AudioSource>();
       

        playerlife = FindObjectOfType<Playerlife>();
    }
    void OnTriggerEnter(Collider other)
    {
       

        playerHealth--;
        playerlife.PlayerHealth(playerHealth);
        
        

        if (playerHealth == 0)
        {
            StartExplode();
        }
    }

   

    private void StartExplode()
    {
       GetComponent<PlayerControls>().enabled = false;
       playerVFX.Play();
       AS.PlayOneShot(playerDeathSound);
       GetComponent<MeshRenderer>().enabled = false;
       GetComponent<BoxCollider>().enabled = false;
       Destroy(laser1ToDestroy);
       Destroy(laser2ToDestroy);
       Invoke("DelayProcess", delayTime);
        
    }
    void DelayProcess()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }
}
