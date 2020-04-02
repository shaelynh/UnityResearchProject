using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stompbox : MonoBehaviour
{
    public GameObject deathEffect;

    public GameObject collectible;
    [Range(0, 100)]public float chanceToDrop;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            Debug.Log("Hit Enemy");

            //don't want to do this because the enemy will still be active in the world
            // other.gameObject.SetActive(false);

            other.transform.parent.gameObject.SetActive(false);

            Instantiate(deathEffect, other.transform.position, other.transform.rotation);

            PlayerController.instance.Bounce();

            float dropSelect = Random.Range(0, 100f);

            
            if (dropSelect <= chanceToDrop)
            {
                //drop an item
                Instantiate(collectible, other.transform.position, other.transform.rotation);
            }

            //play sound effect, choose which by element
            //enemy killed
            AudioManager.instance.PlaySFX(2);

        }
    }
}
