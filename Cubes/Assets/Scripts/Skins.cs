using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skins : MonoBehaviour
{
    public Image  Skin, Skin2, Skin3, Skin4, Skin5, Skin6, Skin7, Skin8, Skin9, Skin10;


    private void Update()
    {
        if (PlayerPrefs.GetInt("Skins") == 0)
        {
            Skin.enabled = true;
            Skin2.enabled = false;
            Skin3.enabled = false;
            Skin4.enabled = false;
            Skin5.enabled = false;
            Skin6.enabled = false;
            Skin7.enabled = false;
            Skin8.enabled = false;
            Skin9.enabled = false;
            Skin10.enabled = false;
        }
        if (PlayerPrefs.GetInt("Skins") == 1)
        {
            Skin.enabled = false;
            Skin2.enabled = true;
            Skin3.enabled = false;
            Skin4.enabled = false;
            Skin5.enabled = false;
            Skin6.enabled = false;
            Skin7.enabled = false;
            Skin8.enabled = false;
            Skin9.enabled = false;
            Skin10.enabled = false;
        }
        if (PlayerPrefs.GetInt("Skins") == 2)
        {
            Skin.enabled = false;
            Skin2.enabled = false;
            Skin3.enabled = true;
            Skin4.enabled = false;
            Skin5.enabled = false;
            Skin6.enabled = false;
            Skin7.enabled = false;
            Skin8.enabled = false;
            Skin9.enabled = false;
            Skin10.enabled = false;
        }
        if (PlayerPrefs.GetInt("Skins") == 3)
        {
            Skin.enabled = false;
            Skin2.enabled = false;
            Skin3.enabled = false;
            Skin4.enabled = true;
            Skin5.enabled = false;
            Skin6.enabled = false;
            Skin7.enabled = false;
            Skin8.enabled = false;
            Skin9.enabled = false;
            Skin10.enabled = false;
        }
          if (PlayerPrefs.GetInt("Skins") == 4)
          {
              Skin.enabled = false;
              Skin2.enabled = false;
              Skin3.enabled = false;
              Skin4.enabled = false;
              Skin5.enabled = true;
              Skin6.enabled = false;
              Skin7.enabled = false;
              Skin8.enabled = false;
              Skin9.enabled = false;
              Skin10.enabled = false;
        }
          if (PlayerPrefs.GetInt("Skins") == 5)
          {
              Skin.enabled = false;
              Skin2.enabled = false;
              Skin3.enabled = false;
              Skin4.enabled = false;
              Skin5.enabled = false;
              Skin6.enabled = true;
              Skin7.enabled = false;
              Skin8.enabled = false;
              Skin9.enabled = false;
              Skin10.enabled = false;
        }
          if (PlayerPrefs.GetInt("Skins") == 6)
          {
              Skin.enabled = false;
              Skin2.enabled = false;
              Skin3.enabled = false;
              Skin4.enabled = false;
              Skin5.enabled = false;
              Skin6.enabled = false;
              Skin7.enabled = true;
              Skin8.enabled = false;
              Skin9.enabled = false;
              Skin10.enabled = false;
        }
          if (PlayerPrefs.GetInt("Skins") == 7)
          {
              Skin.enabled = false;
              Skin2.enabled = false;
              Skin3.enabled = false;
              Skin4.enabled = false;
              Skin5.enabled = false;
              Skin6.enabled = false;
              Skin7.enabled = false;
              Skin8.enabled = true;
              Skin9.enabled = false;
              Skin10.enabled = false;
        }
          if (PlayerPrefs.GetInt("Skins") == 8)
          {
              Skin.enabled = false;
              Skin2.enabled = false;
              Skin3.enabled = false;
              Skin4.enabled = false;
              Skin5.enabled = false;
              Skin6.enabled = false;
              Skin7.enabled = false;
              Skin8.enabled = false;
              Skin9.enabled = true;
              Skin10.enabled = false;
        }
        if (PlayerPrefs.GetInt("Skins") == 9)
        {
            Skin.enabled = false;
            Skin2.enabled = false;
            Skin3.enabled = false;
            Skin4.enabled = false;
            Skin5.enabled = false;
            Skin6.enabled = false;
            Skin7.enabled = false;
            Skin8.enabled = false;
            Skin9.enabled = false;
            Skin10.enabled = true;
        }

    }
}
