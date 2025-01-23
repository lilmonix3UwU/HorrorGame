using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]


public class AnomalyController : MonoBehaviour
{
    [SerializeField] private GameObject[] anomalier;
    [SerializeField] private GameObject[] flyvendeAnomalier;
    GameObject anomalySphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    [SerializeField] private GameObject[] regObjects;
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
            int activateObejct = Random.Range(0, 2);
            if (activateObejct == 1)
            {

                int randomIndex = Random.Range(0, anomalier.Length);
            
                for (int i = 0; i < anomalier.Length; i++)
                {
                    anomalier[i].SetActive(i == randomIndex); 
                }
                Debug.Log("Anomali Aktiv");
            }
            if (activateObejct == 2)
            {
                int randomIndex = Random.Range(0, flyvendeAnomalier.Length);
                for (int i = 0; i < flyvendeAnomalier.Length; i++)
                {
                    flyvendeAnomalier[i].SetActive(i == randomIndex);
                }
                Debug.Log("Flyvende anomali Aktiv");

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
