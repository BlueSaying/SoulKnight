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

            selectingPlayer = GameMediator.Instance.GetSystem<PlayerSystem>().playerGameObject;
            // 同时获取该角色的皮肤
            playerSkins = PlayerCommand.Instance.GetPlayerSkinTypes(Enum.Parse<PlayerType>(selectingPlayer.name));

            // 返回
            UnityTools.Instance.GetComponentFromChildren<Button>(gameObject, "ButtonBack").onClick.AddListener(() =>
            {
                UIMediator.Instance.OpenPanel(PanelName.SelectingPlayerPanel.ToString());
                UIMediator.Instance.ClosePanel(PanelName.SelectingSkinPanel.ToString());
            });

            // 下一步
            UnityTools.Instance.GetComponentFromChildren<Button>(gameObject, "ButtonNext").onClick.AddListener(() =>
            {
                EventCenter.Instance.NotifyEvent(EventType.OnSelectSkinComplete);// TODO:读取数据填写UI

                // 解除冻结位置，即仅设置冻结旋转
                UIMediator.Instance.OpenPanel(PanelName.BattlePanel.ToString());
                UIMediator.Instance.ClosePanel(PanelName.SelectingSkinPanel.ToString());

                // HACK
                WeaponFactory.Instance.InstantiatePlayerWeapon(PlayerWeaponType.Ak47, new Vector2(5, 0), Quaternion.identity);
                WeaponFactory.Instance.InstantiatePlayerWeapon(PlayerWeaponType.BadPistol, new Vector2(3, 0), Quaternion.identity);

                GameMediator.Instance.GetSystem<EnemySystem>().AddEnemy(EnemyType.Stake, Vector2.zero, Quaternion.identity);
            });

            // 切换上一个皮肤
            UnityTools.Instance.GetComponentFromChildren<Button>(gameObject, "ButtonLeft").onClick.AddListener(() =>
            {
                curSkinIndex = (curSkinIndex + playerSkins.Count - 1) % playerSkins.Count;
                selectingPlayer.transform.Find("Sprite").GetComponent<Animator>().runtimeAnimatorController =
                    ResourcesLoader.Instance.GetPlayerSkin(playerSkins[curSkinIndex].ToString());
            });

            //切换下一个皮肤
            UnityTools.Instance.GetComponentFromChildren<Button>(gameObject, "ButtonRight").onClick.AddListener(() =>
            {
                curSkinIndex = (curSkinIndex + 1) % playerSkins.Count;
                selectingPlayer.transform.Find("Sprite").GetComponent<Animator>().runtimeAnimatorController =
                    ResourcesLoader.Instance.GetPlayerSkin(playerSkins[curSkinIndex].ToString());
            });
        }
    }
}