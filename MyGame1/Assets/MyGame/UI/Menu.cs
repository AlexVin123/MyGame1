using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public void OpenClouse()
    {
        if(this.gameObject.active)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }

    private void OpenPanel()
    {
        this.gameObject.SetActive(true);
    }

    private void ClousePanel()
    {
        this.gameObject.SetActive(false);
    }


}
