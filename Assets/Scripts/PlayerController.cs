using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Loose;
    [SerializeField] float moveSpeed;
    Vector2 moveInput;
    Animator anim;
    public GameObject enemySpawner;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        transform.Translate(moveInput * Time.deltaTime * moveSpeed);

        anim.SetBool("isMoving", (Mathf.Abs(moveInput.x) > 0 || Mathf.Abs(moveInput.y) > 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            YouLost();
        }
    }

    private void YouLost()
    {
        Time.timeScale = 0f;
        Loose.SetActive(true);
    }
}
