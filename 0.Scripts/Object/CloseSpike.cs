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
            Debug.Log("�� ����");

            // �� ������Ʈ�� ���� �̵� �ڷ�ƾ ����
            for (int i = 0; i < InteractionObjects.Length; i++)
            {
                StartCoroutine(MoveToDestination(InteractionObjects[i], destinations[i]));
            }

            collider.enabled = false;
        }
    }

    IEnumerator MoveToDestination(GameObject obj, Transform target)
    {
        // ��ǥ ������ ������ ������ �̵�
        while (Vector3.Distance(obj.transform.position, target.position) > 0.01f)
        {
            obj.transform.position = Vector3.MoveTowards(
                obj.transform.position,
                target.position,
                Speed * Time.deltaTime
            );

            yield return null; // ���� �����ӱ��� ���
        }
    }
}
