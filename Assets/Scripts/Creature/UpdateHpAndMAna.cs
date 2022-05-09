using UnityEngine;

public class UpdateHpAndMAna : MonoBehaviour
{
    private AllStats AllStats;

    private void Start()
    {
        AllStats = GetComponent<AllStats>();
    }
    public void UpdateHP(float amount)
    {
        AllStats.Hp += amount;
        if(AllStats.Hp >= AllStats.MaxHp)
        {
            AllStats.Hp = AllStats.MaxHp;
        }
        if(AllStats.Hp <= 0)
        {
            AllStats.Hp = 0;
        }
    }

    public void UpdateMana(float amount)
    {
        AllStats.Mana += amount;
        if (AllStats.Mana >= AllStats.MaxMana)
        {
            AllStats.Mana = AllStats.MaxMana;
        }
        if (AllStats.Mana <= 0)
        {
            AllStats.Mana = 0;
        }
    }
}
