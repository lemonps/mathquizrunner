using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Popup : MonoBehaviour
{
    public GameObject Panel;
    
    int count;
    public void showPopup()
    {
        count++;
        if(count%2 == 0)
        {
            Panel.gameObject.SetActive(false);
        }
        else{
            Panel.gameObject.SetActive(true);
        }

    }
}
