using UnityEngine;
using System.Collections;

public class esc_cloud_move : MonoBehaviour
{

    public float speed;
    private float xDir;

    void Start()
    {
        xDir = transform.position.x;
        StartCoroutine(SpawnRepeat());
        //코루틴 특정함수 초마다 반복 실행 
    }

    private IEnumerator SpawnRepeat()
    {
        float randYtime = (float)Random.Range(0, 2);
        //0~2초 스폰 랜덤시간 
        //첫 랜덤시간 이후 0~1초의 스폰 랜덤시간을 가짐
        while (true)
        {
            yield return new WaitForSeconds(randYtime);
            SpawnClouds();
            randYtime = (float)Random.Range(0, 1);
        }
    }

    void SpawnClouds()
    {
        xDir -= Time.deltaTime * speed;
        transform.position = new Vector3(xDir, transform.position.y, transform.position.z);
        if (transform.position.x < -28)
        {
            xDir = -3;
            xDir -= Time.deltaTime * speed;
            float randomY = Random.Range(-18, -6);
            transform.position = new Vector3(xDir, randomY, transform.position.z);
            // 구름 x좌표 -9 이하면, xDir x좌표 10, y좌표 (랜덤)0~3 으로 이동
        }
    }
}
