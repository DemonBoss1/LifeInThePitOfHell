using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meal : MonoBehaviour
{
    [SerializeField]int value;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        HitPoints character = other.GetComponent<HitPoints>();
        if(character != null){
            if(Input.GetKeyDown(KeyCode.E)){
                character.changeHP(value);
                Destroy(gameObject);
            }
        }
    }
}
