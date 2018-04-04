﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    [SerializeField] int startingHealth = 100;
    [SerializeField] float timeSinceLastHit = 2f;

    private float timer = 0f;
    private CharacterController characterController;
    private Animator anim;
    private int currentHealth;




    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        currentHealth = startingHealth;

    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
		
	}

    void OnTriggerEnter(Collider other)
    {
    if (timer >= timeSinceLastHit && !GameManager.instance.GameOver)
        {
            if(other.tag == "Weapon")
            {
                takehit();
                timer = 0;
            }
        }

    }
    void takehit()
    {
        if (currentHealth > 0)
        {
            GameManager.instance.PlayerHit(currentHealth);
            anim.Play("Hurt");
            currentHealth -= 10;
        }

        if (currentHealth <= 0)
        {
            killPlayer();
        }
    }
        void killPlayer()
        {
            GameManager.instance.PlayerHit(currentHealth);
            anim.SetTrigger("HeroDie");
            characterController.enabled = false;
        }
    }



