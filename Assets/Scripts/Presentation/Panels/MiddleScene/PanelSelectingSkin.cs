using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace MiddleScene
{
    public class PanelSelectingSkin : Panel
    {
        // 当前选中的角色
        private GameObject selectingPlayer;

        // *selectingPlayer*的皮肤列表
        private List<PlayerSkinType> playerSkins;
        private int curSkinIndex;

        public PanelSelectingSkin(Panel parent) : base(parent)
        {
            children.Add(new PanelBattle(this));
        }

        protected override void OnInit()
        {
            base.OnInit();

            // 返回上级菜单
            UnityTools.Instance.GetComponentFromChildren<Button>(panel, "ButtonBack").onClick.AddListener(() =>
            {
                OnExit();
            });

            // 下一步
            UnityTools.Instance.GetComponentFromChildren<Button>(panel, "ButtonNext").onClick.AddListener(() =>
            {
                EventCenter.Instance.NotifyEvent(EventType.OnSelectSkinComplete);// TODO:读取数据填写UI
            });

            // 切换上一个皮肤
            UnityTools.Instance.GetComponentFromChildren<Button>(panel, "ButtonLeft").onClick.AddListener(() =>
            {
                curSkinIndex = (curSkinIndex + playerSkins.Count - 1) % playerSkins.Count;
                selectingPlayer.transform.Find("Sprite").GetComponent<Animator>().runtimeAnimatorController =
                ResourcesLoader.Instance.GetPlayerSkin(playerSkins[curSkinIndex].ToString());
            });

            //切换下一个皮肤
            UnityTools.Instance.GetComponentFromChildren<Button>(panel, "ButtonRight").onClick.AddListener(() =>
            {
                curSkinIndex = (curSkinIndex + 1) % playerSkins.Count;
                selectingPlayer.transform.Find("Sprite").GetComponent<Animator>().runtimeAnimatorController =
                ResourcesLoader.Instance.GetPlayerSkin(playerSkins[curSkinIndex].ToString());
            });

            EventCenter.Instance.RigisterEvent(EventType.OnSelectSkinComplete, false, () =>
            {
                // 解除冻结位置，即仅设置冻结旋转
                GameMediator.Instance.GetSystem<PlayerSystem>().SetMainPlayer(Enum.Parse<PlayerType>(selectingPlayer.name));
                GameMediator.Instance.GetSystem<PlayerSystem>().mainPlayer.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                
                EnterPanel<PanelBattle>();
                panel.SetActive(false);

                // HACK
                WeaponFactory.Instance.InstantiatePlayerWeapon(PlayerWeaponType.Ak47, new Vector2(5, 0), Quaternion.identity);
                WeaponFactory.Instance.InstantiatePlayerWeapon(PlayerWeaponType.BadPistol, new Vector2(3,0), Quaternion.identity);

                GameMediator.Instance.GetSystem<EnemySystem>().AddEnemy(EnemyType.Stake, Vector2.zero, Quaternion.identity);
            });
        }

        public void SetSelectingPlayer(GameObject selectingPlayer)
        {
            this.selectingPlayer = selectingPlayer;

            // 同时获取该角色的皮肤
            playerSkins = PlayerCommand.Instance.GetPlayerSkinTypes(Enum.Parse<PlayerType>(selectingPlayer.name));
        }
    }
}