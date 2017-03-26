using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 테트리스
{
	public partial class Form1 : Form
	{
		Tetris _tt;
		Bitmap _buff;
		bool _left, _right, _up, _down;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			_tt = new Tetris();
			_buff = new Bitmap(this.Width, this.Height);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.DrawImage(_buff, 0, 0);
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			int x = 0, y = 0;
			if (_left) x--;
			if (_right) x++;
			if (_up) y--;
			if (_down) y++;
			_tt.shift(x, y);

			Graphics g = Graphics.FromImage(_buff);
			g.Clear(Color.White);
			_tt.draw(g);

			Invalidate();
		}

		#region Form1_KeyDown(), Form1_KeyUp()

		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Left:
					_left = true;
					break;
				case Keys.Right:
					_right = true;
					break;
				case Keys.Up:
					_up = true;
					break;
				case Keys.Down:
					_down = true;
					break;
			}
		}

		private void Form1_KeyUp(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Left:
					_left = false;
					break;
				case Keys.Right:
					_right = false;
					break;
				case Keys.Up:
					_up = false;
					break;
				case Keys.Down:
					_down = false;
					break;
			}

		}

		#endregion
	}
}