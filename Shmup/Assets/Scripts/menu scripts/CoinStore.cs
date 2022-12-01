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
    public void BuyCoins3()
    {
        stamina+= 3;
        PlayerPrefs.SetInt("Stamina", stamina);
    }
    public void BuyCoins5()
    {
        stamina += 5;
        PlayerPrefs.SetInt("Stamina", stamina);
    }
    public void BuyCoins10()
    {
        stamina += 10;
        PlayerPrefs.SetInt("Stamina", stamina);
    }
}
