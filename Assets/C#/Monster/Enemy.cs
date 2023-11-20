using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField]
    protected int Health;
    [SerializeField]
    protected int Gem;
    [SerializeField]
    protected int Speed;
    [SerializeField]
    protected float Range;
    [SerializeField]
    protected Transform PointA, PointB;
    protected GameObject PlayerObject;
    [SerializeField]
    protected GameObject DiamondPrefab;
    protected Vector3 PlayerDirections;
  
    protected Animator Anim;
    [SerializeField]
    private bool _goBack, _move;

    public int DamageableHealth { get; set; }

    public virtual void Init()
    {
        Anim =GetComponentInChildren<Animator>();
        
        PlayerObject = GameObject.Find("Player");
        DamageableHealth = Health;
    }
    private void Start()
    {
        Init();
    }
    public virtual void Update()
    {
        Movement();
        CheckPlayerIsNear();
        Health = DamageableHealth;
        if (PlayerObject != null)
        {
            PlayerDirections = PlayerObject.transform.position - transform.position;
        }
        
    }
   
    public virtual void Movement()
    {
        //Stop Moveing When Idle
        if (Anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") || Anim.GetCurrentAnimatorStateInfo(0).IsName("Death"))
        {
            return;
        }

        //Forward Movement
        if (_goBack == false && _move == true)
        {
            if (Vector3.Distance(transform.position, PointB.position) >= 0)
            {
                transform.localEulerAngles = new Vector3(0, 0, 0);
                this.gameObject.transform.position = Vector3.MoveTowards(transform.position, PointB.position, Speed * Time.deltaTime);
            }
            if (Vector3.Distance(transform.position, PointB.position) <= 0)
            {
                _goBack = true;
                Anim.SetTrigger("Idle");
                return;

            }
        }
        //Backward Movement
        if (_goBack == true && _move == true)
        {
            if (Vector3.Distance(transform.position, PointA.position) >= 0)
            {
                transform.localEulerAngles = new Vector3(0, 180, 0);
                this.gameObject.transform.position = Vector3.MoveTowards(transform.position, PointA.position, Speed * Time.deltaTime);
            }
            if (Vector3.Distance(transform.position, PointA.position) <= 0)
            {
                _goBack = false;
                Anim.SetTrigger("Idle");
               
            }
        }
    }
    public void CheckPlayerIsNear()
    {
        Vector3 facing = transform.localEulerAngles;
        //Check If Player Is Near
        if (PlayerObject != null)
        {
            if (Vector3.Distance(transform.position, PlayerObject.transform.position) <= Range)
            {

                if (facing.y == 0)
                {
                    _move = false;
                    Anim.SetBool("InCombat", true);

                    if (PlayerDirections.x >= 0)
                    {


                        transform.localEulerAngles = new Vector3(0, 0, 0);
                        _goBack = false;
                    }
                    else
                    {

                        transform.localEulerAngles = new Vector3(0, 180, 0);
                        _goBack = true;
                    }
                }
                else
                {

                    _move = false;
                    Anim.SetBool("InCombat", true);

                    if (PlayerDirections.x >= 0)
                    {

                        transform.localEulerAngles = new Vector3(0, 0, 0);
                        _goBack = false;
                    }
                    else
                    {

                        transform.localEulerAngles = new Vector3(0, 180, 0);
                        _goBack = true;
                    }
                }


            }
            else
            {
                Anim.SetBool("InCombat", false);
                _move = true;

            }
        }
    }

    public void Damage(int Damage)
    {
       
       
        if (PlayerDirections.x >= 0)
        {
            Debug.Log("Right");
            transform.localEulerAngles = new Vector3(0, 0, 0);
            _goBack = false;
        }
        else
        {
            Debug.Log("Left");
            transform.localEulerAngles = new Vector3(0, 180, 0);
            _goBack = true;
        }

        DamageableHealth -= Damage;
       
        Anim.SetTrigger("Hit");
        Anim.SetBool("InCombat", true);
        if(DamageableHealth == 0)
        {
            Death();
        }
    }
    public virtual void Death()
    {

        Diamond diamond = DiamondPrefab.GetComponent<Diamond>();
        diamond._value = Gem;
        Instantiate(DiamondPrefab, transform.position, Quaternion.identity);
        Collider2D collider = GetComponent<Collider2D>();
        collider.enabled = false;
        Anim.SetTrigger("Death");
        Destroy(this.gameObject, 1);
    }
}
