using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] Transform destination;
    GameObject player;
    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            player.transform.position = destination.transform.position;
            GameController.gameController.spawnEmpty();
        }
    }
}
