using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinStore : MonoBehaviour
{
    public mainmenu script;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Stamina"))
        {
            mainmenu.stamina = PlayerPrefs.GetInt("Stamina");
        }
    }
    public void BuyCoins3()
    {
        mainmenu.stamina += 3;
        PlayerPrefs.SetInt("Stamina", mainmenu.stamina);
    }
    public void BuyCoins5()
    {
        mainmenu.stamina += 5;
        PlayerPrefs.SetInt("Stamina", mainmenu.stamina);
    }
    public void BuyCoins10()
    {
        mainmenu.stamina += 10;
        PlayerPrefs.SetInt("Stamina", mainmenu.stamina);
    }
}
