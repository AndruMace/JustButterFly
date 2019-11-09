using UnityEngine;
// using UnityEngine.Monetization;
using UnityEngine.Advertisements;

public class AdController : MonoBehaviour
{
    public static AdController instance;

    private string store_ID = "3350109";

    private string banner_ID = "retryScreenBannerAd"; 
    private string video_ID = "video"; 

    void Awake(){
        if (instance != null)
        {
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        Advertisement.Initialize (store_ID, false);
    }

    public void showVideoAd()
    {
        Advertisement.Show();
    }

    public void showBannerAd()
    {
        Advertisement.Banner.Show(banner_ID);
        Advertisement.Banner.SetPosition (BannerPosition.BOTTOM_CENTER);
    }
}
