using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiInventoryView : MonoBehaviour
{
    [SerializeField] private PlayerData _player;
    [SerializeField] private SpellSlot _spellSlotTemplate;

    private List<SpellSlot> _spellSlots;
    private SpellSlot _nowUseSlot;

    public SpellSlot NowUseSlot 
    {
        get 
        { 
            return _nowUseSlot; 
        }
        set 
        { 
            if(_nowUseSlot != null)
                _nowUseSlot.Quit();

            _nowUseSlot = value;
            _nowUseSlot.Use();
        }
    }

    private void Start()
    {
        _spellSlots = new List<SpellSlot>();

        SpawnSpellSlot();
    }

    private void SpawnSpellSlot()
    {
        for (int i = 0; i < _player.Inventory.Spells.Length; i++)
        {
            _spellSlots.Add(Instantiate(_spellSlotTemplate, transform));
            _spellSlots[i].Fill(_player.Inventory.Spells[i], this);
        }

        NowUseSlot = _spellSlots[0];
    }
}
