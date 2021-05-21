using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : ScriptableObject, ISpell
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private SpellEffect _spellEffect;
    [SerializeField] protected Bullet _bullet;

    private SpellEffect _effect;

    public Sprite Icon => _icon;
    public SpellEffect Effect => _spellEffect;

    public virtual void SpawnEffectSpell(Transform folder)
    {
        _effect = Instantiate(_spellEffect, folder);
    }

    public virtual void DeleteEffectSpell()
    {
        _effect.Delete();
    }

    public virtual void Shoot(Vector2 touchPoint, State state) { }
}
