using UnityEngine;

public class ControlPanel : MonoBehaviour
{
    public void OpenPanel()
    {
        gameObject.SetActive(true);
    }

    public void ClousePanel()
    {
        gameObject.SetActive(false);
    }
}
