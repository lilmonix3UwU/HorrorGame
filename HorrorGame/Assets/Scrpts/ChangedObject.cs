using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangedObject : MonoBehaviour
{
    [SerializeField] GameObject unchangedObject;

    private void Awake()
    {
        unchangedObject.SetActive(false);
    }
    public void ResetObject()
    {
        unchangedObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
