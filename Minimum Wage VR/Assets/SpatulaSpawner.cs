using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class SpatulaSpawner : NetworkBehaviour
{
    [SerializeField] private NetworkObject  spatulaPrefab;

    private Vector3 spawnPos;

    public override void OnNetworkSpawn()
    {
        if(IsHost)
        {
            spawnPos = transform.position;
            NetworkObject spatulaInstance = Instantiate(spatulaPrefab, spawnPos, Quaternion.identity);
            spatulaInstance.Spawn();
        }
    }

}
