using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotObject : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float hitSpeed;
    [SerializeField] private float destroyTime;
    private float timer;
    [SerializeField] private int damage;
    [SerializeField] private float knockbackForce;
    [SerializeField] private GameObject player;
    //[SerializeField] private ParticleSystem explosionParticle;

    [SerializeField] private float detectionRadius;  // OverlapSphere �ݰ�
    [SerializeField] private LayerMask targetLayer;  // ������ ��� Layer

    private Vector3 shotDirection;
    [SerializeField]private bool isHit;
    public bool IsHit { get => isHit; set => isHit = value; }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (isHit)
        {
            //�÷��̾ ���ݽ�
            transform.Translate(new Vector3(-shotDirection.x, 0, -shotDirection.z) * hitSpeed * Time.deltaTime);
        }
        else
        {
            //�Ϲݰ���
            shotDirection = (player.transform.position - transform.position).normalized;
            transform.Translate(new Vector3(shotDirection.x, 0, shotDirection.z) * speed * Time.deltaTime);
        }

        timer += Time.deltaTime;

        if (timer >= destroyTime)
        {
            transform.position = Vector3.zero;
            Destroy(gameObject);
        }

        CheckCollision();
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player") && !isHit)
        {
            Debug.Log($"{other.name} Ÿ��");
            other.GetComponent<Health>().Hit(damage, knockbackForce);
            //transform.position = Vector3.zero;
            Destroy(gameObject);
        }

        if (other.tag.Equals("Enemy") && isHit)
        {
            Debug.Log($"{other.name} Ÿ��");
            other.GetComponent<Health>().Hit(damage, knockbackForce);
            //transform.position = Vector3.zero;
            Destroy(gameObject);
        }
    }*/

    private void CheckCollision()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, detectionRadius, targetLayer);

        foreach (Collider hit in hits)
        {
            Debug.Log($"{hit.name} Ÿ��");
            hit.GetComponent<Health>().Hit(damage, knockbackForce);
            Destroy(gameObject);
        }
    }
}
