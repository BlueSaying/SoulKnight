using UnityEngine;

public abstract class Bow : Weapon
{
    protected bool isCharging;
    protected float chargingTimer;

    public new BowModel model { get => base.model as BowModel; protected set => base.model = value; }

    public GameObject chargingBar { get; protected set; }
    public GameObject[] chargingBars = new GameObject[5];

    public GameObject shootPoint { get; protected set; }

    #region Attr
    public int ChargingDamage => model.staticAttr.chargingDamage;

    public int ChargingCritical => model.staticAttr.chargingCritical;

    public float ChargingTime => model.staticAttr.chargingTime;
    #endregion

    public Bow(GameObject gameObject, Character owner, WeaponModel model) : base(gameObject, owner, model) { }

    protected override void OnInit()
    {
        base.OnInit();
        chargingBar = UnityTools.GetTransformFromChildren(gameObject, "ChargingBar").gameObject;
        for (int i = 0; i < 5; i++)
        {
            chargingBars[i] = chargingBar.transform.Find("ChargingBar" + i.ToString()).gameObject;
        }

        shootPoint = UnityTools.GetTransformFromChildren(gameObject, "ShootPoint").gameObject;
    }

    protected override void OnEnter()
    {
        base.OnEnter();
        isCharging = false;
        chargingTimer = 0f;
        RefreshChargingBar();
    }

    protected override (int damage, bool isCritical) CalcDamageInfo()
    {
        int damageOutput = Mathf.RoundToInt(Mathf.Lerp(Damage, ChargingDamage, chargingTimer / ChargingTime));
        bool isCriticalOutput = false;
        int criticalRate = Mathf.RoundToInt(Mathf.Lerp(CriticalRate, ChargingCritical, chargingTimer / ChargingTime))
            + (owner is Player player ? player.critical : 0);

        if (Random.Range(0f, 100f) < criticalRate)
        {
            damageOutput *= 2;
            isCriticalOutput = true;
        }

        return (damageOutput, isCriticalOutput);
    }

    public override void ControlWeapon(bool isCharging)
    {
        // 如果现在没有在蓄力但之间在蓄力
        if (!isCharging)
        {
            if (this.isCharging)
            {
                this.isCharging = false;

                // 根据武器拥有者是否为玩家扣除能量值
                if (owner is Player && !TestManager.Instance.isUnlockWeapon)
                {
                    (owner as Player).CurEnergy.AddFlatModifier(-EnergyCost);
                }

                animator.SetBool("isCharging", isCharging);
                canRotate = isCharging; // 能否旋转仅依赖是否在蓄力

                OnFire();

                chargingTimer = 0f;

                RefreshChargingBar();
            }
        }
        else
        {
            // 根据武器拥有者是否为玩家
            if (!TestManager.Instance.isUnlockWeapon && owner is Player && (owner as Player).CurEnergy.Value < EnergyCost)
            {
                return;
            }

            animator.SetBool("isCharging", isCharging);
            canRotate = isCharging;

            this.isCharging = true;
            chargingTimer = Mathf.Clamp(chargingTimer + Time.deltaTime, 0f, ChargingTime);
            RefreshChargingBar();
        }
    }

    private void RefreshChargingBar()
    {
        Color whiteColor = Color.white;
        Color grayColor = new Color(0.3f, 0.3f, 0.3f);

        // 根据当前是否在蓄力决定蓄力条是否可见
        if (isCharging)
        {
            chargingBar.SetActive(true);
        }
        else
        {
            chargingBar.SetActive(false);
        }

        float chargingProgress = 5 * chargingTimer / ChargingTime;

        for (int i = 0; i < 5; i++)
        {
            if (chargingProgress >= 1)
            {
                chargingBars[i].GetComponent<SpriteRenderer>().color = whiteColor;
                chargingProgress -= 1;
            }
            else if (chargingProgress > 0)
            {
                chargingBars[i].GetComponent<SpriteRenderer>().color = Color.Lerp(grayColor, whiteColor, chargingProgress);
                chargingProgress = 0;
            }
            else
            {
                chargingBars[i].GetComponent<SpriteRenderer>().color = grayColor;
            }
        }
    }
}