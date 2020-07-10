
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI current;
    [SerializeField]
    private TextMeshProUGUI record;
    public static int currentCount;
    public static int recordCount;
    private void Start()
    {
        currentCount = 0;
        SaveLoad.LoadFile();
    }
    private void Update()
    {
        current.SetText(currentCount.ToString());
        record.SetText(recordCount.ToString());
        if (recordCount < currentCount)
        {
            recordCount = currentCount;
        }
        SaveLoad.SaveFile();
    }
    public void Restart()
    {
        //  isEndGame = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
