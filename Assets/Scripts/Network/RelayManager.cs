using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Networking.Transport.Relay;

public class RelayManager : MonoBehaviour
{
    [SerializeField] private static int maxPlayer = 4;

    public static string joinCode { get; private set; }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private async void Start()
    {
        await UnityServices.InitializeAsync();

        AuthenticationService.Instance.SignedIn += () =>
        {
            Debug.Log($"Logged in as: <color=#FFFFFF><b>{(string.IsNullOrEmpty(AuthenticationService.Instance.PlayerName) ? "Unknow" : $"{AuthenticationService.Instance.PlayerName}")}</b> (<b>{AuthenticationService.Instance.PlayerId}</b>)</color>");
        };

        await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }

    public static async void CreateRelay()
    {
        try
        {
            Allocation allocation = await RelayService.Instance.CreateAllocationAsync(maxPlayer);

            joinCode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);
            Debug.Log($"Join code: <color=#FFFFFF>{joinCode}</color>");

            RelayServerData relayServerData = new RelayServerData(allocation, "dtls");
            NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(relayServerData);

            NetworkManager.Singleton.StartHost();
        }
        catch (RelayServiceException ex)
        {
            Debug.LogError($"[RELAY SERVICE]\n{ex}");
        }
    }

    public static async void JoinRelay(string joinCode)
    {
        try
        {
            Debug.Log($"Joining relay with code: <color=#FFFFFF>{joinCode}</color>");
            JoinAllocation joinAllocation = await RelayService.Instance.JoinAllocationAsync(joinCode);

            RelayServerData relayServerData = new RelayServerData(joinAllocation, "dtls");
            NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(relayServerData);

            NetworkManager.Singleton.StartClient();
        }
        catch (RelayServiceException ex)
        {
            Debug.LogError($"[RELAY SERVICE]\n{ex}");
        }
    }
}
