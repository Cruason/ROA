using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActionManager : ActionManager
{
    private Player _player;
    private Enemy[] _enemies;
    private List<Enemy> _enemyList = new List<Enemy>();

    private float lastSwitchWeapon;
    private void Start()
    {
        FindEnemies();
        _player = FindObjectOfType<Player>();
    }
    private void Update()
    {
        EnemyBehaviour();
    }

    private void FindEnemies()
    {
        _enemies = FindObjectsOfType<Enemy>();
        for (int i = 0; i < _enemies.Length; i++)
        {
            _enemyList.Add(_enemies[i]);
        }
    }


    private void EnemyBehaviour()
    {
        for (int i = 0; i < _enemyList.Count; i++)
        {
            if (_enemyList[i] != null)
            {
                if(!_enemyList[i].Chase)
                {
                    if (Vector2.Distance(_player.transform.position, _enemyList[i].transform.position) < _enemyList[i].TriggerDistance)
                    {
                        _enemyList[i].Chase = true;
                        SearchForAllies(_enemyList[i]);
                    }
                    else
                    {
                        if (_enemyList[i].transform.position != _enemyList[i].SpawnPosition)
                        {
                            MoveToSpawn(_enemyList[i], _enemyList[i].SpawnPosition);
                        }
                        else
                        {
                            _enemyList[i].GoDirection = Vector2.zero;
                        }
                    }
                }
                else if (Vector2.Distance(_player.transform.position, _enemyList[i].transform.position) > _enemyList[i].ChaseDistance)
                {
                    _enemyList[i].Chase = false;
                }

                if (_enemyList[i].Chase)
                {
                    ChaseToTarget(_enemyList[i], _player);
                }
            }
            else
            {
                _enemyList.Remove(_enemyList[i]);
            }
        }
    }
    private void EnemyAttack(Enemy enemy, Creature target)
    {
        EnemyChooseWeapon(enemy, target);
        if (Vector2.Distance(enemy.transform.position, target.transform.position) <= enemy.WeaponManager._currentWeapon.AttackDistance)
        {
            enemy.Attack();
        }
    }

    private void EnemyChooseWeapon(Enemy enemy, Creature target)
    {

        
        if (Vector2.Distance(enemy.transform.position, target.transform.position) > enemy.WeaponManager._currentWeapon.AttackDistance)
        {
            if (TryToSwichWeapon(lastSwitchWeapon, 1f))
            {
                enemy.WeaponManager.SwitchWeapon();
                lastSwitchWeapon = Time.time;
            }
        }
        else if (Vector2.Distance(enemy.transform.position, target.transform.position) <= enemy.WeaponManager._currentWeapon.DontAttackDistance)
        {
            if (TryToSwichWeapon(lastSwitchWeapon, 1f))
            {
                enemy.WeaponManager.SwitchWeapon();
                lastSwitchWeapon = Time.time;
            }
        }
    }

    private bool TryToSwichWeapon(float lastSwitch, float changeDelay)
    {
        if (Time.time - lastSwitch > changeDelay)
        {
            return true;
        }
        return false;
    }

    private void AimToTarget(Enemy enemy, Creature target)
    {
        enemy.RotateToTarget.Rotate(enemy, target.transform.position);
    }

    private void ChaseToTarget(Enemy enemy, Creature target)
    {
        AimToTarget(enemy, target);
        EnemyAttack(enemy, target);
        MoveToTarget(enemy, target);
        LookTo(enemy, target.transform.position);
    }

    private void SearchForAllies(Enemy enemy)
    {
        for(int i=0;i<_enemyList.Count;i++)
        {
            if(Vector3.Distance(enemy.transform.position, _enemyList[i].transform.position) <= enemy.ChaseDistance)
            {
                Debug.Log("allie");
                _enemyList[i].Chase = true;
            }
        }
    }
}
