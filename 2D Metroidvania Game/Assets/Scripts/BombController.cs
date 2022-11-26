using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public float timeToExplode = .5f;
    public GameObject explosion;

    public float blastRange;
    public LayerMask whatIsDestructible;

    public GameObject[] test;

    void Update()
    {
        timeToExplode -= Time.deltaTime;
        
        if (timeToExplode <= 0)
        {
            if (explosion != null)
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }

            Destroy(gameObject);

            Collider2D[] objectsToRemove
            =
            Physics2D.OverlapCircleAll(transform.position, blastRange, whatIsDestructible);

            if (objectsToRemove.Length > 0)
            {
                foreach (Collider2D col in objectsToRemove)
                {
                    Destroy(col.gameObject);
                }
            }
        }
    }
}
