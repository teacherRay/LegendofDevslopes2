﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

public class EnemyMove : MonoBehaviour {
    [SerializeField] Transform player;
    private NavMeshAgent nav;
    private Animator anim;


    void Awake()
    {
        Assert.IsNotNull(player);
    }


    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();

	}
	
	// Update is called once per frame
	void Update () {
        nav.SetDestination(player.position);
		
	}
}
