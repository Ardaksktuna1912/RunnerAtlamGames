using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScooterControl : MonoBehaviour
{

    public List<GameObject> ScooterList = new List<GameObject>();
    public GameObject Scooterprefab;
    bool isWorking;
    public Transform Exitpos;
    public Transform ScooterTransformParent;
    public int scootersayisi;
    public float uretmezamani;



    private void Start()
    {

        StartCoroutine(SpawnScooter());
    }


    IEnumerator SpawnScooter()
    {
        while (true)
        {
            if (isWorking == true)
            {

                GameObject temp = Instantiate(Scooterprefab, ScooterTransformParent);
                temp.transform.position = new Vector3(Random.Range(9.6f, 15.4f), Exitpos.position.y, Exitpos.position.z);
                ScooterList.Add(temp);
                if (ScooterList.Count > scootersayisi)
                {
                    isWorking = false;
                }

            }
            else if (ScooterList.Count <= scootersayisi)
            {
                isWorking = true;
            }

            yield return new WaitForSeconds(uretmezamani);
        }

    }


}
