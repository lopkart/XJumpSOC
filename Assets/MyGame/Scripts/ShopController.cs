using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopController : MonoBehaviour {


    private int availableCoins;

    // SKINS
    public Material PlayerBlueLinear;
    public Material PlayerYellowLinear;
    public Material PlayerGreenLinear;

    public Material PlayerBlueLinear45;
    public Material PlayerYellowLinear45;
    public Material PlayerGreenLinear45;

    public Material PlayerBlueRadial;
    public Material PlayerYellowRadial;
    public Material PlayerGreenRadial;

    public Material PlayerBlueDiamond;
    public Material PlayerYellowDiamond;
    public Material PlayerGreenDiamond;

    private static bool ClickedSkin1 = false;
    private static bool ClickedSkin2 = false;
    private static bool ClickedSkin3 = false;
    private static bool ClickedSkin4 = false;

    private static string skin1StaticText = "2 COINS";
    private static string skin2StaticText = "4 COINS";
    private static string skin3StaticText = "6 COINS";
    private static string skin4StaticText = "8 COINS";

    public TextMeshProUGUI skin1Text;
    public TextMeshProUGUI skin2Text;
    public TextMeshProUGUI skin3Text;
    public TextMeshProUGUI skin4Text;


    // FEATURES
    private static bool ClickedFeature1 = false;
    private static bool ClickedFeature2 = false;
    private static bool ClickedFeature3 = false;
    private static bool ClickedFeature4 = false;

    private static string feature1StaticText = "4 COINS";
    private static string feature2StaticText = "7 COINS";
    private static string feature3StaticText = "10 COINS";
    private static string feature4StaticText = "13 COINS";

    public TextMeshProUGUI feature1Text;
    public TextMeshProUGUI feature2Text;
    public TextMeshProUGUI feature3Text;
    public TextMeshProUGUI feature4Text;

    public static float PlayerGravityScale = 1f;
    public static float destroyLineStaticTime = 5f;



    public void buySkin1()
    {
        if (ClickedSkin1)
        {
            PlayerAbility.PlayerBlueSkin = PlayerBlueLinear;
            PlayerAbility.PlayerYellowSkin = PlayerYellowLinear;
            PlayerAbility.PlayerGreenSkin = PlayerGreenLinear;
        }

        if (availableCoins >= 2 && !ClickedSkin1)
        {            
            PlayerAbility.PlayerBlueSkin = PlayerBlueLinear;
            PlayerAbility.PlayerYellowSkin = PlayerYellowLinear;
            PlayerAbility.PlayerGreenSkin = PlayerGreenLinear;

            PlayerController.coins -= 2;
            ClickedSkin1 = true;
            skin1StaticText = "BOUGHT";
        }        
    }

    public void buySkin2()
    {
        if (ClickedSkin2)
        {
            PlayerAbility.PlayerBlueSkin = PlayerBlueLinear45;
            PlayerAbility.PlayerYellowSkin = PlayerYellowLinear45;
            PlayerAbility.PlayerGreenSkin = PlayerGreenLinear45;
        }

        if (availableCoins >= 4 && !ClickedSkin2)
        {
            PlayerAbility.PlayerBlueSkin = PlayerBlueLinear45;
            PlayerAbility.PlayerYellowSkin = PlayerYellowLinear45;
            PlayerAbility.PlayerGreenSkin = PlayerGreenLinear45;

            PlayerController.coins -= 4;
            ClickedSkin2 = true;
            skin2StaticText = "BOUGHT";
        }        
    }

    public void buySkin3()
    {
        if (ClickedSkin3)
        {
            PlayerAbility.PlayerBlueSkin = PlayerBlueRadial;
            PlayerAbility.PlayerYellowSkin = PlayerYellowRadial;
            PlayerAbility.PlayerGreenSkin = PlayerGreenRadial;
        }

        if (availableCoins >= 6 && !ClickedSkin3)
        {
            PlayerAbility.PlayerBlueSkin = PlayerBlueRadial;
            PlayerAbility.PlayerYellowSkin = PlayerYellowRadial;
            PlayerAbility.PlayerGreenSkin = PlayerGreenRadial;

            PlayerController.coins -= 6;
            ClickedSkin3 = true;
            skin3StaticText = "BOUGHT";
        }        
    }

    public void buySkin4()
    {
        if (ClickedSkin3)
        {
            PlayerAbility.PlayerBlueSkin = PlayerBlueDiamond;
            PlayerAbility.PlayerYellowSkin = PlayerYellowDiamond;
            PlayerAbility.PlayerGreenSkin = PlayerGreenDiamond;
        }

        if (availableCoins >= 8 && !ClickedSkin4)
        {
            PlayerAbility.PlayerBlueSkin = PlayerBlueDiamond;
            PlayerAbility.PlayerYellowSkin = PlayerYellowDiamond;
            PlayerAbility.PlayerGreenSkin = PlayerGreenDiamond;

            PlayerController.coins -= 8;
            ClickedSkin4 = true;
            skin4StaticText = "BOUGHT";
        }        
    }


    void Start()
    {
        availableCoins = PlayerController.coins;       
    }

    private void Update()
    {
        availableCoins = PlayerController.coins;

        skin1Text.text = skin1StaticText;
        skin2Text.text = skin2StaticText;
        skin3Text.text = skin3StaticText;
        skin4Text.text = skin4StaticText;

        feature1Text.text = feature1StaticText;
        feature2Text.text = feature2StaticText;
        feature3Text.text = feature3StaticText;
        feature4Text.text = feature4StaticText;       
    }

    


    public void buyFeature1()
    {
        if (ClickedFeature1)
        {
            PlayerController.moveSpeed = 20f;
        }

        if (availableCoins >= 4 && !ClickedFeature1)
        {
            PlayerController.moveSpeed = 20f;

            PlayerController.coins -= 4;
            ClickedFeature1 = true;
            feature1StaticText = "BOUGHT";
        }
    }

    public void buyFeature2()
    {
        if (ClickedFeature2)
        {
            PlayerController.JumpVelocity = 20f;
        }

        if (availableCoins >= 4 && !ClickedFeature2)
        {
            PlayerController.JumpVelocity = 20f;

            PlayerController.coins -= 4;
            ClickedFeature2 = true;
            feature2StaticText = "BOUGHT";
        }
    }

    public void buyFeature3()
    {
        if (ClickedFeature3)
        {
            PlayerGravityScale = 0.05f;
        }

        if (availableCoins >= 10 && !ClickedFeature3)
        {
            PlayerGravityScale = 0.05f;

            PlayerController.coins -= 10;
            ClickedFeature3 = true;
            feature3StaticText = "BOUGHT";
        }
    }

    public void buyFeature4()
    {
        if (ClickedFeature4)
        {
            destroyLineStaticTime = 9f;
        }

        if (availableCoins >= 13 && !ClickedFeature4)
        {
            destroyLineStaticTime = 9f;

            PlayerController.coins -= 13;
            ClickedFeature4 = true;
            feature4StaticText = "BOUGHT";
        }
    }
}
