using UnityEngine;
using System.Collections;

public class CookingWare : MonoBehaviour
{

    public string actionType;     
    public bool isActive = false; 

    public void TriggerAction()
    {
 
        if (actionType == "Cut")
        {
            StartCoroutine(CuttingAction(3f)); 
        }
        else if (actionType == "Fry")
        {
            StartCoroutine(FryingAction(5f)); 
        }
        else if (actionType == "AddSauce")
        {
            StartCoroutine(AddSauceAction(1f)); 
        }
    }

    // Cutting action with a 3-second delay
    private IEnumerator CuttingAction(float duration)
    {
        yield return new WaitForSeconds(duration);
        // You can add further logic here to handle the result of cutting
    }

    // Frying action with a 5-second delay
    private IEnumerator FryingAction(float duration)
    {
        yield return new WaitForSeconds(duration);
        // You can add further logic here to handle the result of frying
    }

    // Heating action with a 3-second delay
    private IEnumerator HeatingAction(float duration)
    {
        yield return new WaitForSeconds(duration);
        // You can add further logic here to handle the result of heating
    }

    // Adding sauce action with a 1-second delay
    private IEnumerator AddSauceAction(float duration)
    {
        yield return new WaitForSeconds(duration);
        // You can add further logic here to handle the result of adding sauce
    }
}
