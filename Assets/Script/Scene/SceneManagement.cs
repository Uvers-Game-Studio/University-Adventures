using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public static SceneManagement instance1;

    private void Awake()
    {
        if(instance1 == null)
        {
            instance1 = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void lobby1()
    {
        SceneManager.LoadScene("DeniLobby1");
    }
    public void lobby2()
    {
        SceneManager.LoadScene("DeniLobby2");
    }
    public void Ourdoor()
    {
        SceneManager.LoadScene("DeniOutdoor");
    }
    public void kitchen()
    {
        SceneManager.LoadScene("DeniKitchen");
    }
    public void canteen()
    {
        SceneManager.LoadScene("DeniCanteen2");
    }
}
