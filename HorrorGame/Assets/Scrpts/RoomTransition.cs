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
    [SerializeField] private GameObject _anomilyController;
    [SerializeField] private bool anomilyGuess;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }





    public IEnumerator EnterDoor()
    {
        player.GetComponent<PlayerInteraction>().InteractionEnabled = false;
        Debug.Log("the thing did a done");
        player.GetComponent<PlayerInput>().enabled = false;
        _doorHinge.SetTrigger("OpenDoor");
        StartCoroutine(MovePlayer(player, _startPoint, 0.6f, true));
        

        yield return new WaitForSeconds(0.6f);
        StartCoroutine(MovePlayer(_startPoint, _endPoint, 1, false));


        yield return new WaitForSeconds(0.2f);
        _doorHinge.SetTrigger("CloseDoor");
        _anomilyController.GetComponent<AnomalyController>().AnomaliCheck(anomilyGuess);

        yield return new WaitForSeconds(1.2f);
        _doorHinge.SetTrigger("Done");
        player.GetComponent<PlayerInput>().enabled = true;
        player.GetComponent<PlayerInteraction>().InteractionEnabled = true;

    }



    private IEnumerator MovePlayer(GameObject startPos, GameObject endPos, float moveTime, bool rotate)
    {
        float elapsedTime = 0;
        while (elapsedTime < moveTime)
        {
            
            if (rotate)
            {
                player.transform.rotation = Quaternion.Lerp(startPos.transform.rotation, endPos.transform.rotation, elapsedTime / moveTime);
            }
            
            player.transform.position = Vector3.Lerp(startPos.transform.position, endPos.transform.position, elapsedTime / moveTime);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
