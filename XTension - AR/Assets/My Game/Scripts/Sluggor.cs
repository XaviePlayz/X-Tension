using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Sluggor : MonoBehaviour
{
    public Timer time;
    public RandomLevelGenerator rndLevel;

    private Animator anim;
    public NavMeshAgent creature;
    public Transform Player;

    public GameObject thePlayer;

    public GameObject jumpCam1;
    public GameObject jumpCam2;
    public GameObject jumpCam3;

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject GameOverScreenText;
    public GameObject EnemyGenerator;
    public GameObject Timer;

    public float health;
    public bool isAttacking;
    public bool playedScare;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        if (Vector3.Distance(Player.position, this.transform.position) < 80)
        {
            Vector3 direction = Player.position - this.transform.position;
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
            anim.SetBool("isIdle", false);
            if (direction.magnitude > 2)
            {
                this.transform.Translate(0, 0, 0.05f);
                anim.SetBool("isWalking", true);
                anim.SetBool("isAttacking", false);
            }
            else
            {
                if (playedScare == false)
                {
                    playedScare = true;
                    GetComponent<AudioSource>().Play();

                    Timer.SetActive(false);
                    EnemyGenerator.SetActive(false);
                    anim.SetBool("isWalking", false);
                    anim.SetBool("isAttacking", true);
                    if (rndLevel.generator == 1)
                    {
                        rndLevel.Level1.SetActive(false);
                        jumpCam1.SetActive(true);
                        enemy1.SetActive(true);
                    }
                    else if (rndLevel.generator == 2)
                    {
                        rndLevel.Level2.SetActive(false);
                        jumpCam2.SetActive(true);
                        enemy2.SetActive(true);
                    }
                    else if (rndLevel.generator == 3)
                    {
                        rndLevel.Level3.SetActive(false);
                        jumpCam3.SetActive(true);
                        enemy3.SetActive(true);
                    }
                    thePlayer.SetActive(false);
                    StartCoroutine(GameOver());
                }               
            }
        }
        if (time.timeValue < 1)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        anim.SetBool("isAttacking", false);
        anim.SetBool("isDying", true);
        isAttacking = true;
        health -= damage;
        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2f);
        GameOverScreenText.SetActive(true);
        thePlayer.SetActive(false);
        enemy1.SetActive(false);
        enemy2.SetActive(false);
        enemy3.SetActive(false);
    }
}
