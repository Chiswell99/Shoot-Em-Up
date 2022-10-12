using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] public Transform shootOrigin;
    [SerializeField] public GameObject shootPrefab;
    [SerializeField] private ShootingConfig config;
    [SerializeField] private List<GameObject> shootList;
    [SerializeField]  private int poolSize = 10;
    public ShootingConfig shootingConfig 
    {
        get { return config; }
    }

    public bool IsEnabled = true;
    private void Start()
    {
        AddShootsToPool(poolSize);

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
            //DoShoot();
            yield return new WaitForSeconds(config.shootCadence);
        }
    }
    public void DoShoot()
    {
        //if (IsEnabled && shootOrigin != null)
        //{
        //    Instantiate(shootPrefab, shootOrigin.position, shootOrigin.rotation);
        //}
        if (IsEnabled && shootOrigin != null)
        {
            GameObject shoot = RequestShoot();
            shoot.transform.position = shootOrigin.position;
            shoot.transform.rotation = shootOrigin.rotation;
        }
           

      
    }


    public void EnableShooter(bool shouldEnable)
    {
        IsEnabled = shouldEnable;
    }

    private void AddShootsToPool(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            GameObject bullet = Instantiate(shootPrefab);
            bullet.SetActive(false);
            shootList.Add(bullet);
            //bullet.transform.parent = transform;
        }
    }

    public GameObject RequestShoot()
    {
        for (int i = 0; i < shootList.Count; i++)
        {
            if (!shootList[i].activeSelf)
            {
                shootList[i].SetActive(true);
                return shootList[i];
            }
        }
        return null;
    }
}
