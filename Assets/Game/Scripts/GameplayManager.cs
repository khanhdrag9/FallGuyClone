using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror.Discovery;

public enum OnStartPlayAction
{
    CREATE_AND_JOIN, ONLY_JOIN
}

public class GameplayManager : MonoBehaviour
{
    public GameNetwork networkMgrPrefab;


    public static OnStartPlayAction OnStartAction { get; set; } = OnStartPlayAction.CREATE_AND_JOIN;

    GameNetwork gameNetwork;
    NetworkDiscovery networkDiscovery;

    void Awake()
    {
        Application.targetFrameRate = 60;
        gameNetwork = FindObjectOfType<GameNetwork>();
        if (gameNetwork == null)    //in editor
            gameNetwork = Instantiate(networkMgrPrefab);

        networkDiscovery = gameNetwork.GetComponent<NetworkDiscovery>();
    }

    void Start()
    {
        if (OnStartAction == OnStartPlayAction.CREATE_AND_JOIN)
        {
            gameNetwork.StartHost();
            networkDiscovery.AdvertiseServer();
        }
        else if(OnStartAction == OnStartPlayAction.ONLY_JOIN)
        {
            gameNetwork.StartClient();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
