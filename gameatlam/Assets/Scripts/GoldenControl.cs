using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenControl : MonoBehaviour
{
    bool isWorking;
    public GameObject GoldenPrefab;
    public Transform ExitPosGolden;
    public List<GameObject> GoldenList = new List<GameObject>();
    public Transform TransformparentGolden;
    void Start()
    {
        StartCoroutine(GoldenSpawn());
    }

    IEnumerator GoldenSpawn()
    {
        while (true)
        {
            if (isWorking == true)
            {

                GameObject temp = Instantiate(GoldenPrefab, TransformparentGolden);
                temp.transform.position = new Vector3(Random.Range(10f, 15f), ExitPosGolden.position.y, Random.Range(20f, 60f));
                GoldenList.Add(temp);


                if (GoldenList.Count > 10)
                {
                    isWorking = false;
                }

            }
            else if (GoldenList.Count <= 10)
            {
                isWorking = true;
            }

            yield return new WaitForSeconds(0.00000000000000000000000000000000001f);
        }
    }
}
