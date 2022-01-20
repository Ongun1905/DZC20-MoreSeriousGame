using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderTrigger : MonoBehaviour
{
    public Transform player;
    public Transform spawnPosition;
    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player")) {
            Debug.Log("exit sphere");
            player.position = spawnPosition.position;
        }
    }
}
