using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHere : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = target.position;
    }
}