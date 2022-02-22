using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api; ///Para referenciar las librerias de Admob
using System.ComponentModel;
using System;
using UnityEngine.Audio;

///Para evitar errores de EventArgs

public class RewardedAds : MonoBehaviour
{
    private RewardedAd rewardedAd;
    private string rewardAdID = "ca-app-pub-3940256099942544/5224354917"; //TODO: cambiar esto

    [SerializeField] private AudioMixerSnapshot adSnp;
    [SerializeField] private Canvas pauseCanvas;
    

    void Start()
    {
        //MobileAds.Initialize(initStatus => { });

        rewardedAd = new RewardedAd(rewardAdID);

        rewardedAd.OnAdLoaded += HandleRewardedAdLoaded; ///Evento cuando carga el anuncio
        rewardedAd.OnAdOpening += HandleRewardedAdOpening; ///Evento cuando es abierto
        rewardedAd.OnAdClosed += HandleRewardedAdClosed; ///Evento cuando es cerrado
        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward; ///Evento cuando es visto por el usuario completamente y se entrega la recompensa
    }

    public void RequestRewardedAd() ///Codigo para cargarlo (No para mostrarlo) 
    {
        AdRequest request = new AdRequest.Builder().Build();

        rewardedAd.LoadAd(request);
    }

    public void ShowRewardedAd() ///Para mostrarlo, debe haber sido previamente Cargado
    {
        RequestRewardedAd();
        
        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
        }
        else
        {
            Debug.LogError("Reward ad not loaded");
        }
    }
    public void HandleRewardedAdLoaded(object sender, EventArgs args) ///Cargado
    {
        
    }


    public void HandleRewardedAdOpening(object sender, EventArgs args) ///Abierto
    {
        adSnp.TransitionTo(0.0f);
    }


    public void HandleRewardedAdClosed(object sender, EventArgs args) ///Cerrado
    {
        
    }

    public void HandleUserEarnedReward(object sender, Reward args) ///Visto completo (Entregar Recompensa)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print($"HandleRewardedAdRewarded event received for {amount.ToString()} {type}");
        
        LvlManager.SharedInstance.LoadNextLevel();
        pauseCanvas.gameObject.SetActive(false);
    }
}


