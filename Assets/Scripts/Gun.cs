
using System;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    [SerializeField] Player _myPlayer;

    public int damage;
    public float range;

    public Camera fpsCam;

    //public ParticleSystem muscleFlash;
    public GameObject dustImpact;

    public float score;

    public event Action scorePoint = delegate { };
    public event Action ResetEnemyPos = delegate { };
    public event Action OnShoot = delegate { };


    private void Start()
    {
        _myPlayer = GetComponentInParent<Player>();
        _myPlayer.onDead += PlayerDead;
        _myPlayer.OnDamagePowerUp += PowerUpDamage;
        //dustImpact = ParticleFactory.Instance.GetObjectFromPool().gameObject;
    }


    public void Shoot()
    {
        //muscleFlash.Play();

        OnShoot();

        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            IHitable target = hit.transform.GetComponent<IHitable>();
            if(target != null)
            {
                target.TakeLife(damage);
            }

            GameObject impactGO = Instantiate(dustImpact, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 1f);
        }
    }
    void PowerUpDamage(int newDamage)
    {
        damage += newDamage;
        Debug.Log(damage);
    }

    void PlayerDead()
    {
        this.enabled = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.forward);
    }
}
