using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider progressBar;
    public float duration = 3f; // Duration to reach zero
    private bool isProgressActive = false;

    void Start()
    {
        if (progressBar != null)
        {
            progressBar.value = 1; 
            progressBar.gameObject.SetActive(false); 
        }
    }

    void Update()
    {
        if (isProgressActive && progressBar.value > 0)
        {
            // Calculate how much to decrease per frame
            progressBar.value -= Time.deltaTime / duration;

            // Stop progress if it reaches zero
            if (progressBar.value <= 0)
            {
                progressBar.value = 0;
                isProgressActive = false;
                Destroy(progressBar.gameObject);
            }
        }
    }

    public void StartProgress()
    {
        if (progressBar != null)
        {
            progressBar.gameObject.SetActive(true); 
            progressBar.value = 1; 
            isProgressActive = true;
        }
    }
}
