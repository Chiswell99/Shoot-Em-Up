using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinStore : MonoBehaviour
{
    public int stamina;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Stamina"))
        {
            stamina = PlayerPrefs.GetInt("Stamina");
        }
    }
    public void BuyCoins()
    {
        stamina++;
        PlayerPrefs.SetInt("Stamina", stamina);
    }
}
