using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableGameFramework;
using System.Linq;
public class WorldModule : Module
{
    public struct Voxel
    {
        readonly ushort type;

        ushort health;

        public Voxel(ushort type, ushort health)
        {
            this.type = type;
            this.health = health;
        }
    }

    [SerializeField] private List<VoxelAssetGroup> EnabledVoxelGroup = new List<VoxelAssetGroup>();

    private List<VoxelAsset> EnabledVoxels = new List<VoxelAsset>();

    private void LoadVoxels()
    {
        EnabledVoxels.Add(null);//adding a null element to stand for an empty voxel
        foreach (var VoxelGroup in EnabledVoxelGroup)
        {
            EnabledVoxels.Concat(VoxelGroup.Assets);
        }
    }


    public override bool Initialize()
    {
        EnabledVoxels.Clear();
        LoadVoxels();




        return true;
    }

    public override void Start()
    {
        
    }

    public override void Stop()
    {
        
    }
}
