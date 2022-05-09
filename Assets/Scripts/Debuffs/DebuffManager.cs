using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffManager : MonoBehaviour
{
    private Creature debuffTaker;
    private List<BaseDebuff> _debuffList = new List<BaseDebuff>();

    void Start()
    {
        debuffTaker = GetComponent<Creature>();
    }

    void Update()
    {
        if (_debuffList.Count != 0)
        {
            DebuffsOnActive();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDebuff debuffable))
        {
            var debuff = debuffable.GetDebuff().DebuffInstance();
            var stackableDebuff = collision.GetComponent<IStackable>();
            if (IsOponent(collision))
            {
                var debuffExist = DebuffExist(debuff);
                if (debuffExist != null)
                {
                    if (stackableDebuff != null)
                    {
                        debuff = stackableDebuff.StackDebuff(debuffExist, debuff);
                    }
                    RemoveDebuff(debuffExist);
                }
                debuff.StartDebuff(debuffTaker);
                _debuffList.Add(debuff);
            }
        }
    }

    private bool IsOponent(Collider2D collider)
    {
        if (debuffTaker.GetType() != collider.GetComponent<WeaponBase>().Owner.GetType())
        {
            return true;
        }
        return false;
    }

    private BaseDebuff DebuffExist(BaseDebuff debuff)
    {
        if (_debuffList.Count != 0)
        {
            for (int i = 0; i < _debuffList.Count; i++)
            {
                if (_debuffList[i].GetType() == debuff.GetType())
                {
                    return _debuffList[i];
                }
            }
        }
        return null;
    }

    private void DebuffsOnActive()
    {
        for (int i = 0; i < _debuffList.Count; i++)
        {
            if (!_debuffList[i].OnDebaff(debuffTaker))
            {
                RemoveDebuff(_debuffList[i]);
            }
        }
    }

    private void RemoveDebuff(BaseDebuff debuff)
    {
        Debug.Log("removed");
        debuff.EndDebuff(debuffTaker);
        _debuffList.Remove(debuff);
    }


}
