using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using Mirror.Discovery;
using UnityEngine.SceneManagement;

public class HomeMenu_FindRoom : MonoBehaviour
{
    public RectTransform roomGroup;
    public GameObject roomPrefab;

    NetworkDiscovery networkDiscovery;
    GameNetwork gameNetwork;

    Dictionary<long, ServerPack> discoveredServers = new Dictionary<long, ServerPack>();

    void Start()
    {
        networkDiscovery = FindObjectOfType<NetworkDiscovery>();
        gameNetwork = FindObjectOfType<GameNetwork>();

        networkDiscovery.OnServerFound.AddListener(OnDiscoveredServer);
    }

    public void Find()
    {
        Clear();
        networkDiscovery.StartDiscovery();
    }

    void Clear()
    {
        foreach (Transform child in roomGroup)
            Destroy(child.gameObject);
        discoveredServers.Clear();
    }

    public void OnDiscoveredServer(ServerResponse info)
    {
        if(discoveredServers.ContainsKey(info.serverId))
        {
            discoveredServers[info.serverId].info = info;
            discoveredServers[info.serverId].uiObject.GetComponentInChildren<Text>().text = info.EndPoint.Address.ToString();

            return;
        }

        GameObject serverUI = Instantiate(roomPrefab, roomGroup);
        serverUI.GetComponent<Button>().onClick.AddListener(() =>
        {
            gameNetwork.networkAddress = info.EndPoint.Address.ToString();
            GameplayManager.OnStartAction = OnStartPlayAction.ONLY_JOIN;
            SceneManager.LoadScene("Gameplay");
        });
        serverUI.GetComponentInChildren<Text>().text = info.EndPoint.Address.ToString();

        discoveredServers.Add(info.serverId, new ServerPack { uiObject = serverUI, info = info });
    }


    class ServerPack
    {
        public GameObject uiObject;
        public ServerResponse info;
    }
}
