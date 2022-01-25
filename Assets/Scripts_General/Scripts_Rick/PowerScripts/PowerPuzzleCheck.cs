using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPuzzleCheck : MonoBehaviour
{

    public Transform[] PuzzleInputs;
    public Transform PuzzleOutput0;
    public Transform PuzzleOutput1;

    public PowerInteract ButtonInteract;

    public GameObject Portal;

    bool[] states;
    bool[] current_output;
    bool[] expected_output;
    bool state;

    int count;

    public float testFrequency = 2f;
    public int testAmount = 8;

    public bool testing;
    public int testcount;
    public float lastTest;
    public int correctInputs;

    public bool TestPassed;

    // Start is called before the first frame update
    void Start()
    {
        testing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(ButtonInteract.ButtonPressed){
            ButtonInteract.ButtonPressed = false;
            testing = true;
        }
        if(testing){ TestConnections(); }
    }

    bool[] Input(int index){

        bool[] state0 = {false, false, false};
        bool[] state1 = {false, false, true};
        bool[] state2 = {false, true, false};
        bool[] state3 = {false, true, true};
        bool[] state4 = {true, false, false};
        bool[] state5 = {true, false, true};
        bool[] state6 = {true, true, false};
        bool[] state7 = {true, true, true};

        if(index == 0){ return state0; }
        if(index == 1){ return state1; }
        if(index == 2){ return state2; }
        if(index == 3){ return state3; }
        if(index == 4){ return state4; }
        if(index == 5){ return state5; }
        if(index == 6){ return state6; }
        if(index == 7){ return state7; }

        return state0;
    }

    bool[] Output(int index){

        bool[] state0 = {false, false};
        bool[] state1 = {true, false};
        bool[] state2 = {true, false};
        bool[] state3 = {false, true};
        bool[] state4 = {true, false};
        bool[] state5 = {false, true};
        bool[] state6 = {false, true};
        bool[] state7 = {true, true};

        if(index == 0){ return state0; }
        if(index == 1){ return state1; }
        if(index == 2){ return state2; }
        if(index == 3){ return state3; }
        if(index == 4){ return state4; }
        if(index == 5){ return state5; }
        if(index == 6){ return state6; }
        if(index == 7){ return state7; }

        return state0;
    }

    void SetInput(int index){

        count = 0;
        states = Input(index);

        foreach(Transform child in PuzzleInputs){
            state = states[count];
            child.Find("PowerCube").GetComponent<PowerCube>().POWERSTATE = state;
            child.Find("PowerCube").GetComponent<PowerCube>().UpdateMaterial(state);
            count++;
        }

    }

    bool[] GetOutput(int index){

        bool[] output = {false, false};

        output[0] = PuzzleOutput0.GetComponent<PowerLine>().POWERED;
        output[1] = PuzzleOutput1.GetComponent<PowerLine>().POWERED;

        return output;

    }

    bool TestConnection(int index){

        current_output = GetOutput(index);
        expected_output = Output(index);

        Debug.Log("Testing Sum: " + current_output[0] + " == " + expected_output[0]);
        Debug.Log("Testing Carry: " + current_output[1] + " == " + expected_output[1]);
        if(current_output[0] == expected_output[0]){
            if(current_output[1] == expected_output[1]){
                return true;
            }
        }

        return false;
    }

    void TestConnections(){

        lastTest = lastTest + Time.deltaTime;

        if(lastTest > testFrequency){
            lastTest = 0;
            if(testcount != 0){
                if(TestConnection(testcount - 1)){
                    correctInputs++;
                }
            }
            SetInput(testcount);
            testcount++;
            if(testcount == testAmount + 1){
                testcount = 0;
                testing = false;
                SetInput(0);
                if(correctInputs == testAmount){
                    TestPassed = true;
                    Portal.SetActive(true);
                }
                else{
                    TestPassed = false;
                    Portal.SetActive(false);
                }
                correctInputs = 0;
            }
        }
    }
}
