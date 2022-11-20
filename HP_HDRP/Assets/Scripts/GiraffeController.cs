using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;

public enum GiraffeState
{
    IDLE,
    WANDER,
    WANDER_TARGET,
    NOTICE_TARGET,
    TARGET,
    EAT
}

enum TargetType
{
    LEAF,
    PLAYER
}

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class GiraffeController : MonoBehaviour
{
    GameObject target = null;
    NavMeshAgent navAgent = null;
    Animator anim = null;
    private GiraffeState state = GiraffeState.IDLE;
    private TargetType type;

    private Vector3 lastTargetPos = Vector3.zero;

    [SerializeField]
    private float seekTargetTime = 0.5f;
    [SerializeField]
    private float viewDistance = 10.0f;
    [SerializeField]
    private float eatingTime = 10;
    [SerializeField]
    private float minWanderRadius = 10.0f;
    [SerializeField]
    private float maxWanderRadius = 30.0f;
    [SerializeField]
    private float minSeekTime = 15f;
    [SerializeField]
    private float maxSeekTime = 90f;
    [SerializeField]
    private float maxSeekDistance = 50f;
    [SerializeField]
    private float slowSpeed = 3.0f;
    [SerializeField]
    private float normalSpeed = 5.0f;
    [SerializeField]
    private float chargeSpeed = 7.0f;
    [SerializeField]
    private float chargeTime = 1.0f;

    [SerializeField] SoundPool sounds;

    private float T1 = 0;
    private float T2 = 0;
    private float T3 = 0;
    private float T4 = 0;


    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("FindTarget", 0.5f, seekTargetTime);
        state = GiraffeState.IDLE;
        T2 = maxSeekTime;
        StartCoroutine(RandomSounds());
    }

    // Update is called once per frame
    void Update()
    {
        float speed = normalSpeed;
        switch(state)
        {
            case GiraffeState.IDLE:
                if (target == null) state = GiraffeState.WANDER_TARGET;
                else
                {
                    T4 = chargeTime;
                    state = GiraffeState.NOTICE_TARGET;
                    anim.SetBool("Run", true);
                }
                break;
            case GiraffeState.WANDER_TARGET:
                Vector2 rpos = Random.insideUnitCircle.normalized * Random.Range(minWanderRadius, maxWanderRadius);
                navAgent.destination = transform.position + new Vector3(rpos.x, 0f, rpos.y);
                state = GiraffeState.WANDER;
                break;
            case GiraffeState.WANDER:
                if (target != null)
                {
                    T4 = chargeTime;
                    state = GiraffeState.NOTICE_TARGET;
                    anim.SetBool("Run", true);
                }
                else if (target == null && Vector3.Distance(new Vector3(transform.position.x, 0f, transform.position.z), new Vector3(navAgent.destination.x, 0f, navAgent.destination.z)) < 0.1f)
                {
                    state = GiraffeState.WANDER_TARGET;
                }
                //Debug.Log(Vector3.Distance(transform.position, navAgent.destination));
                break;
            case GiraffeState.NOTICE_TARGET:
                speed = chargeSpeed;
                if (T4 <= 0f)
                {
                    state = GiraffeState.TARGET;
                    anim.SetBool("Run", false);
                }
                break;
            case GiraffeState.TARGET:
                if (target == null) state = GiraffeState.WANDER_TARGET;
                if (target != null && target.CompareTag("Leaf") && Vector2.Distance(new Vector3(target.transform.position.x, target.transform.position.z), new Vector3(transform.position.x, transform.position.z)) < 0.1f)
                {
                    navAgent.destination = transform.position;
                    T1 = eatingTime;
                    state = GiraffeState.EAT;
                }
                else if (target != null)
                {
                    navAgent.destination = target.transform.position;
                }
                break;
            case GiraffeState.EAT:
                if (T1 <= 0)
                {
                    Destroy(target);
                    target = null;
                    state = GiraffeState.WANDER_TARGET;
                }
                break;
        }

        if (T1 > 0f) T1 -= Time.deltaTime;

        if (player != null && player.activeSelf)
        {
            if (T2 > 0f) T2 -= Time.deltaTime;
            else
            {
                navAgent.destination = player.transform.position;

                float newSeekTime = Mathf.Lerp(minSeekTime, maxSeekTime, (Vector3.Distance(transform.position, player.transform.position) - viewDistance) / (maxSeekDistance - viewDistance));
                T2 = newSeekTime;
                state = GiraffeState.WANDER;
            }
        }

        if (T3 > 0f)
        {
            T3 -= Time.deltaTime;
            speed = slowSpeed;
        }
    

        if (target != null && target.CompareTag("Player") && Vector3.Distance(target.transform.position, transform.position) > viewDistance)
        {
            lastTargetPos = target.transform.position;
            target = null;
        }

        if (T4 > 0) T4 -= Time.deltaTime;

        navAgent.speed = speed;

    }

    private void FindTarget()
    {
        //TODO: Change to proper player!
        GameObject leaf = GameObject.FindGameObjectWithTag("Leaf");

        target = leaf != null ? leaf : player != null ? player: null;
        if (player != null && leaf == null)
        {
            RaycastHit hit;
            if (Physics.Raycast(new Vector3(transform.position.x, 0.5f, transform.position.z),
                (new Vector3(player.transform.position.x, 0.5f, player.transform.position.z) - new Vector3(transform.position.x, 0.5f, transform.position.z)).normalized,
                out hit, viewDistance))
            {
                //Debug.Log(hit.transform.gameObject.name);
                if (hit.transform != player.transform)
                {
                    target = null;
                }
            }
            else
            {
                target = null;
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, viewDistance);
        if (player != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + (player.transform.position - transform.position).normalized * 20f);
        }
    }

    public void SetSlowDebuff(float time)
    {
        T3 = time;
    }

    IEnumerator RandomSounds()
    {
        for(;;)
        {
            yield return new WaitForSeconds(10);
            switch (state)
            {
                case GiraffeState.IDLE:
                    sounds.PlayRandom(0, 4);
                    break;
                case GiraffeState.WANDER:
                    sounds.PlayRandom(0, 4);
                    break;
                case GiraffeState.WANDER_TARGET:
                    sounds.PlayRandom(0, 4);
                    break;
                case GiraffeState.NOTICE_TARGET:
                    sounds.PlayRandom(4, 7);
                    break;
                case GiraffeState.TARGET:
                    sounds.PlayRandom(4, 7);
                    break;
            }
        }
    }
}
