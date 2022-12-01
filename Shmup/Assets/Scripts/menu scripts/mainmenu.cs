using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class mainmenu : MonoBehaviour
{
    public int stamina;
    public int maxStamina;
    public bool _staminaReload;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Stamina"))
        {
            stamina = PlayerPrefs.GetInt("Stamina");
            if (stamina < maxStamina)
            {
                _staminaReload = true;

                DateTime time = DateTime.Parse(PlayerPrefs.GetString("Time"));
                Debug.Log(time);
                var actualStamina = PlayerPrefs.GetInt("Stamina");

                int multiply = 0;

                for (int i = actualStamina; i < maxStamina; i++)
                {
                    multiply++;
                    if (DateTime.Compare(DateTime.Now, time.AddSeconds(multiply * 30)) >= 0)
                    {
                        stamina++;
                    }
                }
            }
        }
        else
            stamina = maxStamina;

    }

    private void Update()
    {
        if (_staminaReload && PlayerPrefs.HasKey("Time"))
        {
            DateTime time = DateTime.Parse(PlayerPrefs.GetString("Time"));

            if (DateTime.Compare(DateTime.Now, time) >= 0)
            {
                stamina++;

                if (stamina >= maxStamina)
                {
                    _staminaReload = false;
                    PlayerPrefs.DeleteKey("Time");
                }
                else
                    PlayerPrefs.SetString("Time", DateTime.Now.AddSeconds(30).ToString());

                PlayerPrefs.SetInt("Stamina", stamina);
            }

        }
    }

    public void PlayGame()
    {
        if(stamina > 0)
        {
            stamina--;
            PlayerPrefs.SetInt("Stamina", stamina);
        }
        if (stamina < maxStamina)
        {
            PlayerPrefs.SetString("Time", DateTime.Now.AddSeconds(30).ToString());
            _staminaReload = true;

        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("quitting");
        Application.Quit();
    }
}
