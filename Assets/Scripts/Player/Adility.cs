using UnityEngine;

public class Adility : MonoBehaviour
{
    [SerializeField] private UiInventoryView _inventory;

    private void OnEnable()
    {
        _inventory.NowUseSlot.Spell.SpawnEffectSpell(transform);
    }

    private void OnDisable()
    {
        _inventory.NowUseSlot.Spell.DeleteEffectSpell();
    }

    public void Shoot(Vector2 touchPoint, State state)
    {
        _inventory.NowUseSlot.Spell.Shoot(touchPoint, state);
    }
}
