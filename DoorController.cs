using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator doorAnimator;
    private bool closeStatus = false;
    void Start()
    {
        doorAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void control()
    {
        closeStatus = !closeStatus;
        doorAnimator.SetBool("isClosed", closeStatus);
    }
}