using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private static SceneTransition _instance;
    private Animator _animator;
    private AsyncOperation _asyncOperation;
    private static bool _shouldPlayEndLoadScene = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _instance = this;
        if (_shouldPlayEndLoadScene)
            _animator.SetTrigger("EndLoad");
    }

    public static void SwithToScene(int idScene)
    {
        _instance._animator.SetTrigger("EndCutScene");
        _instance._asyncOperation = SceneManager.LoadSceneAsync(idScene);
        _instance._asyncOperation.allowSceneActivation = false;
    }

    public void OnAnimationOver()
    {
        _shouldPlayEndLoadScene = true;
        _instance._asyncOperation.allowSceneActivation = true;
    }

    public void Swith()
    {
        SceneTransition.SwithToScene(1);
    }
}
