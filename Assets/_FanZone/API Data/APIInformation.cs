using UnityEngine;

[CreateAssetMenu(fileName = "API Data", menuName = "API/Data")]
public class APIInformation : ScriptableObject
{
    public bool testing = false;

    [Header (" API Auth")]
    public string AuthToken;
    public string AcceptToken;

    [Header (" API URL")]
    public string GetImageURL;
    public string GetUserURL;
    public string GetUserURL_Static;

    public int test;
}
