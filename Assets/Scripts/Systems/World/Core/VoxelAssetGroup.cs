using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "Systems/Voxel/Organization/Create New Voxel Group")]
public class VoxelAssetGroup : ScriptableObject
{
    public List<VoxelAsset> Assets = new List<VoxelAsset>();
}
