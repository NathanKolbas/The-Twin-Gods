using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artemis : MonoBehaviour
{
    
    [SerializeField] private Stat health;
    [SerializeField] private float startingHealth = 100;
    [SerializeField] private float maxHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        health.Initialize(startingHealth, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
