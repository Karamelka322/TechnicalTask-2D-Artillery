using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsInMainMenu : UiWindow
{
    [SerializeField] private PlayerData _player;

    [Header("Name")]
    [SerializeField] private int _maxLengthName;
    [SerializeField] private InputField _inputName;

    [Header("Color")]
    [SerializeField] private Image _icon;
    [SerializeField] private List<Color> _variantsHeroColor;

    private int _counterColor;

    private void Start()
    {
        _inputName.text = _player.Name;
        _icon.color = _player.Color;

        SetCounterColor();
    }

    public void OnValueChangedInputField()
    {
        _inputName.text = FilterInput(_inputName.text);

        string FilterInput(string str)
        {
            return str.ToString().Length >= _maxLengthName ? str.Substring(0, _maxLengthName) : str;
        }
    }
    
    public void OnEndEditInputField()
    {
        _inputName.text = _inputName.text == "" ? "Player" : _inputName.text;
        _player.Name = _inputName.text;
    }

    public void ReplaceHeroColor()
    {
        _counterColor = _counterColor + 1 != _variantsHeroColor.Count ? _counterColor + 1 : 0;
        _icon.color = _variantsHeroColor[_counterColor];
        _player.Color = _icon.color;
    }

    private void SetCounterColor()
    {
        for (int i = 0; i < _variantsHeroColor.Count; i++)
        {
            if (_variantsHeroColor[i] == _player.Color)
            {
                _counterColor = i;
                break;
            }
        }
    }
}
