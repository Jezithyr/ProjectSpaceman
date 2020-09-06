

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "Systems/Voxel/Create New Voxel Type")]
public class VoxelAsset : ScriptableObject
{
    [SerializeField] private Mesh model;
    public Mesh Model{get=>model;}
    [SerializeField] private Material[] meshMaterials;
    [SerializeField] private ushort MaxHealth;
    public Material[] MeshMaterials{get=>meshMaterials;}
    public Material MeshMaterial{get=>meshMaterials[0];}
}
