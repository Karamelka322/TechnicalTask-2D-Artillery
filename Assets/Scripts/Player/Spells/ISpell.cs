using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpell
{
    Sprite Icon { get; }
    SpellEffect Effect { get; }

    void SpawnEffectSpell(Transform folder);
    void DeleteEffectSpell();
    void Shoot(Vector2 direction, State state);
}
