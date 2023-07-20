using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    private Meal _meal;
    void OnTriggerEnter2D(Collider2D other)
    {
        _meal = other.GetComponent<Meal>();
    }
    void OnTriggerExit2D(Collider2D other)
    {
        _meal = null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Eat();
        }
    }
    public void Eat()
    {
        if (_meal != null) 
        {
            _meal.Eat();
        }
    }
}
