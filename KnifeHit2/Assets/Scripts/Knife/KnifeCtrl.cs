using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeCtrl : ThanhMonoBehaviour
{
    
        [SerializeField] protected KnifeMove knifeMove;
        public KnifeMove KnifeMove { get => knifeMove; }
        [SerializeField] protected KnifeShootLine knifeShootLine;
        public KnifeShootLine KnifeShootLine { get => knifeShootLine; }
        public Vector3 pos;
        public Quaternion ros;
        public Transform model;
        protected override void LoadComponent()
            {
                base.LoadComponent();
                this.LoadKnifeMove();
                this.LoadKnifeShootLine();
            }
        private void Start()
            {
                this.pos = this.transform.position;
                this.ros = this.transform.rotation;
        this.model = this.transform.Find("Model");
            }
        private void LoadKnifeShootLine()
        {
            if (this.knifeShootLine != null) return;
            this.knifeShootLine = this.GetComponentInChildren<KnifeShootLine>();
        }

        private void LoadKnifeMove()
            {
                if (this.knifeMove != null) return;
                this.knifeMove = this.GetComponentInChildren<KnifeMove>();
            }
}

