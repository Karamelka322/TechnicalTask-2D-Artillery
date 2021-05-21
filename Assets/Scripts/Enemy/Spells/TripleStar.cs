using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Spells/TripleStar", fileName = "TripleStar", order = 51)]
public class TripleStar : Spell
{
    [Space]
    [SerializeField] private float _offsetY;
    [SerializeField] private float _delayBetweenBullets;

    private EnemyStateMachine _enemy;

    public override void Shoot(Vector2 targetPoint, State state)
    {
        _enemy = FindObjectOfType<EnemyStateMachine>();

        state.StartCoroutine(TripleShoot(targetPoint));
    }

    IEnumerator TripleShoot(Vector2 targetPoint)
    {
        for (int i = 0; i < 3; i++)
        {
            SpawnBullet(targetPoint);

            yield return new WaitForSeconds(_delayBetweenBullets);
        }
    }

    public void SpawnBullet(Vector2 targetPoint)
    {
        var spawnPoint = new Vector2(_enemy.transform.position.x, _enemy.transform.position.y + _offsetY);
        Vector3 direction = spawnPoint - targetPoint;

        Bullet bullet = Instantiate(_bullet, spawnPoint, Quaternion.identity, null);
        bullet.Direction = -direction;
    }
}
