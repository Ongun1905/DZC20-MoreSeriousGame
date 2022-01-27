using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapFallTrigger : MonoBehaviour
{
    public Transform player;
    public Transform specialSpawn;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            player.transform.position = specialSpawn.transform.position;
            Physics.SyncTransforms();
        }
            
        
    }
}
