using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WinCondition : MonoBehaviour {

    private int _count;
    public Material GoalMat;
    public Material NoGoalMat;
    void Start()
    {
        _count = 0;
    }

    void Update()
    {
        bool pass = isEmpty();
    }
    void OnTriggerEnter(Collider other)
    {
        ++_count;
    }

    void OnTriggerExit(Collider other)
    {
        --_count;
    }

    bool isEmpty()
    {
        if (_count == 0)
        {
            gameObject.GetComponent<Renderer>().material = GoalMat;
            return true;
        }
        else{
            gameObject.GetComponent<Renderer>().material = NoGoalMat;
            return false;
        }
    }
}
