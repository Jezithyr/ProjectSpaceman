using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableGameFramework;

public class AtmoChunk : Object
{
    //===statics===
    private static int masterGasIdMaskSize = -1;
    private static int numberOfGases = -1;
    public static int NumberOfGases{get=>numberOfGases;}
    private const int chunkSize = 16;
    public static int ChunkSize{get=>chunkSize;}
    private const int voxelsize = 1;
    public static int Voxelsize{get=>voxelsize;}
    struct GasMolPair
    {
        int Gas;
        int MolIndex;

        public GasMolPair(int gas, int molIndex)
        {
            Gas = gas;
            MolIndex = molIndex;
        }
    }

    public struct FluidVoxel
    {
        byte[] GasIds;
        float[] Mols;
        float Pressure;
        float Temperature;
        public FluidVoxel(float pressure, float temperature)
        {
            GasIds = new byte[masterGasIdMaskSize];
            Mols = new float[NumberOfGases];
            Pressure = pressure;
            Temperature = temperature;
        }

        private int[] ParseGasIds(byte[] GasIdMask)
        {
            List<int> tempList = new List<int>();//TODO: this might be inefficent

            for (int i = 0; i < GasIdMask.Length; i++)
            {
                if (GasIdMask[i] >= 0)
                {
                    //Unpack the byte and check each bit
                    for (int j = 0; j < 4; j++)
                    {
                        if ((GasIdMask[i] & (1 << j)) != 0)
                        {
                            tempList.Add(j+i);
                        }
                    }
                }
            }
            return tempList.ToArray();
        }

        public void AddMols(byte[] GasIdMask,float[] mols)
        {
            foreach (var molIndex in ParseGasIds(GasIdMask))
            {
                mols[molIndex]+=mols[molIndex];
            }
        }

        public void SubtractMols(byte[] GasIdMask,float[] mols)
        {
            foreach (var molIndex in ParseGasIds(GasIdMask))
            {
                mols[molIndex]-=mols[molIndex];
            }
        }
    }
    //=========================


    private FluidVoxel[,,] Voxels;


    private Vector3 Origin;
    private void InitializeVoxels()
    {
        Voxels = new FluidVoxel[chunkSize,chunkSize,chunkSize];
        for (int x = 0; x < chunkSize; x++)
        {
           for (int y = 0; y < chunkSize; y++)
            {
                for (int z = 0; z < chunkSize; z++)
                {
                    Voxels[x,y,z] = new FluidVoxel(0,0);
                }
            } 
        }
    }

    public void SetOrigin(Vector3 newOrigin)
    {
        if (Origin==null) Origin= newOrigin;
    }


    public AtmoChunk()
    {
        InitializeVoxels();
    }

    public AtmoChunk(Vector3 newOrigin)
    {
        Origin = newOrigin;
        InitializeVoxels();
    }

    public static void RegisterGasIds(AtmosphericsModule atmoModule)
    {
        if (masterGasIdMaskSize!= -1) //If we already initialized exit out
        {
            Debug.Log("WARNING: Already initialized Gas Ids");
            return;
        }
        NumberOfGases = (atmoModule.ActiveFluids.Count);
        masterGasIdMaskSize = (atmoModule.ActiveFluids.Count)/4; //round to the nearest byte
        if ((atmoModule.ActiveFluids.Count)%4 > 0) masterGasIdMaskSize += 1;
    }


}
