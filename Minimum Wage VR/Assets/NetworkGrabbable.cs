using UnityEngine;
using Unity.Netcode;
using UnityEngine.XR.Interaction.Toolkit;

public class NetworkGrabbable : NetworkBehaviour
{
    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(OnSelectEntered);
    }

    private void OnDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(OnSelectEntered);
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        Debug.Log($"[{NetworkManager.Singleton.LocalClientId}] Attempting to grab {gameObject.name}");
        // Only request ownership if we're a client (not the host) and not already the owner
        if (IsClient && !IsOwner)
        {
            Debug.Log("Requesting ownership from server...");
            RequestGrabServerRpc();
        }
    }

    [ServerRpc(RequireOwnership = false)]
    private void RequestGrabServerRpc(ServerRpcParams rpcParams = default)
    {

        ulong requestingClientId = rpcParams.Receive.SenderClientId;

        Debug.Log($"Server received grab request from client {requestingClientId} for {gameObject.name}");

        // Transfer ownership to the grabbing client
        NetworkObject.ChangeOwnership(requestingClientId);
    }
}
