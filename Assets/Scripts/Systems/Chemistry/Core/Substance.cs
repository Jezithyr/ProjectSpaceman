using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Systems/Chemistry/Create New Substance")]
public class Substance : ScriptableObject
{
    public string Name = "Un-Named Substance";

    //temperatures in kelvin
    public float MeltingPoint = 0.0f;//might not use this

    public float BoilingPoint = 0.0f;//might not use this

    public float Mass = 1.0f; // grams per Mol
}
