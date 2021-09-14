using UnityEngine;
using UnityEngine.UI;

public class chpok : MonoBehaviour
{
    public int need;
    public Button knopka;
    private void Start()
    {
        knopka.enabled = false;
        if (PlayerPrefs.GetInt("score") >= need)
            knopka.enabled = true;


    }
}
