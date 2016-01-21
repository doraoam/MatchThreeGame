using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings("0.1");
    }

    private const string roomName = "Board";
    private RoomInfo[] roomsList;

    void OnGUI()
    {
        if (!PhotonNetwork.connected)
        {
            GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
        }
        else if (PhotonNetwork.room == null)
        {
            if (GUI.Button(new Rect(100, 100, 250, 100), "Start Server"))
            {
                PhotonNetwork.CreateRoom(roomName + System.Guid.NewGuid().ToString("N"), new RoomOptions(){maxPlayers = 2}, null);
            }

            if (roomsList != null)
            {
                for (int i = 0; i < roomsList.Length; i++)
                {
                    if ((GUI.Button(new Rect(100, 250 + (110 * i), 250, 100), "Join " + roomsList[i].name)))
                    {
                        PhotonNetwork.JoinRoom(roomsList[i].name);
                    }
                }
            }
        }
    }

    void OnReceivedRoomListUpdate()
    {
        roomsList = PhotonNetwork.GetRoomList();
    }

    public GameObject playerPrefab;

    void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate(playerPrefab.name, Vector3.up * 5, Quaternion.identity, 0);
    }
}
