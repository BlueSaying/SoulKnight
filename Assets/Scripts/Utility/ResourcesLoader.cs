using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// 专门用来管理从Resources文件加载东西的类
public class ResourcesLoader : Singleton<ResourcesLoader>
{
    private ResourcesLoader()
    {
        weaponDic = new Dictionary<string, GameObject>();
        bulletDic = new Dictionary<string, GameObject>();
        playerDic = new Dictionary<string, GameObject>();
        enemyDic = new Dictionary<string, GameObject>();
        effectDic = new Dictionary<string, GameObject>();
        panelDic = new Dictionary<string, GameObject>();
    }

    // 武器
    private Dictionary<string, GameObject> weaponDic;
    private string weaponPath = "Prefabs/Weapons/";

    // 子弹
    private Dictionary<string, GameObject> bulletDic;
    private string bulletPath = "Prefabs/Bullets/";

    // 玩家
    private Dictionary<string, GameObject> playerDic;
    private string playerPath = "Prefabs/Player";

    // 敌人
    private Dictionary<string, GameObject> enemyDic;
    private string enemyPath = "Prefabs/Enemies/";

    // 特效
    private Dictionary<string, GameObject> effectDic;
    private string effectPath = "Prefabs/Effects/";

    // UI
    private Dictionary<string, GameObject> panelDic;
    private string panelPath = "Prefabs/Panels/";

    // 音效
    private string audioPath = "Audios/";

    // 宠物
    private string petPath = "Prefabs/Pets/";

    // 角色皮肤
    private string playerSkinPath = "Animatior/Characters/Players/";

    // 关卡房间
    private string levelRoomPath = "Prefabs/Rooms/";

    public GameObject LoadWeapon(string weaponName)
    {
        if (weaponDic.ContainsKey(weaponName)) return weaponDic[weaponName];

        // NOTE:此处可优化，因为每次都要遍历整个文件
        GameObject newWeapon = Resources.LoadAll<GameObject>(weaponPath).Where(x => x.name == weaponName).ToArray()[0];
        weaponDic.Add(weaponName, newWeapon);
        return newWeapon;
    }

    public GameObject LoadBullet(string bulletName)
    {
        if (bulletDic.ContainsKey(bulletName)) return bulletDic[bulletName];

        GameObject newBullet = Resources.LoadAll<GameObject>(bulletPath).Where(x => x.name == bulletName).ToArray()[0];
        bulletDic.Add(bulletName, newBullet);
        return newBullet;
    }

    public GameObject LoadPlayer(string playerName)
    {
        if (playerDic.ContainsKey(playerName)) return playerDic[playerName];

        GameObject newPlayer = Resources.LoadAll<GameObject>(playerPath).Where(x => x.name == playerName).ToArray()[0];
        playerDic.Add(playerName, newPlayer);
        return newPlayer;
    }

    public GameObject LoadEnemy(string enemyName)
    {
        if (enemyDic.ContainsKey(enemyName)) return enemyDic[enemyName];

        GameObject newEnemy = Resources.LoadAll<GameObject>(enemyPath).Where(x => x.name == enemyName).ToArray()[0];
        enemyDic.Add(enemyName, newEnemy);
        return newEnemy;
    }

    public GameObject LoadEffect(string effectName)
    {
        if (effectDic.ContainsKey(effectName)) return effectDic[effectName];

        GameObject newEffect = Resources.LoadAll<GameObject>(effectPath).Where(x => x.name == effectName).ToArray()[0];
        effectDic.Add(effectName, newEffect);
        return newEffect;
    }

    public GameObject LoadPanel(string sceneName, string panelName)
    {
        if (panelDic.ContainsKey(panelName)) return panelDic[panelName];

        GameObject newPanel = Resources.LoadAll<GameObject>(panelPath).Where(x => x.name == panelName).ToArray()[0];
        panelDic.Add(panelName, newPanel);
        return newPanel;
    }

    public AudioClip LoadAudioClip(string audioType, string audioName)
    {
        return Resources.LoadAll<AudioClip>(audioPath + audioType).Where(x => x.name == audioName).ToArray()[0];
    }

    public GameObject LoadPet(string petName)
    {
        return Resources.LoadAll<GameObject>(petPath).Where(x => x.name == petName).ToArray()[0];
    }

    public RuntimeAnimatorController LoadPlayerSkin(string playerSkinName)
    {
        return Resources.LoadAll<RuntimeAnimatorController>(playerSkinPath + playerSkinName).Where(x => x.name == playerSkinName).ToArray()[0];
    }

    public GameObject LoadLevelRoom(string levelName, string roomName)
    {
        return Resources.LoadAll<GameObject>(levelRoomPath + levelName).Where(x => x.name == roomName).ToArray()[0];
    }


}