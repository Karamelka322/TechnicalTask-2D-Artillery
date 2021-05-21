using UnityEngine;

public class ButtonSettingsInMainMenu : MonoBehaviour
{
    [SerializeField] private UiWindow _main;
    [SerializeField] private SettingsInMainMenu _setting;

    public void OnClickButtonSettings()
    {
        _setting.Open();
        _main.Close();
    }
}
