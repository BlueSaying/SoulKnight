using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenuScene
{
    public class KeyBoardPanel : Panel
    {
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
            });

            // 给所有keyDescription添加事件
            foreach (Transform trans in transform.Find("Keys"))
            {
                trans.Find("Inactive").GetComponent<Button>().onClick.AddListener(() =>
                {
                    if (selectingKeyDescription == null) return;

                    ActivateKey(trans);

                    KeyInputType keyInputType = System.Enum.Parse<KeyInputType>(selectingKeyDescription.name);
                    InactivateKey(transform.Find("Keys").Find(inputDic[keyInputType].ToString()));

                    SystemRepository.Instance.GetSystem<InputSystem>().ChangeKeyCode(keyInputType, System.Enum.Parse<KeyCode>(trans.name));

                    RenderLine();
                });
            }

            ActivateKey();

            // 遍历所有输入
            foreach (var keyInputType in inputDic.Keys)
            {
                Transform keyDescription = transform.Find("KeyDescriptions").Find(keyInputType.ToString());

                // 添加按钮事件
                keyDescription.GetComponent<Button>().onClick.AddListener(() =>
                {
                    selectingKeyDescription = keyDescription;
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
                lineRenderer.RendererLine(startPoint, mediatorPoint, new Color(0.4039216f, 0.7215686f, 0.7215686f, 0.75f));
                lineRenderer.RendererLine(mediatorPoint, endPoint, new Color(0.4039216f, 0.7215686f, 0.7215686f, 0.75f));
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
            foreach(Transform key in transform.Find("Keys"))
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