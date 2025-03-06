using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private GameObject PlayerCameraRoot;
    private RaycastHit hit;
    [SerializeField] private float InteractionRange;
    public bool InteractionEnabled;
    void Start()
    {
        PlayerCameraRoot = GameObject.FindWithTag("CinemachineTarget"); 
        InteractionEnabled = true;
    }


    void Update()
    {
        
        Debug.DrawRay(PlayerCameraRoot.transform.position, PlayerCameraRoot.transform.forward, Color.red);
        if (Physics.Raycast(PlayerCameraRoot.transform.position, PlayerCameraRoot.transform.forward, out hit, InteractionRange))
        {
            if (hit.collider.gameObject.CompareTag("DoorEnter"))
            {
                if (Input.GetKeyDown(KeyCode.E) && InteractionEnabled)
                {
                    StartCoroutine(hit.collider.gameObject.GetComponent<RoomTransition>().EnterDoor()); 
                }
                
            }
        }

    }
}
