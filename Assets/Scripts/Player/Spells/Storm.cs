using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/Spells/Storm", fileName = "Storm", order = 51)]
public class Storm : Spell
{
    [Space]
    [SerializeField] private float _offsetY;

    public override void Shoot(Vector2 touchPoint, State state)
    {
        var spawnPoint = new Vector2(touchPoint.x, touchPoint.y + _offsetY);   

        Bullet bullet = Instantiate(_bullet, spawnPoint, Quaternion.identity, null);
        bullet.Direction = -bullet.transform.up;
    }
}
