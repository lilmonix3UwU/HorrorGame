using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]


public class AnomalyController : MonoBehaviour
{
    [SerializeField] private GameObject[] anomalier;
    [SerializeField] private GameObject[] flyvendeAnomalier;
    GameObject anomalySphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    [SerializeField] private GameObject[] gutObjects;
    GameObject[][] storArray;
    //anomaliArrays = new GameObject[2][];
   /* [SerializeField] private GameObject[][] anomaliArrays = new GameObject [2][];
    anomaliArrays = new GameObject[3]; */
    
   

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
    }
}
