using UnityEngine;
using Unity.Netcode;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NetworkedPrefabsList", menuName = "Netcode/NetworkedPrefabsList")]
public class NetworkedPrefabsList : ScriptableObject
{
    public List<NetworkPrefab> prefabs = new List<NetworkPrefab>();
}

[System.Serializable]
public class NetworkPrefab
{
    public GameObject Prefab;
    public bool PlayerPrefab; // optional flag
}

