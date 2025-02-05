using UnityEngine;

public class Game : MonoBehaviour
{
    private static Game instance;

    public static Game Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Game>();
                if (instance == null)
                {
                    GameObject obj = new GameObject(typeof(Game).Name);
                    instance = obj.AddComponent<Game>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void CharacterDead()
    {
        CharacterMovement characterMovement = FindObjectOfType<CharacterMovement>();
        CameraFollow cameraFollow = FindObjectOfType<CameraFollow>();
        if (characterMovement != null)
        {
            characterMovement.enabled = false;
        }
        cameraFollow.enabled = false;

        UIM.Instance.SetActiveGameoverUI(true);
    }
}