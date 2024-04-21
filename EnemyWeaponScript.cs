using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponScript : MonoBehaviour
{
    //The default damage output
    public int damaged = 2000;

    //The enemy the weapon is attached to
    private SharedEnemyActions boss;

    // Start is called before the first frame update
    void Start()
    {
        //Gets the parent enemy object
        boss = gameObject.GetComponentInParent<SharedEnemyActions>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //This was uneeded
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<SharedPlayerActions>() != null)
        {
            int endDamage = Hurt(target.active[0], target.active[1], 3);
            target.active[0] = endDamage;
        }
    }*/

    //Damages an object and triggers the enemy attack animation
    public int Hurt(int opHealth)
    {
        boss.anim.SetTrigger("Attack");
        return opHealth -= damaged;
    }

    //Turns off the weapon
    public void Defeast()
    {
        gameObject.SetActive(false);
    }

}