using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class AtmoGrid
{
    private AtmoChunk[,,] atmoChunks;

    private Vector3 Origin;

    public AtmoGrid(Vector3 newOrigin,Vector3Int initialGridSize)
    {
        Origin = newOrigin;
        atmoChunks = new AtmoChunk[initialGridSize.x,initialGridSize.y,initialGridSize.z];
        int voxelSize = AtmoChunk.Voxelsize*AtmoChunk.ChunkSize;
        for (int x = 0; x < initialGridSize.x; x++)
        {
            for (int y = 0; y < initialGridSize.y; y++)
            {
                for (int z = 0; z < initialGridSize.z; z++)
                {
                    Vector3 Temp = new Vector3(Origin.x+voxelSize,Origin.y+voxelSize,Origin.z+voxelSize);
                    atmoChunks[x,y,z].SetOrigin(Temp);
                }   
            }   
        }
    }
}
