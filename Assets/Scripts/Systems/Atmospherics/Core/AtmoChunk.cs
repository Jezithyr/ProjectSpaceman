using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableGameFramework;

public class AtmoChunk : Object
{
    //===statics===
    private static int MasterGasIdMaskSize = -1;
    private static int NumberOfGases = -1;
    private const int VoxelSize = 16;
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
            GasIds = new byte[MasterGasIdMaskSize];
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

    private void InitializeVoxels()
    {
        Voxels = new FluidVoxel[VoxelSize,VoxelSize,VoxelSize];
    }


    public AtmoChunk()
    {
        InitializeVoxels();


    }

    public static void RegisterGasIds(AtmosphericsModule atmoModule)
    {
        if (MasterGasIdMaskSize!= -1) //If we already initialized exit out
        {
            Debug.Log("WARNING: Already initialized Gas Ids");
            return;
        }
        NumberOfGases = (atmoModule.ActiveFluids.Count);
        MasterGasIdMaskSize = (atmoModule.ActiveFluids.Count)/4; //round to the nearest byte
        if ((atmoModule.ActiveFluids.Count)%4 > 0) MasterGasIdMaskSize += 1;
    }


}
