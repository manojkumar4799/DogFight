using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyVFX;
    [SerializeField] GameObject hitVFX;
   // [SerializeField] int scoreToAdd=100;
    [SerializeField] int HitPoints;
    [SerializeField] int enemyHealth;
   
   // Score scoreboard;
    GameObject hitVfxHolder;
    GameObject GOpos;
    private void Start()
    {
       // scoreboard = FindObjectOfType<Score>();
        hitVfxHolder = GameObject.FindWithTag("HitVFXHolder");
        GOpos = GameObject.FindWithTag("Holders");
       
    
    }

    private void OnParticleCollision(GameObject other)
    {
        
        ScorForEnemy();
        EnemyKill();
    }

    

    private void ScorForEnemy()
    {
       
      // scoreboard.GameScore(scoreToAdd);
       GameObject VFX= Instantiate(hitVFX, transform.position, Quaternion.identity);
        VFX.transform.parent = hitVfxHolder.transform;
    }

    private void EnemyKill()
    {
        
        HitPoints++;
        if (HitPoints > enemyHealth)
        {
          GameObject vfx = Instantiate(enemyVFX, transform.position, Quaternion.identity);
          vfx.transform.parent = GOpos.transform;
           Destroy(gameObject);
        }
    }

   
}
