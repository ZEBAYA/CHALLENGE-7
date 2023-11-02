using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField]
    public List<TextMeshProUGUI> names;

    [SerializeField]
    public List<TextMeshProUGUI> scores;
    private string publicLeaderboardKey = "ffc1bfa57937921b62340157c0f27c13eeb3271e809be9d214d5e9209c92b4a8";
    private void Start()
    {
        GetLeaderboard();
    }
    public void GetLeaderboard()
    {
        LeaderboardCreator.GetLeaderboard(publicLeaderboardKey, ((msg) => {

            for (int i = 0; i < names.Count; ++i)
            {

                int loopLength = (msg.Length > names.Count) ? msg.Length : names.Count;
                names[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();
            }
        }));
    }
    public void SetLeaderboardEntry(string Username, int score)
    {
        LeaderboardCreator.UploadNewEntry(publicLeaderboardKey, Username, score, ((msg) => {
            Username.Substring(0, 5);
            GetLeaderboard();
        }));
    }
}