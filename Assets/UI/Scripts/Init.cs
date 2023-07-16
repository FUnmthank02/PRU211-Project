using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{

    public CinemachineVirtualCamera virtualCamera;
    public GameObject selectedCharacter;
    GameObject player;
    public CameraFollow camera;
    // Start is called before the first frame update
    void Start()
    {
        selectedCharacter = CharacterSelect.selectedCharacter;
        //Instantiate(selectedCharacter, go.transform.position, Quaternion.identity);
        player = Instantiate(selectedCharacter);
        //GameObject virtualCameraGameObject = GameObject.Find("CM vcam1");
        if (camera != null)
        {
            //virtualCamera.Follow = player.transform;
            //virtualCamera.LookAt = player.transform;
            camera.target = player.transform;
        }

    }

    private void Update()
    {
        //virtualCamera.LookAt = player.transform;

    }





}