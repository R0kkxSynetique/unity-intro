using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_player : MonoBehaviour
{
    public Transform _Player;

    public float Targetable_distance = 150f;
    private float MaxAngle = 45f;
    private float MinAngle = 0f;
    public Transform Head;
    public Transform TurretBase;
    public Transform ShootPoint;
    private float _ProjectileSpeed = 1000f;
    //number of projectile per 10 sec
    public float FireRate = 1f;
    public float AliveTime = 5f;

    public GameObject Ammo;


    private float _TargetDistance;
    private float _nextFire;
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
            if (Mathf.Abs(Head.rotation.x) <= MaxAngle && Mathf.Abs(Head.rotation.x) >= MinAngle)
            {
                Head.LookAt(_Player);
                TurretBase.LookAt(new Vector3(_Player.position.x, transform.position.y, _Player.position.z));
                if (Time.time >= _nextFire)
                {
                    _nextFire = Time.time + 1f / FireRate * 10;
                    shoot();
                }
            }
        }
    }

    void shoot()
    {
        GameObject clone = Instantiate(Ammo, ShootPoint.position, ShootPoint.rotation);
        clone.GetComponent<Rigidbody>().AddForce(Head.forward * _ProjectileSpeed);
        Destroy(clone, AliveTime);
    }
}