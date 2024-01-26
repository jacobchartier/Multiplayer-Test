using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Cinemachine;

public class CameraManager : NetworkBehaviour
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
