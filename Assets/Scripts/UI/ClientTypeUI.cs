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
    [SerializeField] private TMP_Text codeText;
    [SerializeField] private GameObject codePanel;

    private void Update()
    {
        clientTypeText.SetText(TestingNetCodeUI.typeSelected);
        codeText.SetText(string.IsNullOrEmpty(RelayManager.joinCode) ? TestingNetCodeUI.state : $"{RelayManager.joinCode}");

        if (clientTypeText.text == "CLIENT")
        {
            codePanel.SetActive(false);
        }
    }
}
