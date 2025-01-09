using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RoomTransition : MonoBehaviour
{

    private GameObject player;
    [SerializeField] private Animator _doorHinge;
    [SerializeField] private GameObject _door;
    [SerializeField] private GameObject _startPoint;
    [SerializeField] private GameObject _endPoint;
    private bool moveToStartPoint;
    private bool moveToEndPoint;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        moveToStartPoint = false;
        moveToEndPoint = false;
    }
    private void Update()
    {
        if (moveToStartPoint)
        {
            //player.transform.rotation = Quaternion.Lerp(player.transform.rotation, _startPoint.transform.rotation, 2);
            player.transform.position = Vector3.Lerp(player.transform.position, _startPoint.transform.position, 2);
        }
        if (moveToEndPoint)
        {
            player.transform.position = Vector3.Lerp(_startPoint.transform.position, _endPoint.transform.position, 4);
        }
    }

    public IEnumerator EnterDoor()
    {
        Debug.Log("the thing did a done");
        player.GetComponent<PlayerInput>().enabled = false;
        moveToStartPoint = true;
        _doorHinge.SetTrigger("OpenDoor");

        yield return new WaitForSeconds(2);
        moveToStartPoint = false;
        moveToEndPoint = true;


        yield return new WaitForSeconds(4);
        moveToEndPoint = false;
        _doorHinge.SetTrigger("CloseDoor");
        yield return new WaitForSeconds(2);
        _doorHinge.SetTrigger("Done");
        player.GetComponent<PlayerInput>().enabled = true;

    }
}
