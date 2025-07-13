using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace MiddleScene
{
    public class PanelSelectingSkin : IPanel
    {
        // 当前选中的角色
        private GameObject selectingPlayer;

        // *selectingPlayer*的皮肤列表
        private List<PlayerSkinType> playerSkins;
        private int curSkinIndex;

        public PanelSelectingSkin(IPanel parent) : base(parent)
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
                EventCenter.Instance.NotifyEvent(EventType.OnSelectSkinComplete);
                panel.SetActive(false);
                EnterPanel<PanelBattle>();
            });

            // 切换上一个皮肤
            UnityTools.Instance.GetComponentFromChildren<Button>(panel, "ButtonLeft").onClick.AddListener(() =>
            {
                curSkinIndex = (curSkinIndex + playerSkins.Count - 1) % playerSkins.Count;
                selectingPlayer.transform.Find("Sprite").GetComponent<Animator>().runtimeAnimatorController =
                ResourcesFactory.Instance.GetPlayerSkin(playerSkins[curSkinIndex].ToString());
            });

            //切换下一个皮肤
            UnityTools.Instance.GetComponentFromChildren<Button>(panel, "ButtonRight").onClick.AddListener(() =>
            {
                curSkinIndex = (curSkinIndex + 1) % playerSkins.Count;
                selectingPlayer.transform.Find("Sprite").GetComponent<Animator>().runtimeAnimatorController =
                ResourcesFactory.Instance.GetPlayerSkin(playerSkins[curSkinIndex].ToString());
                // GameMediator.Instance.GetController<PlayerController>().SetMainPlayerSkin(Enum.Parse<PlayerSkinType>(skinName));
            });

            EventCenter.Instance.RigisterEvent(EventType.OnSelectSkinComplete, false, () =>
            {
                panel.SetActive(false);
            });
        }

        protected override void OnEnter()
        {
            base.OnEnter();
        }

        public void SetSelectingPlayer(GameObject selectingPlayer)
        {
            this.selectingPlayer = selectingPlayer;

            // 同时获取该角色的皮肤
            playerSkins = PlayerCommand.Instance.GetPlayerSkinStaticTypes(Enum.Parse<PlayerType>(selectingPlayer.name));
        }
    }
}