using System.Collections.Generic;
using UnityEngine;

public class GetHarm : MonoBehaviour
{
    private AllStats AllStats;

    private float _damageTaken;
    private float _armorUpdated;
    private float _magicResistanceUpdated;
    private Creature damageTaker;
    

    private void Start()
    {
        AllStats = GetComponent<AllStats>();
        damageTaker = GetComponent<Creature>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<IDamagable>()  != null)
        {
            var damage = collision.GetComponent<IDamagable>().GetDamage();
            if (damageTaker.GetType() != damage.Owner.GetType())
            {
            ReceiveDamage(damage);
            }
        }
    }
    public void ReceiveDamage(Damage damage)
    {
        UpdateStats();
        _damageTaken = damage.DamageAmountPhysical / _armorUpdated + damage.DamageAmountMagical / _magicResistanceUpdated;
        if(damage.IsCrit)
        {
            FloatingTextManager.Instance.ShowText("-" + _damageTaken, 30, Color.red, transform.position, Vector2.up * 50f, 2f);
        }
        else
        {
        FloatingTextManager.Instance.ShowText("-" + _damageTaken, 20, Color.yellow, transform.position, Vector2.up * 50f, 2f);
        }
        GetComponent<UpdateHpAndMAna>().UpdateHP(-_damageTaken);
    }

    private void UpdateStats()
    {
        _armorUpdated = 100 * (AllStats.Armor / (AllStats.Armor + 300));
        _magicResistanceUpdated = 100 * (AllStats.MagicResistance / (AllStats.MagicResistance + 300));
    }
}
