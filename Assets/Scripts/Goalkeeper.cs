using System.Security.Cryptography;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

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
                FirstPatrolPos = new Vector2(Random.Range(-1.75f, 1.75f), Random.Range(0.25f, 0.75f));
            }
            else
            {
                targetPos = FirstPatrolPos;
                SecondPatrolPos = new Vector2(Random.Range(-1.75f, 1.75f), Random.Range(0.25f, 0.75f));
            }
            
        }
    }
}
