using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_player : MonoBehaviour
{
    public Transform _Player;

    public float Targetable_distance = 150f;
    public float MaxAngle = 45f;
    public float MinAngle = 0f;
    public Transform head;
    public Transform turretBase;


    private float _TargetDistance;
    private Quaternion _default;

    // Start is called before the first frame update
    void Start()
    {
        _Player = GameObject.FindGameObjectWithTag("Player").transform;
        _default = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        _TargetDistance = Vector3.Distance(_Player.position, transform.position);
        if (_TargetDistance <= Targetable_distance)
        {
            if (Mathf.Abs(head.rotation.x) <= MaxAngle && Mathf.Abs(head.rotation.x) >= MinAngle)
            {
                head.LookAt(_Player);
                turretBase.LookAt(new Vector3(_Player.position.x, transform.position.y, _Player.position.z));
            }
        }
    }
}