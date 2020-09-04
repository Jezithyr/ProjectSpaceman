using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Systems/Chemistry/Create New Reaction")]
public class Reaction : ScriptableObject
{
    [System.Serializable]
   public struct SubstancePair
   {
       public Substance Input;
       public float Amount;
        public SubstancePair(Substance input, float amount)
        {
            Input = input;
            Amount = amount;
        }
    }

    public float RequiredTemperature = 873.15f;

    public List<SubstancePair> Reagents = new List<SubstancePair>();

    public List<SubstancePair> Products = new List<SubstancePair>();

    public float ReationRate = 1.0f;

}
