using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameLoader : MonoBehaviour
{
    public Text playerText;
    public List<string> playerNames = new List<string>();
    
    // Start is called before the first frame update
    void Start()
    {
        LoadPlayerName();
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
