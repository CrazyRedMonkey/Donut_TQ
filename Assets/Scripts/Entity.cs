using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Entity : MonoBehaviour
{
    [SerializeField] private GameObject EndRoundScreen;
    [SerializeField] private Button ButtonContinue;
    [SerializeField] private Text EndRoundLifeText;

    private bool InProgress = false;
    private List<ICharacterMain> enemies;
    private GameObject prefabEnemy;
    private GameObject Player;
    private int Life = 3;
    private int FragCount;
    private float Timer = 0;

    public void ShowEndRound()
    {
        Life--;
        if (Life <= 0)
        {
            ButtonContinue.interactable = false;
            EndRoundLifeText.text = string.Format("игра окончена, колличество убитых юнитов: {0}, затрачено {1} секунд", FragCount, Timer);
        }
        else
        {
            EndRoundLifeText.text = string.Format("осталось {0} жизни, колличество убитых юнитов: {1}, затрачено {2} секунд",Life, FragCount,Timer);
        }
        EndRoundScreen.SetActive(true);
        InProgress = false;
        foreach (var i in enemies)
            Destroy(i.obj);
        enemies.Clear();

    }

    public void RemoveUnit(ICharacterMain obj)
    {
        if (InProgress)
            FragCount++;
        enemies.Remove(obj);
    }

    private void Respawn()
    {
        FragCount = 0;
        EndRoundScreen.SetActive(false);
        Player.GetComponent<ICharacterMain>().Reset();
        Player.SetActive(true);
        InProgress = true;
    }

    private void Update()
    {
        if (InProgress)
            Timer += Time.deltaTime;
    }

    private void Start()
    {
        enemies = new List<ICharacterMain>();
        prefabEnemy = Resources.Load<GameObject>("Enemy");
        ButtonContinue.onClick.AddListener(Respawn);
        Player = GameObject.FindGameObjectWithTag("Player");
        InProgress = true;
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        if (enemies.Count < 10 && InProgress)
        {
            GameObject clone = Instantiate(prefabEnemy, Player.transform.position + Random.onUnitSphere * 20f, Quaternion.identity);
            enemies.Add(clone.GetComponent<ICharacterMain>());
        }
        yield return new WaitForSeconds(5f);
        yield return StartCoroutine(Spawner());
    }
}
