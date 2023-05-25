using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterController : MonoBehaviour  
{
    public Rigidbody2D playerRB;
    public float sForce;
    public SpriteRenderer playerSR;
    public UI ui;
    public inventoryManager iM;
    public bool window1;
    public bool window2;

    

    public float currency = 100f;
    
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerSR = GetComponent<SpriteRenderer>();

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ShopTrigger")
        {
            ui.ShopScreen(true);
            

            window1 = true;

        }

        if (collision.tag == "ChestTrigger")
        {
            ui.ChestScreen(true);

            window2 = true;
            ui.sell = false;

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ShopTrigger")
        {

            ui.ShopScreen(false);
            ui.Shop.SetActive(false);
            ui.Backpack.SetActive(false);
            ui.sell = false;

            window1 = false;
        }

        if (collision.tag == "ChestTrigger")
        {
            ui.ChestScreen(false);
            ui.Backpack.SetActive(false);
            ui.Chest.SetActive(false);
            ui.sell = false;

            window2 = false;
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey("d"))
        {
            playerSR.flipX = true;
            playerRB.velocity = new Vector2(sForce * Time.deltaTime, 0);


        }


        if (Input.GetKey("a"))
        {
            playerSR.flipX = false;
            playerRB.velocity = new Vector2(-sForce * Time.deltaTime, 0);            

        }

        if (window1)
        {
            if (Input.GetKey("x"))
            {
                ui.Shop.SetActive(true);
                ui.Backpack.SetActive(true);
                ui.sell = true;
                ui.BackpackCover.SetActive(true);

            }

            if (Input.GetKey("z"))
            {
                ui.Shop.SetActive(false);
                ui.Backpack.SetActive(false);
                ui.sell = false;
                ui.BackpackCover.SetActive(false);
            }
        }

         if (window2)
         {
                if (Input.GetKey("x"))
                {
                ui.Chest.SetActive(true);
                ui.Backpack.SetActive(true);
                ui.sell = false;
                ui.BackpackCover.SetActive(false);

            }

                if (Input.GetKey("z"))
                {
                ui.Chest.SetActive(false);
                ui.Backpack.SetActive(false);
                ui.sell = false;
                ui.BackpackCover.SetActive(false);
            }
         }





    }
}
