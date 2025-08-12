using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenuScene
{
    public class KeyBoardPanel : Panel
    {
        // 当前选中的按键事件
        private Transform selectingKeyDescription = null;

        private Dictionary<KeyInputType, KeyCode> inputDic = SystemRepository.Instance.GetSystem<InputSystem>().inputDic;

        protected override void Awake()
        {
            base.Awake();

            InitUI();
        }

        private void InitUI()
        {
            // 为所有按键添加点击事件
            transform.Find("ButtonBack").GetComponent<Button>().onClick.AddListener(() =>
            {
                UIMediator.Instance.ClosePanel(PanelName.KeyBoardPanel.ToString());
            });

            transform.Find("ButtonSetDefault").GetComponent<Button>().onClick.AddListener(() =>
            {
                selectingKeyDescription = null;
                SystemRepository.Instance.GetSystem<InputSystem>().SetDefault();
                InactivateAllKeys();
                ActivateKey();
                RenderLine();

                // 取消所有红框
                foreach (var keyInputType in inputDic.Keys)
                {
                    transform.Find("KeyDescriptions").Find(keyInputType.ToString()).Find("SelectBounds").gameObject.SetActive(false);
                }
            });

            // 给所有Keys添加事件
            foreach (Transform trans in transform.Find("Keys"))
            {
                trans.Find("Inactive").GetComponent<Button>().onClick.AddListener(() =>
                {
                    // 如果当前没有选中keyDescription便直接返回
                    if (selectingKeyDescription == null) return;

                    ActivateKey(trans);

                    KeyInputType keyInputType = System.Enum.Parse<KeyInputType>(selectingKeyDescription.name);
                    InactivateKey(transform.Find("Keys").Find(inputDic[keyInputType].ToString()));

                    SystemRepository.Instance.GetSystem<InputSystem>().ChangeKeyCode(keyInputType, System.Enum.Parse<KeyCode>(trans.name));

                    RenderLine();
                });
            }

            ActivateKey();

            // 给所有KeyDescriptions添加事件
            foreach (var keyInputType in inputDic.Keys)
            {
                Transform keyDescription = transform.Find("KeyDescriptions").Find(keyInputType.ToString());

                // 添加按钮事件
                keyDescription.GetComponent<Button>().onClick.AddListener(() =>
                {
                    selectingKeyDescription = keyDescription;

                    // 先取消所有红框,再勾选选定红框
                    // NOTE:下方的两个keyInputType不同
                    foreach (var keyInputType in inputDic.Keys)
                    {
                        transform.Find("KeyDescriptions").Find(keyInputType.ToString()).Find("SelectBounds").gameObject.SetActive(false);
                    }
                    transform.Find("KeyDescriptions").Find(keyInputType.ToString()).Find("SelectBounds").gameObject.SetActive(true);
                });
            }

            // 绘制线段
            RenderLine();
        }

        private void RenderLine()
        {
            UILineRenderer lineRenderer = transform.Find("LineRenderer").GetComponent<UILineRenderer>();
            lineRenderer.Refresh();

            foreach (var keyInputType in inputDic.Keys)
            {
                Transform key = transform.Find("Keys").Find(inputDic[keyInputType].ToString());
                Transform keyDescription = transform.Find("KeyDescriptions").Find(keyInputType.ToString());

                Vector2 startPoint = key.GetComponent<RectTransform>().anchoredPosition;
                Vector2 endPoint = keyDescription.GetComponent<RectTransform>().anchoredPosition + keyDescription.Find("EndPoint").GetComponent<RectTransform>().anchoredPosition;
                startPoint += (endPoint - startPoint).normalized * 20f;

                Vector2 mediatorPoint;
                if (Mathf.Abs(startPoint.x - endPoint.x) > Mathf.Abs(startPoint.y - endPoint.y)) mediatorPoint = new Vector2(endPoint.x, startPoint.y);
                else mediatorPoint = new Vector2(startPoint.x, endPoint.y);
                lineRenderer.RendererLine(startPoint, mediatorPoint, new Color(0.2498911f, 0.5974842f, 0.5974842f, 0.7f), 5f);
                lineRenderer.RendererLine(mediatorPoint, endPoint, new Color(0.2498911f, 0.5974842f, 0.5974842f, 0.7f), 5f);
            }
        }

        // 激活所有key
        private void ActivateKey()
        {
            foreach (var keyInputType in inputDic.Keys)
            {
                ActivateKey(transform.Find("Keys").Find(inputDic[keyInputType].ToString()));
            }
        }

        // 激活keyTrans
        private void ActivateKey(Transform keyTrans)
        {
            keyTrans.Find("Active").gameObject.SetActive(true);
            keyTrans.Find("Inactive").gameObject.SetActive(false);
        }

        private void InactivateAllKeys()
        {
            foreach (Transform key in transform.Find("Keys"))
            {
                InactivateKey(key);
            }
        }

        private void InactivateKey(Transform keyTrans)
        {
            keyTrans.Find("Active").gameObject.SetActive(false);
            keyTrans.Find("Inactive").gameObject.SetActive(true);
        }
    }
}