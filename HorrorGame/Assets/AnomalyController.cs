using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnomalyController : MonoBehaviour
{
    [SerializeField] private GameObject[] anomalier;
    GameObject anomalySphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    [SerializeField] private GameObject[] gutObjects;
    public float timer, interval = 2f;
    

    // Start is called before the first frame update
    void Start()
    {
      //GameObject yeet = anomalier[Random.Range(0, anomalier.Length)];

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            bool activateObejct = Random.Range(0, 2) == 1;
            if (activateObejct)
            {
                int randomIndex = Random.Range(0, anomalier.Length);
            
                for (int i = 0; i < anomalier.Length; i++)
                {
                    anomalier[i].SetActive(i == randomIndex); 
                }
                Debug.Log("Anomali Aktiv");
            }
            else
            {
                for (int i = 0; i < anomalier.Length; i++)
                {
                anomalier[i].SetActive(false);
                }
                Debug.Log("Ingen anomalier");
            }
            timer = 0;
        }
       
        
        
            /*for (int i = 0; i < anomalier.Length; i++)
            {
                int randomValue = Random.Range(0, 2);
                anomalier[i].SetActive(i == randomIndex);
            } */
            
        
                
    }
}
