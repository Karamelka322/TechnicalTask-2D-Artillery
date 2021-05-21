using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiInformationView : MonoBehaviour
{
    [SerializeField] private StateMachine _stateMachine;

    [Header("Health")]
    [SerializeField] private HealthContainer _health;
    [SerializeField] private Image _hpBar;

    [Header("Name")]
    [SerializeField] private string _nickName;
    [SerializeField] private TMP_Text _nameText;

    private int _startHealht;

    public string NickName 
    {
        set { _nickName = value; }
    }

    private void Start()
    {
        _nameText.SetText(_nickName);
        _startHealht = _health.ValueHealth;
    }

    private void OnEnable()
    {
        _health.ChangedHealth += OnChangedHealth;
    }

    private void OnDisable()
    {
        _health.ChangedHealth -= OnChangedHealth;
    }

    private void LateUpdate()
    {
        UiAdaptation();
    }

    private void OnChangedHealth()
    {
        var part = (float)_health.ValueHealth / (float)_startHealht;
        _hpBar.fillAmount = part;
    }

    private void UiAdaptation()
    {
        transform.eulerAngles = Vector3.zero;

        Vector2 direction = _stateMachine.transform.localScale.x < 0 ? Vector2.left : Vector2.right;
        FliipUi(direction);
    }

    private void FliipUi(Vector2 direction)
    {
        var scale = transform.localScale;

        if (CheckScale())
            scale = new Vector2(-scale.x, scale.y);

        transform.localScale = scale;

        bool CheckScale()
        {
            return (direction.x > 0 && scale.x < 0) || (direction.x < 0 && scale.x > 0);
        }
    }

    public void SetColorInUi(Color newColor)
    {
        _nameText.color = newColor;
        _hpBar.color = newColor;
    }
}
