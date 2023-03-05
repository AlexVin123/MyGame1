using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUpgrate : MonoBehaviour
{
    [SerializeField] TypeParameter parameter;
    private SystemUpgrade systemUpgrade;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    public void Init(SystemUpgrade system)
    {
        systemUpgrade = system;
    }

    public void OnClick()
    {
        Debug.Log("Click");
        if(systemUpgrade == null)
        {
            Debug.Log("Sytem False");
            return;
        }
        systemUpgrade.Ugrade(parameter);
    }
}
