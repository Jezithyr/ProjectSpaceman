using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "Systems/Voxel/Create New Voxel Type")]
public class VoxelChunkData
{
    public const int VoxelSize = 16;

    private WorldModule.Voxel[,,] voxels =new WorldModule.Voxel[VoxelSize,VoxelSize,VoxelSize];
    public WorldModule.Voxel[,,] Voxels{get=>voxels;}
}


public class VoxelChunk : MonoBehaviour
{





}
