using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]


public class AnomalyController : MonoBehaviour
{
    [SerializeField] private GameObject[] anomalier;
    [SerializeField] private GameObject[] flyvendeAnomalier;
    
    [SerializeField] private GameObject[] regObjects;
    GameObject temp;
    bool anomaliCheck;
    bool startTimer;
    //anomaliArrays = new GameObject[2][];
    /* [SerializeField] private GameObject[][] anomaliArrays = new GameObject [2][];
     anomaliArrays = new GameObject[3]; */



    public float timer, interval = 2f;
    

    // Start is called before the first frame update
    void Start()
    {
        //GameObject anomalySphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //GameObject yeet = anomalier[Random.Range(0, anomalier.Length)];

    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        {
            timer += Time.deltaTime;
        }
        if (timer >= interval)
        {
            startTimer = false;
            int activateObjectA = Random.Range(1, 4); // DET HER VIRKER IKKE!!!
            //bool activateObjectF = Random.Range(0, 100) == activateObjectF <50);
            if (activateObjectA == 1) // && activateObjectA < 50)
            {

                
                temp = anomalier[Random.Range(0, anomalier.Length)];
            
                for (int i = 0; i < anomalier.Length; i++)
                {
                    temp.SetActive(true);
                    anomaliCheck = true;
                }
                Debug.Log("Anomali Aktiv");

                
            }

            if (activateObjectA == 2)// && activateObjectA < 25)
            {
                temp = anomalier[Random.Range(0, flyvendeAnomalier.Length)];
                for (int i = 0; i < flyvendeAnomalier.Length; i++)
                {
                    temp.SetActive(true);
                    anomaliCheck = true;
                }
                Debug.Log("Flyvende anomali Aktiv");
                

            }

            if (activateObjectA == 3)// && activateObjectA < 75)
            {
                Debug.Log("Sejhed");
                anomaliCheck = true;
            }

            if (activateObjectA == 4)
            {
                for (int i = 0; i < anomalier.Length; i++)
                {
                 anomalier[i].SetActive(false);
                 flyvendeAnomalier[i].SetActive(false);
                    
                
                }
                Debug.Log("Ingen anomalier");
            }
            if (activateObjectA == 0) 
            { 
                Debug.Log("Du har lavet en fejl dumbass");
                anomaliCheck = false;
            }

            

            timer = 0;
        }       
    }
    public void AnomaliCheck(bool anomali)
    {
        startTimer = true;
        if (anomali == anomaliCheck)
        {
            GameObject.Find("Controllers").GetComponent<PointsAndGameOver>().points++;
        }


        if (anomali)
        {
            if (temp.CompareTag("ChangedObject"))
            {
                temp.GetComponent<ChangedObject>().ResetObject();
            }
            else if (temp != null)
            {
                temp.SetActive(!temp.activeSelf);
            }
        }
    }
}
