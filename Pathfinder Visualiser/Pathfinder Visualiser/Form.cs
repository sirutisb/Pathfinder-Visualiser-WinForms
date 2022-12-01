using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace New_Pathfinder
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        const int maxGridSize = 256;
        Grid[,] grid = new Grid[maxGridSize, maxGridSize];
        int nodeSize = 75;
        int gridSize = 0;

        Point StartPos = new Point(0, 0);
        Point EndPos = new Point(1, 1);

        List<Point> Path = new List<Point>();
        List<Point> RevealPath = new List<Point>();

        // Brushes
        Brush foregroundBrush = Brushes.LightBlue;
        Brush startBrush = Brushes.LimeGreen;
        Brush endBrush = Brushes.OrangeRed;
        Brush obstacleBrush = new SolidBrush(Color.FromArgb(35, 35, 35));


        bool shift;
        bool ctrl;

        private void CreateGrid()
        {
            if (gridSize < 2 || gridSize > maxGridSize) return;
            if (autoResizeCheckBox.Checked)
                AutoResize();
            Size = new Size(gridSize * nodeSize + 200 + 16, gridSize * nodeSize + 39);
            gridSizeLabel.Text = "Grid Size: " + gridSize.ToString();
            Path.Clear();
            gridPictureBox.Invalidate();
        }

        void AutoResize()
        {
            Rectangle screenRectangle = this.RectangleToScreen(this.ClientRectangle);
            int titleHeight = screenRectangle.Top - this.Top;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height - 45 - titleHeight;
            nodeSize = screenHeight / gridSize;
        }
        private void Form_Load(object sender, EventArgs e)
        {
            for (int y = 0; y < maxGridSize; y++)
            {
                for (int x = 0; x < maxGridSize; x++)
                {
                    grid[x, y] = new Grid();
                }
            }

            string[] args = Environment.GetCommandLineArgs();
            if(args.Length == 2)
            {
                loadMap(args[1]);
            }
        }
        private void createGridButton_Click(object sender, EventArgs e)
        {
            if (gridSizeTextBox.Text == null) return;
            try
            {
                gridSize = int.Parse(gridSizeTextBox.Text);
                CreateGrid();
            }
            catch
            {
                MessageBox.Show("Please enter a valid grid size!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (gridSize < 2 || gridSize > maxGridSize)
                MessageBox.Show("Grid Size must be between 2-" + maxGridSize + "!", "Invalid Grid Size!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        private void saveGridButton_Click(object sender, EventArgs e)
        {
            string mapData = "";
            for (int y = 0; y < gridSize; y++)
            {
                for (int x = 0; x < gridSize; x++)
                {
                    if (x == StartPos.X && y == StartPos.Y)
                        mapData += '2';
                    else if (x == EndPos.X && y == EndPos.Y)
                        mapData += '3';
                    else if (grid[x, y].isObstacle)
                        mapData += '1';
                    else
                        mapData += '0';
                }
            }

            SaveFileDialog fileDialog = new SaveFileDialog();

            fileDialog.Title = "Select Map File";
            //fileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            fileDialog.Filter = "pmap files (*.pmap)|*.pmap|All files (*.*)|*.*";
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(fileDialog.FileName))
                {
                    sw.Write(mapData);
                }
            }
        }

        void loadMap(string fileName)
        {
            string mapData = "";
            using (StreamReader sr = new StreamReader(fileName))
            {
                mapData = sr.ReadToEnd();
            }
            gridSize = (int)Math.Sqrt(mapData.Length);
            for (int y = 0; y < gridSize; y++)
            {
                for (int x = 0; x < gridSize; x++)
                {
                    grid[x, y] = new Grid();
                    if (mapData[y * gridSize + x] == '2')
                        StartPos = new Point(x, y);
                    else if (mapData[y * gridSize + x] == '3')
                        EndPos = new Point(x, y);
                    else if (mapData[y * gridSize + x] == '1')
                        grid[x, y].isObstacle = true;
                }
            }
            CreateGrid();
        }
        private void loadGridButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.Title = "Select Map File";
            fileDialog.Filter = "pmap files (*.pmap)|*.pmap|All files (*.*)|*.*";
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                loadMap(fileDialog.FileName);
            }
        }
        private void clearGridButton_Click(object sender, EventArgs e)
        {
            Path.Clear();
            StartPos = new Point(0, 0);
            EndPos = new Point(1, 1);
            for (int y = 0; y < gridSize; y++)
            {
                for (int x = 0; x < gridSize; x++)
                    grid[x, y] = new Grid();
            }
            gridPictureBox.Invalidate();
        }
        private void findPathButton_Click(object sender, EventArgs e)
        {
            findPath();
        }
        private void gridPictureBox_Paint(object sender, PaintEventArgs e)
        {
            for(int y = 0; y < gridSize; y++)
            {
                for (int x = 0; x < gridSize; x++)
                {
                    RectangleF rect = new RectangleF(x * nodeSize, y * nodeSize, nodeSize, nodeSize);
                    if (grid[x, y].isObstacle)
                    {
                        e.Graphics.FillRectangle(obstacleBrush, rect);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(foregroundBrush, rect);



                        if (showNodeInfoCheckBox.Checked)
                        {
                            string nodeInfoText = "";
                            if (grid[x, y].isVisited)
                                nodeInfoText += 'V';
                            else
                                nodeInfoText += 'N';
                            nodeInfoText += '|' + grid[x, y].distanceFromStart;
                            e.Graphics.DrawString(nodeInfoText, new Font("Arial", nodeSize / 5), Brushes.Black, x * nodeSize, y * nodeSize);
                        }
                    }
                }
            }
            RectangleF rectangle = new RectangleF(StartPos.X * nodeSize, StartPos.Y * nodeSize, nodeSize, nodeSize);
            e.Graphics.FillRectangle(startBrush, rectangle);
            rectangle.X = EndPos.X * nodeSize;
            rectangle.Y = EndPos.Y * nodeSize;
            e.Graphics.FillRectangle(endBrush, rectangle);

            // Show Path
            for (int i = 0; i < Path.Count; i++)
            {
                rectangle.X = Path[i].X * nodeSize;
                rectangle.Y = Path[i].Y * nodeSize;
                e.Graphics.FillRectangle(Brushes.Purple, rectangle);
            }

        }
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift)
                shift = true;
            if (e.Control)
                ctrl = true;
        }
        private void Form_KeyUp(object sender, KeyEventArgs e)
        {
            if (!e.Shift)
                shift = false;
            if (!e.Control)
                ctrl = false;
        }

        private void gridSizeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            nodeSize = gridSizeTrackBar.Value;
            boxSizeLabel.Text = "Node Size: " + nodeSize;
            CreateGrid();
        }

        private void showNodeInfoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            gridPictureBox.Invalidate();
        }
        private void pathIntervalTrackBar_ValueChanged(object sender, EventArgs e)
        {
            pathIntervalLabel.Text = "Path Reveal Interval: " + pathIntervalTrackBar.Value.ToString();
            revealPathTimer.Interval = pathIntervalTrackBar.Value;
        }
        private void revealPathTimer_Tick(object sender, EventArgs e)
        {
            if (RevealPath.Count == 0)
            {
                revealPathTimer.Stop();
                return;
            }

            Path.Add(RevealPath[0]);
            RevealPath.RemoveAt(0);
            gridPictureBox.Invalidate();
        }

        void VisitNode(ref Point currentPos, ref Point neighbourPos, ref Queue<Point> visitedNodes) // for better code implement this
        {
            neighbourPos = new Point(currentPos.X, currentPos.Y - 1);
            if (!grid[neighbourPos.X, neighbourPos.Y].isObstacle && !grid[neighbourPos.X, neighbourPos.Y].isVisited)
            {
                int currentDistance = grid[currentPos.X, currentPos.Y].distanceFromStart + 1;
                if (currentDistance < grid[neighbourPos.X, neighbourPos.Y].distanceFromStart)
                {
                    grid[neighbourPos.X, neighbourPos.Y].distanceFromStart = currentDistance;
                    grid[neighbourPos.X, neighbourPos.Y].previousVertex = currentPos;
                    visitedNodes.Enqueue(neighbourPos);
                }
            }
        }

        void findPath()
        {
            Path.Clear();
            RevealPath.Clear();

            Point currentPos = StartPos;
            Point neighbourPos;

            // Reset variables
            for (int y = 0; y < gridSize; y++)
            {
                for (int x = 0; x < gridSize; x++)
                {
                    grid[x, y].isVisited = false;
                    grid[x, y].distanceFromStart = maxGridSize * maxGridSize;
                    grid[x, y].previousVertex = new Point();
                }
            }

            grid[StartPos.X, StartPos.Y].distanceFromStart = 0;
            grid[StartPos.X, StartPos.Y].previousVertex = StartPos;

            Queue<Point> visitedNodes = new Queue<Point>();

            while (currentPos != EndPos)
            {
                int currentDistance;

                // Up
                if (currentPos.Y > 0)
                {
                    neighbourPos = new Point(currentPos.X, currentPos.Y - 1);
                    if (!grid[neighbourPos.X, neighbourPos.Y].isObstacle && !grid[neighbourPos.X, neighbourPos.Y].isVisited)
                    {
                        currentDistance = grid[currentPos.X, currentPos.Y].distanceFromStart + 1;
                        if (currentDistance < grid[neighbourPos.X, neighbourPos.Y].distanceFromStart)
                        {
                            grid[neighbourPos.X, neighbourPos.Y].distanceFromStart = currentDistance;
                            grid[neighbourPos.X, neighbourPos.Y].previousVertex = currentPos;
                            visitedNodes.Enqueue(neighbourPos);
                        }

                    }
                }

                // Left
                if (currentPos.X > 0)
                {
                    neighbourPos = new Point(currentPos.X - 1, currentPos.Y);
                    if (!grid[neighbourPos.X, neighbourPos.Y].isObstacle && !grid[neighbourPos.X, neighbourPos.Y].isVisited)
                    {
                        currentDistance = grid[currentPos.X, currentPos.Y].distanceFromStart + 1;
                        if (currentDistance < grid[neighbourPos.X, neighbourPos.Y].distanceFromStart)
                        {
                            grid[neighbourPos.X, neighbourPos.Y].distanceFromStart = currentDistance;
                            grid[neighbourPos.X, neighbourPos.Y].previousVertex = currentPos;
                            visitedNodes.Enqueue(neighbourPos);
                        }
                    }
                }

                // Down
                if (currentPos.Y < gridSize - 1)
                {
                    neighbourPos = new Point(currentPos.X, currentPos.Y + 1);
                    if (!grid[neighbourPos.X, neighbourPos.Y].isObstacle && !grid[neighbourPos.X, neighbourPos.Y].isVisited)
                    {
                        currentDistance = grid[currentPos.X, currentPos.Y].distanceFromStart + 1;
                        if (currentDistance < grid[neighbourPos.X, neighbourPos.Y].distanceFromStart)
                        {
                            grid[neighbourPos.X, neighbourPos.Y].distanceFromStart = currentDistance;
                            grid[neighbourPos.X, neighbourPos.Y].previousVertex = currentPos;
                            visitedNodes.Enqueue(neighbourPos);
                        }
                    }
                }

                // Right
                if (currentPos.X < gridSize - 1)
                {
                    neighbourPos = new Point(currentPos.X + 1, currentPos.Y);
                    if (!grid[neighbourPos.X, neighbourPos.Y].isObstacle && !grid[neighbourPos.X, neighbourPos.Y].isVisited)
                    {
                        currentDistance = grid[currentPos.X, currentPos.Y].distanceFromStart + 1;
                        if (currentDistance < grid[neighbourPos.X, neighbourPos.Y].distanceFromStart)
                        {
                            grid[neighbourPos.X, neighbourPos.Y].distanceFromStart = currentDistance;
                            grid[neighbourPos.X, neighbourPos.Y].previousVertex = currentPos;
                            visitedNodes.Enqueue(neighbourPos);
                        }
                    }
                }

                if (visitedNodes.Count == 0) // Reached dead end, path not found.
                {
                    pathLengthLabel.Text = "Path Length: ∞";
                    return;
                }

                grid[currentPos.X, currentPos.Y].isVisited = true;
                currentPos = visitedNodes.Dequeue();
            }

            Point previous = EndPos;

            while (grid[previous.X, previous.Y].previousVertex != StartPos)
            {
                previous = grid[previous.X, previous.Y].previousVertex;
                Path.Add(previous);
            }
            Path.Reverse();
            gridPictureBox.Invalidate();

            pathLengthLabel.Text = "Path Length: " + (Path.Count + 1).ToString();

            if(revealPathCheckBox.Checked)
            {
                RevealPath = new List<Point>(Path);
                Path.Clear();
                revealPathTimer.Start();
            }
        }


        bool mouseDown = false;
        private void gridPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastClickedGrid = new Point(e.X / nodeSize, e.Y / nodeSize);
            ToggleGrid(lastClickedGrid);
        }

        private void gridPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        Point lastClickedGrid = new Point(-1, -1);
        private void gridPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mouseDown) return;
            Point clickedGrid = new Point(e.X / nodeSize, e.Y / nodeSize);

            if (clickedGrid != lastClickedGrid)
            {
                lastClickedGrid = clickedGrid;
                ToggleGrid(clickedGrid);
            }
        }

        void ToggleGrid(Point pos)
        {
            if (pos.X >= maxGridSize || pos.Y >= maxGridSize) return;
            if (pos.X < 0 || pos.Y < 0) return;
            if (pos.X >= gridSize || pos.Y >= gridSize) return; // Keep in range of current map size
            if (pos == StartPos || pos == EndPos) return; // Dont allow to replace start/end pos.

            if (shift)
            {
                grid[pos.X, pos.Y].isObstacle = false;
                StartPos = pos;
            }
            else if (ctrl)
            {
                grid[pos.X, pos.Y].isObstacle = false;
                EndPos = pos;
            }
            else
            {
                grid[pos.X, pos.Y].isObstacle = !grid[pos.X, pos.Y].isObstacle;
            }

            Path.Clear();
            gridPictureBox.Invalidate();

            if (autoPathfindCheckBox.Checked) // auto find path after modifying (experimental)
                findPath();
        }

        int r = 255, g = 0, b = 0;
        private void rgbCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            rgbTimer.Enabled = rgbCheckBox.Checked;
        }

        private void rgbTimer_Tick(object sender, EventArgs e) // LOL experimental stuff
        {
            if (r > 0 && b == 0)
            {
                r--;
                g++;
            }
            if (g > 0 && r == 0)
            {
                g--;
                b++;
            }
            if (b > 0 && g == 0)
            {
                b--;
                r++;
            }
            trackBar1.Value = r;
            trackBar2.Value = g;
            trackBar3.Value = b;
            obstacleBrush = new SolidBrush(Color.FromArgb(r,g,b));
            gridPictureBox.Invalidate();
        }
    }
}