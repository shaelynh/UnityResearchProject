using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;


    public int currentHealth,maxHealth;

    //do not want to overly punish player
    public float invincibleLength;
    private float invincibleCounter;

    private SpriteRenderer theSR;

    public GameObject deathEffect;

    //called right before start
    private void Awake()
    {
        //this is playerhealthcontroller - static variables will not show in the inspector
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        //to use to set color
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(invincibleCounter > 0)
        {
            //if invincible count down so player does not stay invincible 
            invincibleCounter -= Time.deltaTime;

            if (invincibleCounter <= 0)
            {
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1f);
            }

        }
    }

    public void DealDamage()
    {
        if (invincibleCounter <= 0)
        {

            //currentHealth -= 1;
            currentHealth--;

            if (currentHealth <= 0)
            {
                //so it doesn't go below 0
                currentHealth = 0;

                //deactivate player
                // gameObject.SetActive(false);

                Instantiate(deathEffect, transform.position, transform.rotation);

                LevelManager.instance.RespawnPlayer();
            }
            else
            {
                invincibleCounter = invincibleLength;
                // a is alpha theSR.color.a , f because it is a float
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, .5f);


                PlayerController.instance.KnockBack();

                AudioManager.instance.PlaySFX(2);
            }

            UIController.instance.UpdateHealthDisplay();

        }
    }
    public void HealPlayer()
    {
        currentHealth++;

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UIController.instance.UpdateHealthDisplay();
    }
}
