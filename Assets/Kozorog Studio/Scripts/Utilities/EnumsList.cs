﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumsList : MonoBehaviour
{

}

public enum SkinRarity
{
    Common,
    Rare,
    Special,
    VIP
}

public enum TabGroupEnum
{
    Cars,
    Drivers
}

[System.Serializable]
public enum CarType
{
    CCar1,
    CCar2,
    CCar3,
    CCar4,
    CCar5,
    CCar6,
    CCar7,
    CCar8,
    CCar9,
    RCar1,
    RCar2,
    RCar3,
    RCar4,
    RCar5,
    RCar6,
    RCar7,
    RCar8,
    RCar9,
    SCar1,
    SCar2,
    SCar3,
    SCar4,
    SCar5,
    SCar6,
    VCar1,
    VCar2,
    VCar3,
}

[System.Serializable]
public enum DriverType
{
    CDriver1,
    CDriver2,
    CDriver3,
    CDriver4,
    CDriver5,
    CDriver6,
    CDriver7,
    CDriver8,
    CDriver9,
    RDriver1,
    RDriver2,
    RDriver3,
    RDriver4,
    RDriver5,
    RDriver6,
    RDriver7,
    RDriver8,
    RDriver9,
    SDriver1,
    SDriver2,
    SDriver3,
    SDriver4,
    SDriver5,
    SDriver6,
    VDriver1,
    VDriver2,
    VDriver3,
}

public enum PlayerMovementState
{
    NotRacing,
    Racing
}

public enum EnemyMovementState
{
    NotRacing,
    Racing
}

public enum GearChangeSuccess
{
    Waiting,
    Perfect,
    Fail,
    Max
}

public enum RewardVideoType
{
    GoldMultiplier,
    SpecialSkinPoint,
    InterstetialAd,
    ShopGoldReward
}

public enum EnemyTriggerType
{
    ActivateNitro,
    RaiseGear,
    ActivateDodgeLeft,
    ActivateDodgeRight,
    Blockade
}

public enum PlayerNames
{
    Tamrex,
    IHasInsides,
    TamHopefulInsides,
    TamasaurusRex,
    TamBraveCheeks,
    TamItalian,
    UberHopefulOwl,
    DisguisedOwl,
    HopefulInsidesOMG,
    BraveInsidesLOL,
    GingerInsidesOMG,
    HopefulCheeksLOL,
    BraveCheeksOMG,
    GingerCheeksLMAO,
    Iamhopeful,
    Iambrave,
    Iamginger,
    IamTam,
    OwlMilk,
    TamGingerOwl,
    MindOfTam,
    Gamerowl,
    TheHopefulGamer,
    TheBraveGamer,
    TheGingerGamer,
    DrHopeful,
    TamInsidespopper,
    BigHopefulOwl,
    ItIsYeOwl,
    T4m,
    OwlBoy,
    OwlGirl,
    OwlPerson,
    CaptainHopeful,
    IHasCheeks,
    TotalOwl,
    TheHopefulItalianDude,
    TheGamingOwl,
    GamingWithTam,
    MrGameOwl,
    MsGameOwl,
    Christelrex,
    IHasHairs,
    ChristelNobleHairs,
    ChristelasaurusRex,
    ChristelViolentHairs,
    ChristelFrench,
    UberNobleGuppy,
    DisguisedGuppy,
    NobleHairsOMG,
    ViolentHairsLOL,
    BoldHairsOMG,
    NobleHairsLOL,
    ViolentHairsOMG,
    BoldHairsLMAO,
    Iamnoble,
    Iamviolent,
    Iambold,
    IamChristel,
    GuppyMilk,
    ChristelBoldGuppy,
    MindOfChristel,
    Gamerguppy,
    TheNobleGamer,
    TheViolentGamer,
    TheBoldGamer,
    DrNoble,
    ChristelHairspopper,
    BigNobleGuppy,
    ItIsYeGuppy,
    Chr1st3l,
    GuppyBoy,
    GuppyGirl,
    GuppyPerson,
    CaptainNoble,
    TotalGuppy,
    TheNobleFrenchDude,
    TheGamingGuppy,
    GamingWithChristel,
    MrGameGuppy,
    MsGameGuppy,
    Pavlinarex,
    IHasEyebrows,
    PavlinaBrownEyebrows,
    PavlinaasaurusRex,
    PavlinaBraveEars,
    PavlinaGerman,
    UberBrown,
    Disguised,
    BrownEyebrowsOMG,
    BraveEyebrowsLOL,
    WildEyebrowsOMG,
    BrownEarsLOL,
    BraveEarsOMG,
    WildEarsLMAO,
    Iambrown,
    Iamwild,
    IamPavlina,
    Milk,
    PavlinaWild,
    MindOfPavlina,
    Gamer,
    TheBrownGamer,
    TheWildGamer,
    DrBrown,
    PavlinaEyebrowspopper,
    BigBrown,
    ItIsYe,
    P4vl1n4,
    Boy,
    Girl,
    Person,
    CaptainBrown,
    IHasEars,
    Total,
    TheBrownGermanDude,
    TheGaming,
    GamingWithPavlina,
    MrGame,
    MsGame
}

public enum PlayerCountry
{
    Afghanistan,
    Albania,
    Algeria,
    Andorra,
    Angola,
    AntiguaDeps,
    Argentina,
    Armenia,
    Australia,
    Austria,
    Azerbaijan,
    Bahamas,
    Bahrain,
    Bangladesh,
    Barbados,
    Belarus,
    Belgium,
    Belize,
    Benin,
    Bhutan,
    Bolivia,
    BosniaHerzegovina,
    Botswana,
    Brazil,
    Brunei,
    Bulgaria,
    Burkina,
    Burundi,
    Cambodia,
    Cameroon,
    Canada,
    CapeVerde,
    CentralAfricanRep,
    Chad,
    Chile,
    China,
    Colombia,
    Comoros,
    Congo,
    CostaRica,
    Croatia,
    Cuba,
    Cyprus,
    CzechRepublic,
    Denmark,
    Djibouti,
    Dominica,
    DominicanRepublic,
    EastTimor,
    Ecuador,
    Egypt,
    ElSalvador,
    EquatorialGuinea,
    Eritrea,
    Estonia,
    Ethiopia,
    Fiji,
    Finland,
    France,
    Gabon,
    Gambia,
    Georgia,
    Germany,
    Ghana,
    Greece,
    Grenada,
    Guatemala,
    Guinea,
    GuineaBissau,
    Guyana,
    Haiti,
    Honduras,
    Hungary,
    Iceland,
    India,
    Indonesia,
    Iran,
    Iraq,
    Ireland,
    Israel,
    Italy,
    IvoryCoast,
    Jamaica,
    Japan,
    Jordan,
    Kazakhstan,
    Kenya,
    Kiribati,
    KoreaNorth,
    KoreaSouth,
    Kosovo,
    Kuwait,
    Kyrgyzstan,
    Laos,
    Latvia,
    Lebanon,
    Lesotho,
    Liberia,
    Libya,
    Liechtenstein,
    Lithuania,
    Luxembourg,
    Macedonia,
    Madagascar,
    Malawi,
    Malaysia,
    Maldives,
    Mali,
    Malta,
    MarshallIslands,
    Mauritania,
    Mauritius,
    Mexico,
    Micronesia,
    Moldova,
    Monaco,
    Mongolia,
    Montenegro,
    Morocco,
    Mozambique,
    Myanmar,
    Namibia,
    Nauru,
    Nepal,
    Netherlands,
    NewZealand,
    Nicaragua,
    Niger,
    Nigeria,
    Norway,
    Oman,
    Pakistan,
    Palau,
    Panama,
    PapuaNewGuinea,
    Paraguay,
    Peru,
    Philippines,
    Poland,
    Portugal,
    Qatar,
    Romania,
    RussianFederation,
    Rwanda,
    StKittsNevis,
    StLucia,
    SaintVincenttheGrenadines,
    Samoa,
    SanMarino,
    SaoTomePrincipe,
    SaudiArabia,
    Senegal,
    Serbia,
    Seychelles,
    SierraLeone,
    Singapore,
    Slovakia,
    Slovenia,
    SolomonIslands,
    Somalia,
    SouthAfrica,
    SouthSudan,
    Spain,
    SriLanka,
    Sudan,
    Suriname,
    Swaziland,
    Sweden,
    Switzerland,
    Syria,
    Taiwan,
    Tajikistan,
    Tanzania,
    Thailand,
    Togo,
    Tonga,
    TrinidadTobago,
    Tunisia,
    Turkey,
    Turkmenistan,
    Tuvalu,
    Uganda,
    Ukraine,
    UnitedArabEmirates,
    UnitedKingdom,
    UnitedStates,
    Uruguay,
    Uzbekistan,
    Vanuatu,
    VaticanCity,
    Venezuela,
    Vietnam,
    Yemen,
    Zambia,
    Zimbabwe
}

