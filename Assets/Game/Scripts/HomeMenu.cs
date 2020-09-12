using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeMenu : MonoBehaviour
{
    public Button createRoomBtn;
    public Button findRoomBtn;
    public GameObject findRoomLayout;

    GameNetwork gameNetwork;
    HomeMenu_FindRoom findRoom;

    void Start()
    {
        gameNetwork = FindObjectOfType<GameNetwork>();
        findRoom = GetComponent<HomeMenu_FindRoom>();

        createRoomBtn.onClick.AddListener(OnCreateRoom);    
        findRoomBtn.onClick.AddListener(OnFindRoom);

        Cursor.lockState = CursorLockMode.None;
    }

    void OnCreateRoom()
    {
        SceneManager.LoadScene("Gameplay");
    }

    void OnFindRoom()
    {
        findRoomLayout.SetActive(true);
        findRoom.Find();
    }

}
