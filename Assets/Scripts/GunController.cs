using UnityEngine;

public class GunController : MonoBehaviour
{
    SpriteRenderer sprite;

    AudioSource _audio;

    public GameObject bullet;
    public Transform spawnBullet;

    public GameObject menuInicial;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        _audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        Aim();
        Shoot();
    }

    void Shoot()
    {
        if (menuInicial.activeSelf)
        {
            return;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, spawnBullet.position, transform.rotation);
            _audio.Play();
        }
    }

    void Aim()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);

        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);

        sprite.flipY = (mousePos.x < screenPoint.x);
    }
}
