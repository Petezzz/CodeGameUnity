using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public float spinSpeed = 4f;
    void Start()
    {

    }


    void Update()
    {
        this.transform.Rotate(new Vector3(0, spinSpeed, 0));
    }
}
