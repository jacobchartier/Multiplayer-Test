using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.Netcode;
using System.Runtime.CompilerServices;

public class ClientTypeUI : MonoBehaviour
{
    [SerializeField] private TMP_Text clientTypeText;

    private void Update()
    {
        clientTypeText.SetText(TestingNetCodeUI.typeSelected);
    }
}
