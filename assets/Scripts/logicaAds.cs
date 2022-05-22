using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class logicaAds : MonoBehaviour
{
    public BannerView bannerAd;
    public InterstitialAd interstitialAd;
    public RewardBasedVideoAd rewardAd;
    [SerializeField] private string appID = "";
    [SerializeField] private string bannerID = "";
    [SerializeField] private string interstitialID = "";
    [SerializeField] private string rewardID = "";

    public static logicaAds anuncios;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        MobileAds.Initialize(appID);
                pedirinterstitial();
        anuncios = this;

        //pedirreward();
    }

    public void pedirBanner()
    {
        Debug.Log("soy banner");
        bannerAd = new BannerView(bannerID, AdSize.Banner, AdPosition.Bottom);
        AdRequest pedir = new AdRequest.Builder().Build();
        bannerAd.LoadAd(pedir);
        
    }

    public void pedirinterstitial()
    {
        
  
        interstitialAd = new InterstitialAd(interstitialID);
        AdRequest pedir = new AdRequest.Builder().Build();
        interstitialAd.LoadAd(pedir);
        
    }

    public void pedirreward()
    {
        rewardAd = RewardBasedVideoAd.Instance;
        AdRequest pedir = new AdRequest.Builder().Build();
        rewardAd.LoadAd(pedir,rewardID);
    }

    public void muestraint() 
    {
        interstitialAd.Show();
        interstitialAd.Destroy();
        pedirinterstitial();
    }

    public void muestrarew()
    {
        rewardAd.Show();
        // pedirreward();
        estado.comoEstoy.jugando();
        Avion.datosAvion.quitar = Avion.datosAvion.quitar + 1;
        Avion.datosAvion.largoBarraV = Avion.datosAvion.largoBarraV + .1f;
    }


}
