using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsAmount : MonoBehaviour
{
    [SerializeField] private Text scoreValueText;
    public int stamina;

    public void Start()
    {
        if(PlayerPrefs.HasKey("Stamina"))
        {
            stamina = PlayerPrefs.GetInt("Stamina");
            scoreValueText.text = stamina.ToString();
        }
        else
        {
            stamina = 11;
        }


    }
    private void Update()
    {
        stamina = PlayerPrefs.GetInt("Stamina");
        scoreValueText.text = stamina.ToString();
    }
}
