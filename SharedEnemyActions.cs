using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharedEnemyActions : MonoBehaviour
{
    // The ammount of damage that can be taken before the enemy is defeated
    public int health = 5;

    // Connects to Animator component
    public Animator anim;

    //Grabs the weapon component
    private EnemyWeaponScript hurtbox;


    // Called as the script is loading
    void Awake()
    {
        // Assigns varibles their items
        anim = GetComponent<Animator>();
        hurtbox = gameObject.GetComponentInChildren<EnemyWeaponScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the enemy has no more health the defeat animation is played and the weapon is turned off
        if (health < 0)
        {
            anim.SetBool("IsDefeat", true);
            hurtbox.Defeast();
        }

    }

    // When the enemy is hit its health is subtracted by the damage recived and the hit animation is played
    public void Hit(int pow)
    {
        health -= pow;
        anim.SetTrigger("IsHit");
    }

}
