using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAndLeaveBehind : MonoBehaviour
{
    [SerializeField]
    GameObject behind; Queue<GameObject> BehindPool = new Queue<GameObject>();

    //Pooling
    [SerializeField] int poolSize;

    public float pushForce = 50;
    Rigidbody2D rb;

    private void Start()
    {
        InitPool();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (behind != null)
            {
                SpawnFromPool(BehindPool, transform.position, transform.rotation);
                rb.AddForce(transform.up * pushForce);
            }
        }
    }

    void InitPool()
    {
        if (behind != null)
        {

            for (int i = 0; i < poolSize; i++)
            {
                GameObject obj = Instantiate(behind);
                obj.SetActive(false);
                BehindPool.Enqueue(obj);
            }
        }

    }

    //function to spawn an object; Use OnEnable for non-re-enabling objects
    public GameObject SpawnFromPool(Queue<GameObject> q,Vector3 position, Quaternion rotation)
    {
        GameObject objectToSpawn = q.Dequeue();
        if (objectToSpawn.activeSelf != true)
        {
            objectToSpawn.transform.rotation = rotation;

            objectToSpawn.transform.position = position;
            objectToSpawn.SetActive(true);

            q.Enqueue(objectToSpawn);

        }
        return objectToSpawn;
    }
}
