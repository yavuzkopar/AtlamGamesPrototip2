using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public UnityEvent finalMoment;
    public UnityEvent failMoment;
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] GameObject jStick;

    
    public Transform finalpoints;

    private static GameManager instance;

    public static GameManager Instance { get { return instance; } }
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
