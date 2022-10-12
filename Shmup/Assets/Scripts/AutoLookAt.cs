using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoLookAt : MonoBehaviour
{
    private Transform target;

    private void Start()
    {
        target = GameController.Instance.Player.transform;
    }
    private void Update()
    {
        if (target == null)
        {
            return;
        }
        //var targetPosition = FindObjectOfType<PlayerController>().transform.position;
        var targetPosition = target.position;

        Vector3 diff = target.position - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }
}
