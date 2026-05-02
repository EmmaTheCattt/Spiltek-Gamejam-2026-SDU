using UnityEngine;
[CreateAssetMenu(menuName = "Purple Guy Movement")]
public class Purple_Guy_Movement_Stats : ScriptableObject
{
    public static Purple_Guy_Movement_Stats Instance { get; set; }
    [Header("Walk")]
    [Range(1f, 100f)] public float maxWalkSpeed = 12.5f;
    [Range(0.25f, 50f)] public float groundAcceleration = 5f;
    [Range(0.25f, 50f)] public float groundDeceleration = 20f;
    [Range(0.25f, 50f)] public float airAcceleration = 5f;
    [Range(0.25f, 50f)] public float airDeceleration = 5f;

    [Header("Jump")]
    public float jumpHeight = 0.8f;
    [Range(1, 5)] public int numberOfJumpsAllowed = 1;


    [Header("Jump Coyote Time")]
    [Range(0f, 1f)] public float jumpCoyoteTime = 0.1f;


    private void OnValidate()
    {
        CalculateValues();
    }
    private void OnEnable()
    {
        CalculateValues();
    }

    void CalculateValues()
    {
    }
}
