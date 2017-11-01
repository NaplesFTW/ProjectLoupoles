using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public EnemyHealth enemyHealth;


	// Use this for initialization
	void Start () {
        enemyHealth = GetComponent<EnemyHealth>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
