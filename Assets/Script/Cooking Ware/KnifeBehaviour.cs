using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnifeBehaviour : MonoBehaviour
{
    public GameObject KnifeButton; 
    public ProgressBar progressBar; 
    void Start()
    {
        KnifeButton.SetActive(false);
        
        if (KnifeButton != null)
        {
            KnifeButton.GetComponent<Button>().onClick.AddListener(knifeActive);
        }
    }

    public void knifeActive()
    {
        if (progressBar != null)
        {
            KnifeButton.SetActive(false);
            progressBar.StartProgress(); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            KnifeButton.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            KnifeButton.SetActive(false);
        }
    }
}
