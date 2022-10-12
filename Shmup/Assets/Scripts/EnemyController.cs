using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{[HideInInspector]
    public EnemyConfig config;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private MultipleInstantiator multipleInstantiator;

    private Mover mover;
    private Shooter[] shooters;
    private void Start()
    {
        mover = GetComponent<Mover>();
        if(mover != null)
        {
            mover.speed = config.moverSpeed;
        }

        if(config.sprite != null && spriteRenderer !=null)
        {
            spriteRenderer.sprite = config.sprite;
        }

        shooters = GetComponentsInChildren<Shooter>();
        if (shooters != null && shooters.Length > 0)
        {
            foreach(var shooter in shooters)
            {
                StartCoroutine(ShootForever(shooter));
            }
            
        }
        
    }

    public void OnDie()
    {
        if (config != null && multipleInstantiator != null && config.ShouldThrowPicup())
        {
            if (multipleInstantiator.InstantiatorsCount > 1)
            {
                for (int i = 0; i < multipleInstantiator.InstantiatorsCount; i++)
                {
                    if (Dice.IsChanceSuccess(config.pickupChance))
                    {
                        multipleInstantiator.InstantiateByIndex(i);
                    }
                }
            }
            else
            {
                multipleInstantiator.InstantiateSequence();
            }
        }
        StopAllCoroutines();
        GameController.Instance.OnDie(gameObject, config.score);
    }
    private IEnumerator ShootForever(Shooter shooter)
    {
        yield return new WaitForSeconds(shooter.shootingConfig.shootInitialWaitTime);
        while (true)
        {
                shooter.DoShoot();
                yield return new WaitForSeconds(shooter.shootingConfig.shootCadence);
        }
    }
}
