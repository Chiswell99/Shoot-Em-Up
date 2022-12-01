using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyObject : MonoBehaviour
{
    public float destroyTime;

    public void OnDestroy()
    {
        Destroy(gameObject, destroyTime);
    }

    public void OnDestroyBoss()
    {

        StartCoroutine(DestroyBoss());
        
    }

    IEnumerator DestroyBoss()
    {
        yield return new WaitForSeconds(5);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
