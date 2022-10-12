using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] public Transform shootOrigin;
    [SerializeField] public GameObject shootPrefab;
    [SerializeField] private ShootingConfig config;
    public ShootingConfig shootingConfig 
    {
        get { return config; }
    }

    public bool IsEnabled = true;
    private void Start()
    {
        if(config == null)
        {
            return;
        }
        if (config.autoShooting)
        {
            StartCoroutine(AutoShoot());
        }
    }
    
    private IEnumerator AutoShoot()
    {
        while (true)
        {
            DoShoot();
            yield return new WaitForSeconds(config.shootCadence);
        }
    }
    public void DoShoot()
    {
        if (IsEnabled && shootOrigin != null)
        {
            Instantiate(shootPrefab, shootOrigin.position, shootOrigin.rotation);
        }
    }

    public void EnableShooter(bool shouldEnable)
    {
        IsEnabled = shouldEnable;
    }
}
