using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    [SerializeField] private Image pauseImage;
    [SerializeField] private Image resumeImage;

    private float originalTimeScale;

    private void Start()
    {
        originalTimeScale = Time.timeScale;
    }

    public void Toggle()
    {
        if (GameController.Instance.isGamePaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseImage.gameObject.SetActive(false);
        resumeImage.gameObject.SetActive(true);
        GameController.Instance.isGamePaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = originalTimeScale;
        resumeImage.gameObject.SetActive(false);
        pauseImage.gameObject.SetActive(true);
        GameController.Instance.isGamePaused = false;
    }
}
