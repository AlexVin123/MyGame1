using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    Aim aim;
    [SerializeField] GameObject target;

    private void Start()
    {
        aim = GetComponent<Aim>();
        aim.Init(transform);
    }

    private void Update()
    {
        Vector2 look = transform.position - target.transform.position;
        aim.AimTarget(look);
    }
}
