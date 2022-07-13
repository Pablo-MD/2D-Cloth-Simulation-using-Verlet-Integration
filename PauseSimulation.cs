using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSimulation : MonoBehaviour
{
    PhysicSimulation physicSimulation;
    bool activeSimulation = false;

    void Start()
    {
        physicSimulation = FindObjectOfType<PhysicSimulation>().GetComponent<PhysicSimulation>();
        physicSimulation.enabled = activeSimulation;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            activeSimulation = !activeSimulation;
            physicSimulation.enabled = activeSimulation;
        }
    }
}
