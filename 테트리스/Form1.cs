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

		protected override void OnPaint(PaintEventArgs e)
		{
			int rows = _grid.GetLength(0);
			int cols = _grid.GetLength(1);

			for (int r = 0; r < rows; r++)
			{
				for (int c = 0; c < cols; c++)
				{
					if(_grid[r,c] != 0)
					{
						e.Graphics.FillRectangle(
							Brushes.Black,
							c*_blockSize,
							r*_blockSize,
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
	}
}