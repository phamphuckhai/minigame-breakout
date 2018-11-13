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
        bool goLeft = false;
        bool goRight = false;
        public Player()
        {
            InitializeComponent();
            this.BackColor = Color.AliceBlue;
        }

        public int Speed { get => speed; set => speed = value; }
        public bool GoRight { get => goRight; set => goRight = value; }
        public bool GoLeft { get => goLeft; set => goLeft = value; }
        #endregion
       
        #region functions
        public void move()
        {
            if (this.GoLeft) { this.Left -= this.Speed; }
            else if (this.GoRight) { this.Left += this.Speed; }
        }
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
        #endregion
    }
}
