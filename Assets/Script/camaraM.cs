using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraM : MonoBehaviour {
    private Transform target;
    private Vector3 tmbPosition;
    // Use this for initialization
    void Start()
    {
        this.target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.target)
        {
            this.tmbPosition = this.target.position;
            this.tmbPosition.z = -10;
            this.transform.position = Vector3.Lerp(this.transform.position, this.tmbPosition, 1);
        }
    }



}
