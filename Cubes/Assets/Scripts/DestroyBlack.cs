using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyBlack : MonoBehaviour
{
    public int needToUnlockk;
    public Button knopka;
    
    private void Start()
    {
        knopka.enabled = false;
        if (PlayerPrefs.GetInt("score") >= needToUnlockk) { 
            Destroy(gameObject);
            knopka.enabled = true;
        }

    }
}
