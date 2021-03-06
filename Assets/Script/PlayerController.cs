﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]

    float moveSpeed = 4f;

    Vector3 forward, right;

    // Use this for initialization
    void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
            Move();
    }

    void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal Key"), 0, Input.GetAxis("Vertical Key"));
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal Key");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical Key");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        transform.forward = heading;

        transform.position += rightMovement;

        transform.position += upMovement;
    }
}
