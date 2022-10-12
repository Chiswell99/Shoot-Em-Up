using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEnterDo : MonoBehaviour
{
    public bool IsEnabled = true;
    [SerializeField] protected UnityEvent alwaysAction;

    protected GameObject colissionee;
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        colissionee = collision.gameObject;
        alwaysAction.Invoke();
    }

    public virtual void DestroyCollisionee()
    {
        if(colissionee != null)
        {
            Destroy(colissionee);
        }
    }
}
