using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfGolden { get; private set; }
    public UnityEvent<PlayerInventory> OncollectGolden;

   
    public void GoldenCollect()
    {
        NumberOfGolden++;
        OncollectGolden.Invoke(this);
    }
    private void Update()
    {
        if (NumberOfGolden>PlayerPrefs.GetInt("_highscore"))
        {
            PlayerPrefs.SetInt("_highscore", NumberOfGolden);
        }
    }

}
