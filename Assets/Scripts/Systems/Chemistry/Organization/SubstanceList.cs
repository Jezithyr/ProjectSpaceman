using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Systems/Chemistry/Organization/Create New Substance List")]
public class SubstanceList : ScriptableObject
{
    public List<Substance> Substances = new List<Substance>();
}
