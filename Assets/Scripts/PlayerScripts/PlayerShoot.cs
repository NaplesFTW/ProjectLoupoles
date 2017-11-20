using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
    Player player;

    public GameObject[] abilityPrefabs;
    public Vector2 abilityStartPos;
    public int currentAbility = 0; 

    List<GameObject> abilities;
    public bool shot;

    public float shootCooldownTime = .25f;
    public float shootCooldownTimer;
	// Use this for initialization
	void Start () {
        player = GetComponent<Player>();
        abilities = new List<GameObject>();
    }


    void Update()
    {
        if (player.getState() == PlayerState.Dead)
            return;

        if (Input.GetAxis("Shoot") == 0 && shot == true)
        {
            shot = false;
            player.anim.SetBool("Shooting", false);
        }

        if(player.getState() == PlayerState.Dashing)
            player.anim.SetBool("Shooting", false);

        if (shootCooldownTimer > 0)
            shootCooldownTimer -= Time.deltaTime;
    }

    void FixedUpdate () {
        if (player.getState() == PlayerState.Dead)
            return;

        if (Input.GetAxis("Shoot") == 1 && shootCooldownTimer <= 0 && player.getState() == PlayerState.Moving)
        {
            Shoot();
        }

        for (int i = 0; i < abilities.Count; i++)
        {
            if(abilities[i] == null)
            {
                abilities.Remove(abilities[i]);
                continue;
            }
        }
    }
    public void setAbility(int abilityNumber)
    {
        currentAbility = abilityNumber;
    }
    void Shoot()
    {
        shot = true;
        player.anim.SetBool("Shooting", true);
        shootCooldownTimer = shootCooldownTime = .25f;
        GameObject bullet = Instantiate<GameObject>(abilityPrefabs[currentAbility]);
        bullet.transform.position = abilityStartPos;
        abilities.Add(bullet);
    }

}
