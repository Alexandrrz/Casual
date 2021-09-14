using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopCubes : MonoBehaviour
{
    private int ind;


    public void ShopCube(int index)
    {
        PlayerPrefs.SetInt("Player", index);
    }

    public void ClickSkin(int ind)
    {
        PlayerPrefs.SetInt("Skins", ind);
    }
}
