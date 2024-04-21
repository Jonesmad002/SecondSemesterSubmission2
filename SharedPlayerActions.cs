using UnityEngine;
using System.Collections;

public class SharedPlayerActions : MonoBehaviour
{
    // Connects to the Animator component
    private Animator anim;

    //Finds which specific enemy is attacking the player
    private EnemyWeaponScript attacker;

    //This is for testsing, currently unused
    public bool test = true;

    //Finds the Mover script;
    public Mover mov;

    // Called as the script is loading
    private void Awake()
    {
        // Assigns varibles their items
        if(GetComponent<Animator>() != null)
        {
            anim = GetComponent<Animator>();
        }
        mov = gameObject.GetComponentInParent<Mover>();
        //attack = GameObject.FindGameObjectWithTag("ShareEnemy").GetComponent<SharedEnemyActions>();
        attacker = GameObject.FindGameObjectWithTag("EnemyHurt").GetComponent<EnemyWeaponScript>();

    }

    // Hurts the player
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Checks if item touched is an enemy
        if (collision.GetComponent<EnemyWeaponScript>() != null)
        {
            attacker = collision.GetComponent<EnemyWeaponScript>();
            mov.active[0] = attacker.Hurt(mov.active[0]);
            anim.SetTrigger("Hurt");
        }

        //If player is defeated, plays the defeat animation
        if(mov.active[0] <= 0 && anim.GetBool("IsDefeat") == false)
        {
            anim.SetBool("IsDefeat", true);
            anim.SetTrigger("Defeat");
        }
    }

    //Moved to GobuiWeaponScript to fix an issue with colliders
    /* When the player attacks and hits an enemy the enemy loses health equal to pow
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Checks if item hit is an enemy
        if (collision.GetComponent<SharedEnemyActions>() != null)
        {
            attack = collision.GetComponent<SharedEnemyActions>();
            attack.Hit(mov.active[2]);
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        // If the player is moving they will change to their walking animation
        anim.SetFloat("isMoving", mov.move);

        // Triggers attack animation when E is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetTrigger("Attack");
        }



        //----------------TESTS---------------------------------------
        //Damages the player with J
        if (Input.GetKeyDown(KeyCode.J))
        {
            mov.active[0]--;
            anim.SetTrigger("Hurt");
        }
        //Heals the player with K
        if (Input.GetKeyDown(KeyCode.K))
        {
            mov.active[0]++;
            anim.SetTrigger("Attack");
        }

        //Checks if the defeat animation should be playing or not
        if (mov.active[0] <= 0)
        {
            anim.SetBool("IsDefeat", true);
        }
        else
        {
            anim.SetBool("IsDefeat", false);
        }
    }
}

