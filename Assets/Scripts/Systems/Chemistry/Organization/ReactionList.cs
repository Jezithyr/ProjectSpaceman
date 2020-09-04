using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Systems/Chemistry/Organization/Create New Reaction List")]
public class ReactionList : ScriptableObject
{
    public List<Reaction> Reactions = new List<Reaction>();
}
