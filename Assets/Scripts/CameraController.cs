using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class CameraController : NetworkBehaviour
{
    [SerializeField] private CinemachineVirtualCamera vCam1stPerson;
    [SerializeField] private CinemachineVirtualCamera vCam3rdPerson;

    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            vCam1stPerson.Priority = 1;
            vCam3rdPerson.Priority = 1;
        }
        else
        {
            vCam1stPerson.Priority = 0;
            vCam3rdPerson.Priority = 0;
        }
    }
}
