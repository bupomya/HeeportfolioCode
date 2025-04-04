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
            Debug.Log("문 열림");
            // 각 오브젝트에 대해 이동 코루틴 시작
            for (int i = 0; i < closeSpike.InteractionObjects.Length; i++)
            {
                StartCoroutine(MoveToDestination(closeSpike.InteractionObjects[i], destinations[i]));
            }

            meshRenderer.enabled = false;
        }

        //열쇠 습득시 Count 증가 (3개 획득시 보스방 진입 가능)
        StageManager.StageCount++;
    }

    IEnumerator MoveToDestination(GameObject obj, Transform target)
    {
        // 목표 지점에 도달할 때까지 이동
        while (Vector3.Distance(obj.transform.position, target.position) > 0.01f)
        {
            obj.transform.position = Vector3.MoveTowards(
                obj.transform.position,
                target.position,
                closeSpike.Speed * Time.deltaTime
            );

            yield return null; // 다음 프레임까지 대기
        }
    }
}
