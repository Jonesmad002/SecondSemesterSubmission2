using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class GobuiWeaponScript : MonoBehaviour
{
    // Connects to Animator component
    private Animator anim;

    //Connects to various scripts
    private SharedEnemyActions attack;
    public Mover mov;

    // Called as the script is loading
    void Awake()
    {
        //Assigns varibles their objects
        anim = GetComponent<Animator>();
        attack = GameObject.FindGameObjectWithTag("ShareEnemy").GetComponent<SharedEnemyActions>();
        mov = gameObject.GetComponentInParent<Mover>();
    }

    // Update is called once per frame
    void Update()
    {
        // Plays swinging animation when E is pressed
        if (Input.GetKeyDown(KeyCode.E) && mov.active[0] > 0)
        {
            anim.SetTrigger("Swing");
            // The Animator automatically activates the collision trigger
        }
    }

    // When the player attacks and hits an enemy the enemy loses health equal to pow
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Checks if item hit is an enemy
        if (collision.GetComponent<SharedEnemyActions>() != null)
        {
            attack = collision.GetComponent<SharedEnemyActions>();
            attack.Hit(mov.active[2]);
        }
    }
}