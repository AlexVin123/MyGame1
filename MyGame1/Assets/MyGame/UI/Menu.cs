using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Menu : MonoBehaviour
{
    public event UnityAction PanelCloused;
    public event UnityAction PanelOpen;
    public virtual void OpenClouse(InputAction.CallbackContext obj)
    {
        if(gameObject.activeInHierarchy)
        {
            Clouse();
        }
        else
        {
            Open();
        }
    }

    public virtual void Open()
    {
        PanelOpen?.Invoke();
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public virtual void Clouse()
    {
        gameObject.SetActive(false);
        PanelCloused?.Invoke();
        Time.timeScale = 1;
    }

    public void ReturnInMainMeny()
    {
        Time.timeScale = 1;
        SceneTransition.SwithToScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
