using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MiddleScene
{
    public class SelectingSkinPanel : Panel
    {
        // 当前选中的角色
        private GameObject selectingPlayer;

        // *selectingPlayer*的皮肤列表
        private List<PlayerSkinType> playerSkins;
        private int curSkinIndex;

        protected override void Awake()
        {
            base.Awake();

            selectingPlayer = SystemRepository.Instance.GetSystem<PlayerSystem>().playerGameObject;
            // 同时获取该角色的皮肤
            playerSkins = SystemRepository.Instance.GetSystem<PlayerSystem>().
                GetPlayerSkinModel(Enum.Parse<PlayerType>(selectingPlayer.name)).staticAttr.playerSkinTypes;

            // 返回
            UnityTools.Instance.GetComponentFromChildren<Button>(gameObject, "ButtonBack").onClick.AddListener(() =>
            {
                UIMediator.Instance.OpenPanel(SceneName.MiddleScene, PanelName.SelectingPlayerPanel.ToString());
                UIMediator.Instance.ClosePanel(PanelName.SelectingSkinPanel.ToString());
            });

            // 下一步
            UnityTools.Instance.GetComponentFromChildren<Button>(gameObject, "ButtonNext").onClick.AddListener(() =>
            {
                // 保存皮肤
                SystemRepository.Instance.GetSystem<PlayerSystem>().SetMainPlayerSkin(playerSkins[curSkinIndex]);

                EventCenter.Instance.NotifyEvent(EventType.OnSelectSkinComplete);// TODO:读取数据填写UI

                // 解除冻结位置，即仅设置冻结旋转
                UIMediator.Instance.OpenPanel(SceneName.MiddleScene, PanelName.BattlePanel.ToString());
                UIMediator.Instance.ClosePanel(PanelName.SelectingSkinPanel.ToString());
                UIMediator.Instance.ClosePanel(PanelName.GemPanel.ToString());

                // HACK
                WeaponFactory.InstantiateWeapon(WeaponType.AK47, new Vector2(3, 0), Quaternion.identity);
                WeaponFactory.InstantiateWeapon(WeaponType.BadPistol, new Vector2(5, 0), Quaternion.identity);
                WeaponFactory.InstantiateWeapon(WeaponType.GoblinSpear, new Vector2(7, 0), Quaternion.identity);
                WeaponFactory.InstantiateWeapon(WeaponType.Basketball, new Vector2(9, 0), Quaternion.identity);
                WeaponFactory.InstantiateWeapon(WeaponType.GatlingGun, new Vector2(3, 2), Quaternion.identity);
                WeaponFactory.InstantiateWeapon(WeaponType.P250Pistol, new Vector2(5, 2), Quaternion.identity);
                WeaponFactory.InstantiateWeapon(WeaponType.DesertEagle, new Vector2(7, 2), Quaternion.identity);
                WeaponFactory.InstantiateWeapon(WeaponType.StrongBow, new Vector2(9, 2), Quaternion.identity);

                SystemRepository.Instance.GetSystem<EnemySystem>().AddEnemy(EnemyType.Stake, Vector2.zero, Quaternion.identity, null);
            });

            // 切换上一个皮肤
            UnityTools.Instance.GetComponentFromChildren<Button>(gameObject, "ButtonLeft").onClick.AddListener(() =>
            {
                curSkinIndex = (curSkinIndex + playerSkins.Count - 1) % playerSkins.Count;
                selectingPlayer.transform.Find("Sprite").GetComponent<Animator>().runtimeAnimatorController =
                    ResourcesLoader.Instance.LoadPlayerSkin(playerSkins[curSkinIndex].ToString());
            });

            //切换下一个皮肤
            UnityTools.Instance.GetComponentFromChildren<Button>(gameObject, "ButtonRight").onClick.AddListener(() =>
            {
                curSkinIndex = (curSkinIndex + 1) % playerSkins.Count;
                selectingPlayer.transform.Find("Sprite").GetComponent<Animator>().runtimeAnimatorController =
                    ResourcesLoader.Instance.LoadPlayerSkin(playerSkins[curSkinIndex].ToString());
            });
        }
    }
}