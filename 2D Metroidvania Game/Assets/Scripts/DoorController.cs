using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator anim;

    public float distanceToOpen;

    private PlayerController thePlayer;


    // Start is called before the first frame update
    void Start()
    {
        thePlayer = PlayerHealthController.instance.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()   
    {
        if (Vector3.Distance(transform.position, thePlayer.transform.position) < distanceToOpen)
        {
            anim.SetBool("doorOpen", true);
        }
        else
        {
            anim.SetBool("doorOpen", false);
        }

    }
}
