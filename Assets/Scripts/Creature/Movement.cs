using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool MoveRight;

    private BoxCollider2D boxCollider2D;
    private RaycastHit2D raycastHit2D;
    private Vector2 move;
    [SerializeField] private float _speed;

    private AllStats AllStats;
    private void Start()
    {
        AllStats = GetComponent<AllStats>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        DefaultSpeed();
    }

    public void MoveMotor(float x, float y)
    {
        move = new Vector2(x, y) * _speed;
        raycastHit2D = Physics2D.BoxCast(transform.position, boxCollider2D.size, 0, move,
            Mathf.Abs(move.magnitude * Time.deltaTime), LayerMask.GetMask("Creatures", "Blocking", "Cliff"));

        if (raycastHit2D.collider == null)
        {
            transform.Translate(move * Time.deltaTime);
        }

        if (move.x > 0)
        {
            MoveRight = true;
        }
        else if (move.x < 0)
        {
            MoveRight = false;
        }
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    public void DefaultSpeed()
    {
        _speed = AllStats.Speed;
    }

    public float GetSpeed()
    {
        return _speed;
    }

    public float GetDefaultSpeed()
    {
        return AllStats.Speed;
    }

    public void MoveThroughCliff()
    {
        if (raycastHit2D.collider)
        {
            if (raycastHit2D.collider.CompareTag("Water"))
            {
                transform.Translate(move * Time.deltaTime);
            }
        }
    }
}
