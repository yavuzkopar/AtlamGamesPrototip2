using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public UnityEvent finalMoment;
    public UnityEvent failMoment;
    public int brickGoal;
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] GameObject jStick;

    public static GameManager instance;
    public Transform finalpoints;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        Invoke(nameof(SetCamera), 3f);
    }
    void SetCamera()
    {
        virtualCamera.Priority = 12;
        jStick.SetActive(true);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
