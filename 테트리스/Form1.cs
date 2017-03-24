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
		bool _left, _right, _up, _down;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			_tt = new Tetris();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			int rows = _tt._grid.GetLength(0);
			int cols = _tt._grid.GetLength(1);

			for (int r = 0; r < rows; r++)
			{
				for (int c = 0; c < cols; c++)
				{
					if (_tt._grid[r, c] != 0)
					{
						e.Graphics.FillRectangle(
							Brushes.Black,
							c * _tt._blockSize,
							r * _tt._blockSize,
							_tt._blockSize,
							_tt._blockSize
						);
					}
					else
					{
						e.Graphics.DrawRectangle(
							Pens.Black,
							c * _tt._blockSize,
							r * _tt._blockSize,
							_tt._blockSize,
							_tt._blockSize
						);
					}
				}
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			int x = 0, y = 0;
			if (_left) x--;
			if (_right) x++;
			if (_up) y--;
			if (_down) y++;

			_tt._grid = _tt.shift(_tt._grid, x, y);
			Invalidate();
		}

		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			switch(e.KeyCode)
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
	}
}