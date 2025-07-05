using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public class Knight : IPlayer
{
    private Vector2 _moveDir;
    private Rigidbody2D _rb;
    public Knight(GameObject obj) : base(obj) { }
    protected override void OnInit()
    {
        base.OnInit();
        _rb = transform.GetComponent<Rigidbody2D>();
    }
    protected override void OnCharacterUpdate()
    {
        base.OnCharacterUpdate();

        // 测试代码
        _moveDir.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (_moveDir.magnitude > 0)
        {
            if (_moveDir.x > 0) isLeft = true;
            else isLeft = false;

            _rb.transform.position += (Vector3)_moveDir * 8 * Time.deltaTime;
        }
    }
}