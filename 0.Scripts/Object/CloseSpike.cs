using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseSpike : MonoBehaviour
{
    [SerializeField] private Transform[] destinations;
    [SerializeField] private GameObject[] interactionObjects;

    [SerializeField] private float speed;

    private BoxCollider collider;

    public GameObject[] InteractionObjects { get => interactionObjects; set => interactionObjects = value; }
    public float Speed { get => speed; set => speed = value; }

    private void Awake()
    {
        collider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("문 닫힘");

            // 각 오브젝트에 대해 이동 코루틴 시작
            for (int i = 0; i < InteractionObjects.Length; i++)
            {
                StartCoroutine(MoveToDestination(InteractionObjects[i], destinations[i]));
            }

            collider.enabled = false;
        }
    }

    IEnumerator MoveToDestination(GameObject obj, Transform target)
    {
        // 목표 지점에 도달할 때까지 이동
        while (Vector3.Distance(obj.transform.position, target.position) > 0.01f)
        {
            obj.transform.position = Vector3.MoveTowards(
                obj.transform.position,
                target.position,
                Speed * Time.deltaTime
            );

            yield return null; // 다음 프레임까지 대기
        }
    }
}
