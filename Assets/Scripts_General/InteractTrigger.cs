using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractTrigger : MonoBehaviour
{
    public Image cutscene;
    public BoxCollider portalTrigger;
    public GameObject portal;
    public TextMeshProUGUI taskPrompt;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //Einstein
            Debug.Log("cutscene appear");
            cutscene.enabled = true;

            //Portal
            portalTrigger.enabled = false;
            portal.SetActive(true);

            //TaskPrompt
            taskPrompt.text = "Jump into the portal!";

        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            cutscene.enabled = false;
        }
    }
}
