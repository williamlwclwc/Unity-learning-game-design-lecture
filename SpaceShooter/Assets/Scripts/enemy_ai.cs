using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_ai : MonoBehaviour {

    public float dodge;     // 躲避
    public float smoothing;
    public float tilt;
    public Vector2 startWait;
    public Vector2 maneuverTime;
    public Vector2 maneuverWait;
    public Boundary boundary;
    public float timer = 1;
    public GameObject shot;
    public Transform shot_pos;
    private float targetManeuver;       // a point on the x axies. So the Enemy will move left or right
    private float currentSpeedZ;        // z方向的当前速度
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeedZ = rb.velocity.z;
        Debug.Log("currentSpeedZ = " + currentSpeedZ);
        StartCoroutine(Evade());
    }

    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y)); // 等候一个随机的时间

        while (true)
        {
            targetManeuver = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);    // 当Enemy在左侧的时候会向右dodge，在右侧的时候向左dodge
            yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));
            targetManeuver = 0;                 // set it back
            yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
        }
    }

    void FixedUpdate()
    {
        float newManeuver = Mathf.MoveTowards(rb.velocity.x, targetManeuver, Time.deltaTime * smoothing);
        rb.velocity = new Vector3(newManeuver, 0.0f, currentSpeedZ);
        // Clamp the position of Enemy
        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );
        // set tilt
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer<=0)
        {
            Instantiate(shot, shot_pos.position, shot_pos.rotation);
            timer = 1;
        }
    }
}
