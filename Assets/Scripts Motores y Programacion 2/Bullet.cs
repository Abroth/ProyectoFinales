using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int _damage;
    [SerializeField] float _speed;


    void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;

        Destroy(gameObject, 4f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<IHitable>().TakeLife(_damage);
            Destroy(gameObject);
        }
    }
}
