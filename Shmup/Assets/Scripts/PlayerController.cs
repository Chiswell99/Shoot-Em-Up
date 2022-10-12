using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]public class Boundary
{
    public float xMinimum, xMaximum, yMinimum, yMaximum;
}
public class PlayerController : MonoBehaviour
{
    public float speed;
    public Mover moverComponent;
    public Boundary boundary;
    [SerializeField] private List <Shooter> shooters;
    [SerializeField] private PlayerConfig config;
    [SerializeField] private SpecialsController specialsController;
    [SerializeField] private Collider2D playerCollider;
    [SerializeField] private OnTriggerEnterDo triggerer;

    public delegate void PowerChanged(int currentPower, int totalPower);
    public event PowerChanged OnPowerChanged;

    private int powerLevel;
    private int unlockedCannons = 1;

    // Start is called before the first frame update
    void Start()
    {
        moverComponent.speed = speed;

        InputProvider.OnHasShoot += OnHasShoot;
        InputProvider.OnDirection += OnDirection;
    }

    private void OnHasShoot()
    {
        for (int i = 0; i < unlockedCannons; i++)
        {
            var shooter = shooters[i];
            shooter.DoShoot();
        }

    }
    private void OnDirection(Vector3 direction)
    {
        moverComponent.direction = direction;
    }

    public void UnlockSpecial(PickupConfig pickupConfig)//Este metodo llama al SpecialsController y le dice ejecutame el metodo specialsUnlock con el tipo que te digo.
    {
        Debug.LogFormat("UnlockSpecial pickup type {0}", pickupConfig.type);
        specialsController.UnlockSpecial(pickupConfig);
        if (pickupConfig.type == PickupType.Shield)
        {
            EnableCollider(false);
        }
    }

    public void EnableCollider(bool shouldEnable)
    {
        playerCollider.enabled = shouldEnable;
        triggerer.IsEnabled = shouldEnable;
    }

    public int GetCurrentPowerLevel()
    {
        return powerLevel;
    }

    public int GetMaxPowerLevel()
    {
        return config.GetMaxPowerValue();
    }
    void Update()
    {
        float x = Mathf.Clamp(transform.position.x, boundary.xMinimum, boundary.xMaximum);
        float y = Mathf.Clamp(transform.position.y, boundary.yMinimum, boundary.yMaximum);
        transform.position = new Vector3(x, y);


    }

    public void AddToPowerLevel(int powerToAdd)
    {
        powerLevel += powerToAdd;
        var powerConfig = config.GetPowerConfig(powerLevel);
        unlockedCannons = powerConfig.cannonAmount;
        Debug.LogFormat("Player has {0} cannons unlocked. Current Power Level: {1}", unlockedCannons, powerLevel);

        if(OnPowerChanged != null)
        {
            OnPowerChanged.Invoke(powerLevel, config.GetMaxPowerValue());
        }
    }

    public void OnPlayerDie()
    {
        GameController.Instance.OnPlayerDie();
    }
 
}
