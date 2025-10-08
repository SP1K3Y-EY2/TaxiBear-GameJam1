using Unity.VisualScripting;
using UnityEngine;

public class Goalkeeper : MonoBehaviour
{
    [SerializeField] private Vector2 FirstPatrolPos;
    [SerializeField] private Vector2 SecondPatrolPos;
    private Vector2 targetPos;

    [SerializeField] private float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.localPosition = FirstPatrolPos;

        targetPos = SecondPatrolPos;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector2.MoveTowards(transform.localPosition, targetPos, Time.deltaTime * speed);

        if (transform.localPosition == (Vector3)targetPos)
        {
            if (targetPos == FirstPatrolPos)
            {
                targetPos = SecondPatrolPos;
            }
            else
            {
                targetPos = FirstPatrolPos;
            }
            
        }
    }
}
