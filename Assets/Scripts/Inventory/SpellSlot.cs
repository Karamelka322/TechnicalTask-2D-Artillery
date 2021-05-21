using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class SpellSlot : MonoBehaviour
{
    [SerializeField] private Image _icon;

    private UiInventoryView _inventory;
    private Animator _animator;
    
    public Spell Spell { get; private set; }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        Quit();
    }

    public void SetSpellInInventory()
    {
        _inventory.NowUseSlot = this;
    }

    public void Use()
    {
        _animator.speed = 1f;
        _animator.Play("SpellSlot_Start");
    }

    public void Quit()
    {
        _animator.speed = 0f;
    }

    public void Fill(Spell dataSpell, UiInventoryView inventory)
    {
        Spell = dataSpell;
        _inventory = inventory;
        
        _icon.sprite = Spell.Icon;
    }
}
