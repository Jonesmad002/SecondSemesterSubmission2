using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmojikManager : MonoBehaviour
{
    //Varibles that connect to various GameObjects
    private Mover mov;
    private GameObject gobui;
    private GameObject crackers;
    private GameObject barbus;

    [SerializeField]
    private GameObject player;

    //The index of the current character
    private int gob = 0;

    private void Awake()
    {
        //Assigns the varibles to the nessicary GameObjects in the scene
        //mov = GameObject.FindGameObjectWithTag("SharedPlayer")
        player = GameObject.FindGameObjectWithTag("SharedPlayer");
        mov = player.GetComponent<Mover>();
        gobui = GameObject.FindGameObjectWithTag("Gobui");
        crackers = GameObject.FindGameObjectWithTag("Crackers");
        barbus = GameObject.FindGameObjectWithTag("Barbus");

       //This saves GameObjects between scenes
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        //Changes the character when 'R' is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            playerChangeUp();
        }
    }

    //Cycles between 3 different characters with different stats
    void playerChangeUp()
    {
        //Swaps to Crackers, high speed, but can't attack
        if (gob == 0)
        {
            gobui.SetActive(false);
            crackers.SetActive(true);
            mov.characterSet(1);
            gob = 1;
        }
        //Swaps to Barbus, high defense and attack, low speed
        else if (gob == 1)
        {
            crackers.SetActive(false);
            barbus.SetActive(true);
            mov.characterSet(2);
            gob = 2;
        }
        //Swaps to Gobui, medium speed, has a sword
        else if (gob == 2)
        {
            barbus.SetActive(false);
            gobui.SetActive(true);
            mov.characterSet(0);
            gob = 0;
        }
    }

}