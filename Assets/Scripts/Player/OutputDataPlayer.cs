using UnityEngine;

public class OutputDataPlayer : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;
    [Space]
    [SerializeField] private UiInformationView _information;
    [SerializeField] private SpriteRenderer _spriteLight;
    [SerializeField] private SpriteRenderer _spritePlayer;

    private void Awake()
    {
        _information.NickName = _playerData.Name;

        _spriteLight.color = _playerData.Color;
        _spritePlayer.color = _playerData.Color;

        _information.SetColorInUi(_playerData.Color);
    }
}
