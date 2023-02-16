using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing_Missile : MonoBehaviour
{
    private Transform RocketTarget;
    public Rigidbody RocketRgb;

    public float TurnSpeed = 1f;
    public float RocketFlySpeed = 10f;

    private Transform rocketLocalTrans;

    void Start()
    {
        RocketTarget = GameObject.FindWithTag("Player").transform;
        rocketLocalTrans = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        RocketRgb.velocity = rocketLocalTrans.forward * RocketFlySpeed;

        var rocketTargetRot = Quaternion.LookRotation(RocketTarget.position - rocketLocalTrans.position);

        RocketRgb.MoveRotation(Quaternion.RotateTowards(rocketLocalTrans.rotation, rocketTargetRot, TurnSpeed));
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(transform);
    }
}
