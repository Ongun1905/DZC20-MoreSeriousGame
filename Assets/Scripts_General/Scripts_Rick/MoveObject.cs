using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{

    public enum Directions{
    X,
    Y,
    Z
    };

    [Header("Move button")]
    public bool move;

    [Header("Settings")]
    [Range(0.0F, 1F)]public float StepSize = 1F;
    public bool NegativeDirection = false;
    public Directions direction = Directions.X;

    private int k;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(NegativeDirection){
            k = -1;
        }
        else{
            k = 1;
        }

        if(move){
            if(direction.ToString().Equals("X")){ transform.position = new Vector3(transform.position.x + StepSize * k, transform.position.y, transform.position.z);}
            if(direction.ToString().Equals("Y")){ transform.position = new Vector3(transform.position.x, transform.position.y + StepSize * k, transform.position.z);}
            if(direction.ToString().Equals("Z")){ transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + StepSize * k);}
            move = false;
        }
    }
}
