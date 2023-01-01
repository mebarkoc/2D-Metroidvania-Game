using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHealth : MonoBehaviour
{
    public int healthAmount;

    public GameObject pickupEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerHealthController.instance.healPlayer(healthAmount);

            if (pickupEffect != null)
            {
                Instantiate(pickupEffect, transform.position, Quaternion.identity);
            }

            Destroy(gameObject); 
        }
    }
}
