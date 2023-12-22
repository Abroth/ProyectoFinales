
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    [SerializeField] Player _myPlayer;

    public int damage;
    public float range;

    public Camera fpsCam;

    [SerializeField] public int shoots = 2;

    //public ParticleSystem muscleFlash;
    public GameObject dustImpact;

    AudioManager _audioManager;

    public float score;

    public event Action scorePoint = delegate { };
    public event Action ResetEnemyPos = delegate { };
    public event Action OnShoot = delegate { };
    public event Action OnReload = delegate { };


    private void Start()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        _myPlayer = GetComponentInParent<Player>();
        _myPlayer.onDead += PlayerDead;
        _myPlayer.OnDamagePowerUp += PowerUpDamage;
        //dustImpact = ParticleFactory.Instance.GetObjectFromPool().gameObject;
    }


    public void Shoot()
    {
        if(shoots > 0)
        {
            shoots--;
            //muscleFlash.Play();
            _audioManager.PlaySFX(_audioManager.shoot);
            OnShoot();

            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                IHitable target = hit.transform.GetComponent<IHitable>();
                if (target != null)
                {
                    target.TakeLife(damage);
                }

                GameObject impactGO = Instantiate(dustImpact, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 1f);
            }
            StartCoroutine(Reload());
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

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(2);
        shoots++;
        OnReload();
    }
}
