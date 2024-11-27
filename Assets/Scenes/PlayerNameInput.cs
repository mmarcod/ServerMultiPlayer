using TMPro;
using Photon.Pun;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;

public class PlayerNameInput : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField = null;
    [SerializeField] private Button continueButton = null;
    public Text playerText;
    public List <string> playerNames = new List<string>();

    private const string PlayerPrefsNameKey = "PlayerName";

    private void Start()
    {
        SetUpInputField();
        continueButton.interactable = false;
    }

    private void SetUpInputField()
    {
        if(!PlayerPrefs.HasKey(PlayerPrefsNameKey))
        {
            return;
        }

        string defaultName = PlayerPrefs.GetString(PlayerPrefsNameKey);

        nameInputField.text = defaultName;

        SetPlayerName(defaultName);
    }

    public void SetPlayerName(string name)
    {
        if (nameInputField.text != null)
        continueButton.interactable = string.IsNullOrEmpty(name);
        else
            continueButton.interactable = false;

    }

    public void SavePlayerName()
    {
        string playerName = nameInputField.text;
        PhotonNetwork.NickName = playerName;

        PlayerPrefs.SetString(PlayerPrefsNameKey, playerName);


    }
    public void UpdatePlayerNameList()
    {
        playerNames.Clear();
        if (PhotonNetwork.InRoom)
        {
            foreach (Player player in PhotonNetwork.PlayerList)
            {
                playerNames.Add(player.NickName);
            }
        }
    }
    public void LoadPlayerName()
    {
        UpdatePlayerNameList();
        foreach (string name in playerNames)
        {
            playerText.text += "\n" + name;
        }
    }



}