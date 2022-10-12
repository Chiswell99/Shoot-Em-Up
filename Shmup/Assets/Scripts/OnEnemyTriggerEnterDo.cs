using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnEnemyTriggerEnterDo : OnTriggerEnterDo
{
    [SerializeField] private UnityEvent unignoredAction;
    [SerializeField] List<string> tagsToIgnore;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IsEnabled)
        {
            return;
        }
        alwaysAction.Invoke();
        foreach(var ignoteTag in tagsToIgnore)
        {
            if (collision.tag == ignoteTag)
                return;
        }
        unignoredAction.Invoke();
    }
    public override void DestroyCollisionee()
    {
        Debug.LogFormat("Enemy shouldn't do anything against collisionee. Ignoring");
    }
}
