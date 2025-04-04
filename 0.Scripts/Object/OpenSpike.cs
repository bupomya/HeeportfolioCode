using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSpike : MonoBehaviour
{
    [SerializeField] private CloseSpike closeSpike;
    [SerializeField] private Transform[] destinations;

    MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("�� ����");
            // �� ������Ʈ�� ���� �̵� �ڷ�ƾ ����
            for (int i = 0; i < closeSpike.InteractionObjects.Length; i++)
            {
                StartCoroutine(MoveToDestination(closeSpike.InteractionObjects[i], destinations[i]));
            }

            meshRenderer.enabled = false;
        }

        //���� ����� Count ���� (3�� ȹ��� ������ ���� ����)
        StageManager.StageCount++;
    }

    IEnumerator MoveToDestination(GameObject obj, Transform target)
    {
        // ��ǥ ������ ������ ������ �̵�
        while (Vector3.Distance(obj.transform.position, target.position) > 0.01f)
        {
            obj.transform.position = Vector3.MoveTowards(
                obj.transform.position,
                target.position,
                closeSpike.Speed * Time.deltaTime
            );

            yield return null; // ���� �����ӱ��� ���
        }
    }
}
