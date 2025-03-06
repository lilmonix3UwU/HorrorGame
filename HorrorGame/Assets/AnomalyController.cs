using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]


public class AnomalyController : MonoBehaviour
{
    [SerializeField] private GameObject[] anomalier;
    [SerializeField] private GameObject[] flyvendeAnomalier;
    [SerializeField] private GameObject[] shapeshiftAnomalier;
    [SerializeField] private GameObject[] regObjects;
    GameObject temp;
    bool anomaliCheck;
    bool startTimer;
    public float timer, interval = 2f;
    

    // Start is called before the first frame update
    void Start()
    {
        startTimer = true;
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
            int rando = Random.Range(0, 3);

            switch (rando)
            {
                case 0: RegAnomalier(); break;

                case 1:FlyvAnomalier(); break;

                case 2: ShapeshiftAnomalier() ; break;

                case 3: IngenAnomalier(); ; break;
            }

            timer = 0;
            startTimer = true;
        }       
    }

    void RegAnomalier()
    {
        temp = anomalier[Random.Range(0, anomalier.Length)];

        for (int i = 0; i < anomalier.Length; i++)
        {
            temp.SetActive(true);
            anomaliCheck = true;
        }
        Debug.Log("Anomali Aktiv");
    }

    void FlyvAnomalier()
    {
        temp = flyvendeAnomalier[Random.Range(0, flyvendeAnomalier.Length)];
        for (int i = 0; i < flyvendeAnomalier.Length; i++)
        {
            temp.SetActive(true);
            anomaliCheck = true;
        }
        Debug.Log("Flyvende anomali Aktiv");

    }

    void ShapeshiftAnomalier()
    {
        temp = shapeshiftAnomalier[Random.Range(0, shapeshiftAnomalier.Length)];
        for (int i = 0; i < shapeshiftAnomalier.Length; i++)
        {
            temp.SetActive(true);
            anomaliCheck = true;
        }

        Debug.Log("ShapeShifter");
    }

    void IngenAnomalier()
    {
        for (int i = 0; i < anomalier.Length; i++)
        {
            anomalier[i].SetActive(false);
            flyvendeAnomalier[i].SetActive(false);

        }
        for (int i = 0;i < flyvendeAnomalier.Length; i++)
        {
            flyvendeAnomalier[i].SetActive(false);
        }
        Debug.Log("Ingen anomalier");
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
