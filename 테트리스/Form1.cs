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
		int[,] _grid = new int[20, 10];
		int _blockSize = 20;
		bool _left, _right, _up, _down;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			_grid[0, 0] = 1;
			_grid[0, 1] = 1;
			_grid[0, 2] = 0;

			_grid[1, 0] = 0;
			_grid[1, 1] = 1;
			_grid[1, 2] = 1;
		}

		#region OnPaint(), shift(), sum()

		protected override void OnPaint(PaintEventArgs e)
		{
			int rows = _grid.GetLength(0);
			int cols = _grid.GetLength(1);

			for (int r = 0; r < rows; r++)
			{
				for (int c = 0; c < cols; c++)
				{
					if (_grid[r, c] != 0)
					{
						e.Graphics.FillRectangle(
							Brushes.Black,
							c * _blockSize,
							r * _blockSize,
							_blockSize,
							_blockSize
						);
					}
					else
					{
						e.Graphics.DrawRectangle(
							Pens.Black,
							c * _blockSize,
							r * _blockSize,
							_blockSize,
							_blockSize
						);
					}
				}
			}
		}

		int[,] shift(int[,] grid, int x, int y)
		{
			int sum_grid = sum(grid);

			int rows = grid.GetLength(0);
			int cols = grid.GetLength(1);
			int[,] clone = new int[rows, cols];

			for (int r = 0; r < rows; r++)
			{
				if (r + y < 0 || r + y >= rows) continue;

				for (int c = 0; c < cols; c++)
				{
					if (c + x < 0 || c + x >= cols) continue;

					clone[r + y, c + x] = grid[r, c];
				}
			}

			int sum_clone = sum(clone);
			if (sum_grid == sum_clone) return clone;
			else return grid;
		}

		int sum(int[,] arr)
		{
			int rows = arr.GetLength(0);
			int cols = arr.GetLength(1);
			int i = 0;

			for (int r = 0; r < rows; r++)
			{
				for (int c = 0; c < cols; c++)
				{
					i += arr[r, c];
				}
			}

			return i;
		}

		#endregion

		private void timer1_Tick(object sender, EventArgs e)
		{
			int x = 0, y = 0;
			if (_left) x--;
			if (_right) x++;
			if (_up) y--;
			if (_down) y++;

			_grid = shift(_grid, x, y);
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