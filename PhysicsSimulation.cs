using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PhysicsSimulation
{

    //"Coding Math"/"Sebastian Lague" Verlet's Integration Implementations 
    // Transcribed on my way, in the future will be also be done in another way.
    public static void Verlet( Node[] web,  Stick[] sticks, float g)
    {
        foreach (Node node in web)
        {
            if (!node.isFixed)
            {
                Vector3 positionBeforeUpdate = node.position;            
                node.position += node.position - node.previousPosition + g * Time.deltaTime * Time.deltaTime * Vector3.down;
                node.previousPosition = positionBeforeUpdate;
            }
        }

        for (int i = 0; i < 5; i++)
        {
            foreach (Stick stick in sticks)
            {
                Vector2 stickCentre = (stick.nodeA.position + stick.nodeB.position) / 2;
                Vector2 stickDir = (stick.nodeA.position - stick.nodeB.position).normalized;
                if (!stick.nodeA.isFixed)
                {
                    stick.nodeA.position = stickCentre + stickDir * stick.length / 2;
                }
                if (!stick.nodeB.isFixed)
                {
                    stick.nodeB.position = stickCentre - stickDir * stick.length / 2;
                }
            }
        }
    }
    //Intention to code another Verlet integration, using this time  somewhat more complex and real-like physiscs
}
