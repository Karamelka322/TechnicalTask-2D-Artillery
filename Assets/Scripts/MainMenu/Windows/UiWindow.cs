using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class UiWindow : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Open() 
    {
        gameObject.SetActive(true);
    }

    public void Close()
    { 
        _animator.Play("Window_Close");
        StartCoroutine(DisableWindow());
    }

    IEnumerator DisableWindow()
    {
        yield return new WaitForSeconds(.3f);
        gameObject.SetActive(false);
    }
}
