using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractTrigger : MonoBehaviour
{
    public Image einsteinCutscene;
    public BoxCollider portalTrigger;
    public GameObject portal;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("cutscene appear");
            einsteinCutscene.enabled = true;
            portalTrigger.enabled = false;
            portal.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            einsteinCutscene.enabled = false;
        }
    }
}
