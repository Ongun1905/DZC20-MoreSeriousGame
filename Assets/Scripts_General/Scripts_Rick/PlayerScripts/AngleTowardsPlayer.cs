using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleTowardsPlayer : MonoBehaviour
{


    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = transform.root.Find("LogicPlayer").GetComponent<Player_UI>().PlayerCam.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z), Vector3.up);
    }

}
