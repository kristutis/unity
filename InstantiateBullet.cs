using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletsForce = 50f;
    public float lifeDuration = 2f;

    private List<GameObject> bullets = new List<GameObject>();
    private List<float> times = new List<float>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject newBullet = Instantiate(bulletPrefab);
            newBullet.transform.position = new Vector3(newBullet.transform.position.x, newBullet.transform.position.y + 2, newBullet.transform.position.z);
            bullets.Add(newBullet);
            times.Add(lifeDuration);
        }
        for (int i = 0; i < bullets.Count; i++)
        {
            var bullet = bullets[i];
            bullet.GetComponent<Rigidbody>().AddForce(new Vector3(bullet.transform.position.x, bullet.transform.position.y, bullet.transform.position.z + bulletsForce));
            times[i] = times[i] -= Time.deltaTime;
            if (times[i] <= 0f)
            {
                Destroy(bullet);
                bullets.RemoveAt(i);
                times.RemoveAt(i);
            }
        }
    }
}
