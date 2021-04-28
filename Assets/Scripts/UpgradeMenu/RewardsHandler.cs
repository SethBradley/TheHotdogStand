using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardsHandler
{

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
}
