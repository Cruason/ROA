using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookToTarget : MonoBehaviour
{
    public void OnLookTo(Creature entity, Vector3 target)
    {
        if (entity.transform.position.x - target.x < 0)
        {
            entity.transform.localScale = Vector3.one;
            entity.LookRight = true;
        }
        else
        {
            entity.transform.localScale = new Vector3 (-1,1,1);
            entity.LookRight = false;
        }
    }
}
