using System.Diagnostics;

public class CommonLog
{
    [Conditional("ALL_LOG")]
    public static void LogInfo(string message)
    {
#if ALL_LOG
        UnityEngine.Debug.Log(message);
#endif
    }

    [Conditional("ALL_LOG")]
    public static void LogError(string message)
    {
#if ALL_LOG
        UnityEngine.Debug.LogError(message);
#endif
    }

}
