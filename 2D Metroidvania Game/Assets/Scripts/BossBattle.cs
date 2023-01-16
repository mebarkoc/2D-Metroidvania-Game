using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattle : MonoBehaviour
{
    private CameraController theCam;
    public Transform camPosition;
    public float camSpeed;


    private void Start()
    {
        theCam = FindObjectOfType<CameraController>();
        theCam.enabled = false;
    }


    private void Update()
    {
        theCam.transform.position = Vector3.MoveTowards(theCam.transform.position, camPosition.position, camSpeed * Time.deltaTime);
    }

    public void BattleEnd()
    {
        gameObject.SetActive(false);
    }
}
