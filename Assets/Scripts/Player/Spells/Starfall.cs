using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/Spells/Starfall", fileName = "Starfall", order = 51)]
public class Starfall : Spell
{
    [Space]
    [SerializeField] private float _offsetY;

    public override void Shoot(Vector2 touchPoint, State state)
    {
        PlayerStateMachine player = FindObjectOfType<PlayerStateMachine>();

        var spawnPoint = new Vector2(player.transform.position.x, player.transform.position.y + _offsetY);
        Vector3 direction = spawnPoint - touchPoint;

        Bullet bullet = Instantiate(_bullet, spawnPoint, Quaternion.identity, null);
        bullet.Direction = -direction;
    }
}
