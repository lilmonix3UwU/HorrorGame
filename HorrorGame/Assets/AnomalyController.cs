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
            int activateObjectA = Random.Range(0, 100);
            //bool activateObjectF = Random.Range(0, 100) == activateObjectF <50);
            if (activateObjectA >= 25 && activateObjectA < 50)
            {

                int randomIndex = Random.Range(0, anomalier.Length);
            
                for (int i = 0; i < anomalier.Length; i++)
                {
                    anomalier[i].SetActive(i == randomIndex); 
                }
                Debug.Log("Anomali Aktiv");
            }
            if (activateObjectA >= 0 && activateObjectA < 25)
            {
                int randomIndex = Random.Range(0, flyvendeAnomalier.Length);
                for (int i = 0; i < flyvendeAnomalier.Length; i++)
                {
                    flyvendeAnomalier[i].SetActive(i == randomIndex);
                }
                Debug.Log("Flyvende anomali Aktiv");

            }
            if (activateObjectA > 50 && activateObjectA < 75)
            {
                Debug.Log("Sejhed");
            }
            else
            {
                for (int i = 0; i < anomalier.Length; i++)
                {
                 anomalier[i].SetActive(false);
                 flyvendeAnomalier[i].SetActive(false);
                }
                Debug.Log("Ingen anomalier");
            }
            timer = 0;
        }       
    }
}
