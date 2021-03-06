﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAvatar : MonoBehaviour
{
    public ShootSystem ShootSystem { get; private set; }

    public User UserInfo { get; set; }

    bool UpdatePosition;
    Prediction predition;
    Vector3 startPos, endPos, speed;
    Quaternion startRot, endRot;
    float interpolationTime, time, frac;

    void Start()
    {
        ShootSystem = GetComponent<ShootSystem>();

        startPos = endPos = transform.position;
        startRot = endRot = transform.rotation;

        predition = new Prediction(startPos, startRot);
    }

    //PREDICTION
    public void SetTransform(Vector3 position, Quaternion rotation)
    {
        startPos = transform.position;
        startRot = transform.rotation;
        interpolationTime = predition.Predict(position, rotation, out endPos, out endRot, out speed);
        time = 0;
        UpdatePosition = true;
    }

    void Update()
    {
        if (UpdatePosition)
        {
            time += Time.deltaTime;
            frac = time / interpolationTime;
            if (frac > 1)
                frac = 1;
            transform.position = Vector3.Lerp(startPos, endPos, frac);
            transform.rotation = Quaternion.Slerp(startRot, endRot, frac);
        }
    }
}
