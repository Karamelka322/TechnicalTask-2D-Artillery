using UnityEngine;

public class ButtonPlayInMainMenu : MonoBehaviour
{
    [SerializeField] private LoadingScene _loadingScene;

    public void OnClickButtonPlay()
    {
        _loadingScene.LoadScene("Game");
    }
}
