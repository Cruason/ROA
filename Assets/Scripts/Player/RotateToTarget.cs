using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToTarget : MonoBehaviour
{
    public void Rotate(Creature entity, Vector3 targetPosition)
    {
        var objectPosition = transform.position;
        float angle = AngleBetweenPoints(targetPosition, objectPosition);
        if (entity.transform.localScale.x == 1)
        {
            if (angle >= -90f && angle <= 90f)
            {
                transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
            }
        }
        else
        {
            if (angle < 0)
            {
                angle += 180;
            }
            else
            {
                angle -= 180;
            }
            if (angle >= -90f && angle <= 90f)
            {
                transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, -angle));
            }
        }
    }
    private float AngleBetweenPoints(Vector2 a, Vector2 b)
    {

        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
