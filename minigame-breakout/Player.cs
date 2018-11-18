﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace minigame_breakout
{
    public partial class Player : PlayerButton
    {
        #region properties
        private int speed = 5;
        private bool goLeft = false;
        private bool goRight = false;
        private bool isBuffSpeed = false;
        private bool isBouncing = false;
        public Player()
        {
            InitializeComponent();
            this.BackColor = Color.AliceBlue;
            this.ResizeRedraw = false;
        }

        public bool GoRight { get => goRight; set => goRight = value; }
        public bool GoLeft { get => goLeft; set => goLeft = value; }
        public int Speed { get => speed; set => speed = value; }
        public bool IsBuffSpeed { get => isBuffSpeed; set => isBuffSpeed = value; }
        public bool IsBouncing { get => isBouncing; set => isBouncing = value; }
        #endregion

        #region functions
        public void move()
        {
            /*if (isBuffSpeed)*/ this.speed = 10;
            if (isBouncing) this.ButtonColor = Color.Black;
            else this.ButtonColor = Color.Black;
            if (this.GoLeft) { this.Left -= this.speed; }
            else if (this.GoRight) { this.Left += this.speed; }
        }
        //xu ly va cham voi tuong
        public void collision_Wall(int clientWidthSize)
        {
            if (this.Left < 1)
            {
                this.GoLeft = false;
            }
            else if (this.Left + this.Width > clientWidthSize)
            {
                this.GoRight = false;
            }
        }
        //xu ly va cham voi item
        public bool collision_Item(Item item)
        {
            if (this.Bounds.IntersectsWith(item.Bounds))
            {
                int func = item.Function;
                if (func == 0)
                {
                    Random rnd = new Random();
                    int generator = rnd.Next(7)+1;
                    func = generator;
                }
                if (func == 1)
                {
                    speed = (int)(speed * 0.6);
                }
                if (func == 2)
                {
                    speed = (int)(speed * 1.5);
                }
                if (func == 3)
                {
                    //later
                }
                if (func == 4)
                {
                    Width *= 2;
                }
                if (func == 5)
                {
                    Width /= 2;
                }
                if (func == 6)
                {
                    //toball
                }
                return true;
            }
            return false;
        }
        #endregion
    }
}
