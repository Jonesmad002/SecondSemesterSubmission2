using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mover : MonoBehaviour
{
    // Check which way the player sprite faces
    private bool faceing = true;

    // Gets the movement for animations, used for other scripts
    public float move = 0;

    // Connected to sprite movement
    private Vector2 movement;

    // Connects to Rigidbody component
    private Rigidbody2D rb;

    // Sets Player Character
    [SerializeField]
    public int character = 0;

    //The indicidual stats for each character, not all are implemented yet
    //Char Order: Gobui, Crackers, Barbus, CDoo, Dariwn, Macaroni
    private int[] hp = { 25, 10, 40, 30, 20, 25 };
    private int[] speeds = { 4, 10, 2, 6, 5, 3};
    private int[] pow = { 10, 0, 8, 7, 2, 5 };

    //Uneeded
    //public int characterLimit = 1;

    //The active stats that change to match the current character
    public int[] active = { 0, 0, 0, 0, 0, 0, 0 };
    

    // Called as script is loading
    private void Awake()
    {
        // Grabs game components
        rb = GetComponent<Rigidbody2D>();

        //Sets the default character to Gobui
        characterSet(0);
    }

    //Changes the character stats to match the sprite
    public void characterSet(int c)
    {
        character = c;
        active[0] = hp[character];
        active[1] = speeds[character];
        active[2] = pow[character];
    }

    // When WASD is pressed, the player moves and/or changes direction
    private void OnWalks(InputValue value)
    {
        movement = value.Get<Vector2>();

        // This varible is sent to other scripts for animation purposes
        move = Mathf.Abs(movement.x) + Mathf.Abs(movement.y);

        //Changes the direction sprite is facing if needed
        if (movement.x > 0 && faceing == false)
        {
            gameObject.transform.Rotate(0, 180, 0);
            faceing = true;
        }else if(movement.x < 0 && faceing == true){
            gameObject.transform.Rotate(0, 180, 0);
            faceing = false;
        }

    }
    // Moves the player based on the input in OnWalks
    public void MoveSprite(int spe)
    {
        rb.MovePosition(rb.position + spe * Time.fixedDeltaTime * movement);
    }

    //The character moves every fixed update, unless they are defeated
    private void FixedUpdate()
    {
        if (active[0] > 0)
        {
            MoveSprite(active[1]);
        }else if (active[0] < 0)
        {
            active[0] = 0;
        }
    }
}
