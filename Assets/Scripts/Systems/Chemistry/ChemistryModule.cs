using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableGameFramework;

public class ChemistryModule : Module
{

    [SerializeField] private List<SubstanceList> EnabledSubstances = new List<SubstanceList>();
    [SerializeField] private List<ReactionList> EnabledReactions = new List<ReactionList>();

    struct SubstanceData
    {
        public List<Reaction> UsedIn;
        public List<Reaction> CreatedBy;
        public List<Substance> Creates;

        public SubstanceData(List<Reaction> usedIn, List<Reaction> createdBy, List<Substance> creates)
        {
            UsedIn = usedIn;
            CreatedBy = createdBy;
            Creates = creates;
        }
    }

    private Dictionary<Substance, SubstanceData> SubstanceRegistry = new Dictionary<Substance, SubstanceData>();



    private void ProcessRecipes()
    {
        SubstanceRegistry.Clear();//prevent serialization fuckery
        foreach (var substanceList in EnabledSubstances)
        {
            foreach (var substance in substanceList.Substances)
            {
                SubstanceRegistry.Add(substance,new SubstanceData(new List<Reaction>(),new List<Reaction>(),new List<Substance>()));
            }
        }
        Debug.Log("test");
        //This isn't what it looks like...
        //Precalculate substance relationships and cache them for later use during runtime
        
        //TODO: Replace foreach with For i (Foreach runs slower on lists than arrays)
        foreach (var reactionList in EnabledReactions)
        {
            foreach (var reaction in reactionList.Reactions)
            {
                foreach (var substancePair in reaction.Reagents)
                {
                    SubstanceRegistry[substancePair.Input].UsedIn.Add(reaction);

                    foreach (var substancePair2 in reaction.Products)
                    {
                        SubstanceRegistry[substancePair.Input].Creates.Add(substancePair2.Input);
                    }
                }

                foreach (var substancePair in reaction.Products)
                {
                    SubstanceRegistry[substancePair.Input].CreatedBy.Add(reaction);
                }
            }
        }

    }




    public override bool Initialize()
    {
        ProcessRecipes();
        
        return true;
    }   

    public override void Start()
    {
    }

    public override void Stop()
    {

    }

    
}
