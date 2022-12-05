using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject telaInicial;
    public GameObject Loose;
    public GameObject spawnManager;
    public GameObject gun;
    public GameObject[] enemys;

    public void PlayGame()
    {
        telaInicial.SetActive(false);
        spawnManager.GetComponent<EnemySpawner>().enabled = true;
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void PlayAgain()
    {
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in enemys)
        {
            Destroy(enemy);
        }
        Time.timeScale = 1f;
        Loose.SetActive(false);
    }
}
