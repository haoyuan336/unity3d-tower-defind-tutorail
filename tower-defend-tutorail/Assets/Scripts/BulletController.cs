using UnityEngine;
class BulletController : MonoBehaviour
{
    public GameObject bulletPrefab;
    private ObjectPool bulletPool = new ObjectPool();
    void Start()
    {
        for (int i = 0; i < 10; i ++) {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.parent = transform;
            bulletPool.RecoverObject(bullet);
        }
        Global.GetInstance().SetBulletController(this);
    }
    public void CreateOneBullet(Vector3 startPos, GameObject targetObj)
    {
        Debug.Log("制造一颗子弹");
        GameObject bullet = bulletPool.GetObject();
        if (bullet == null) {
            bullet = Instantiate(bulletPrefab);
        }
        bullet.SetActive(true);
        bullet.transform.position = startPos;
        bullet.transform.GetComponent<Bullet>().InitWithData(targetObj, bulletPool);
       
    }
}
