using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBoxBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject foodType;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            Debug.Log("Taking bread");
        } 
    }
}
