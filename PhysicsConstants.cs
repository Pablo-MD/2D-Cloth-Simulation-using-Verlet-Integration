using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PhysicsConstants : ScriptableObject
{
    //gravity
    public float g = 1f;
    //Density of the fluid
    public float rho;
    //viscosity of the fluid
    public float viscosity;
}
