using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardsHandler : MonoBehaviour
{
    private Page3 page3Handler;
    private void Awake() 
    {
        page3Handler = GetComponent<Page3>();    
    }

    public void GiveReward(int rewardIndex)
    {
        SaveData.current.achievementRewardClaimedArray[rewardIndex] = true;

        switch (rewardIndex)
        {
            case 0:
                Reward_YourFirstSale();
                break;

            case 1:
                Reward_DogDisher();
                break;

            case 4:
                Reward_ThatsInteresting();
                break;

            case 5:
                Reward_SeeingRed();
                break;

            case 6:
                Reward_ASharpTaste();
                break;

            default:
                break;
        }
    }

    private void Reward_DogDisher()
    {
        
    }

    public void Reward_YourFirstSale()
    {
        //Play noises / anims
        SaveData.current.totalMoney += 5f;
    }

    public void Reward_ThatsInteresting()
    {
        page3Handler.UnlockSpicyMayo();
    }

    public void Reward_SeeingRed()
    {
        page3Handler.UnlockDuckfatKetchup();
    }

    public void Reward_ASharpTaste()
    {
        page3Handler.UnlockDijonMustard();
    }
}
