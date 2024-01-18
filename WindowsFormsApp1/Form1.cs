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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        TransportProblem TP;
        float[,] Optimum;
        float[,] SupportPlan;
        public Form1()
        {
            InitializeComponent();
            GridB.RowsAdded += new DataGridViewRowsAddedEventHandler(GridB_RowsAdded);
            GridA.RowsAdded += new DataGridViewRowsAddedEventHandler(GridA_RowsAdded);
            GridB.RowsRemoved += new DataGridViewRowsRemovedEventHandler(GridB_RowsRemoved);
            GridA.RowsRemoved += new DataGridViewRowsRemovedEventHandler(GridA_RowsRemoved);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void GridA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            GridA.RowCount = 1;
            GridB.RowCount = 1;
            GridC.ColumnCount = 1;
            GridC.RowCount = 1;
            Stream myStream;
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = "E:\\",
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        StreamReader SR = new StreamReader(myStream);
                        string[] Sizes = SR.ReadLine().Split(' ');
                        int.TryParse(Sizes[0], out int Asize);
                        int.TryParse(Sizes[1], out int Bsize);
                        string A = SR.ReadLine();
                        string B = SR.ReadLine();
                        string[] C = new string[Asize];

                        for (int i = 0; i < Asize; i++)
                            C[i] = SR.ReadLine();
                        try
                        {
                            TP = new TransportProblem(Asize, Bsize, A, B, C);
                        }
                        catch (Exception exc)
                        { MessageBox.Show(exc.Message); }
                    }
                    myStream.Close();

                    GridA.Visible = true;
                    GridB.Visible = true;
                    GridC.Visible = true;
                    FillGrids();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
        private void GridA_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            GridC.RowCount++;
        }

        private void GridA_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (GridC.RowCount > 0) GridC.RowCount--;
        }
        private void CreateColumnsHeaders(DataGridView grid)
        {
            grid.Columns.Clear();
            DataGridViewColumn[] newColumns = new DataGridViewColumn[GridB.Rows.Count - 1];
            for (int i = 0; i < newColumns.Length; i++)
            {
                DataGridViewTextBoxColumn ColC = new System.Windows.Forms.DataGridViewTextBoxColumn();
                grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { ColC });
                ColC.FillWeight = 50F;
                ColC.HeaderText = "B" + (grid.Columns.Count).ToString();
                ColC.Name = (grid.Columns.Count).ToString();
                ColC.Width = 50;
            }
        }

        private void GridB_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CreateColumnsHeaders(GridC);
        }

        private void GridB_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            GridC.Columns.Remove((e.RowIndex + 1).ToString());
            int i = 1;
            foreach (DataGridViewTextBoxColumn Col in GridC.Columns)
            {
                Col.Name = i.ToString();
                Col.HeaderText = Col.Name;
                i++;
            }
        }
        private void FillBigGrid(DataGridView grid, float[,] arr)
        {
            DataGridViewRow DataGridRow = new DataGridViewRow();
            for (int k = 0; k < TP.ASize; k++)
            {
                DataGridRow = new DataGridViewRow();
                DataGridRow.CreateCells(grid);
                for (int j = 0; j < TP.BSize; j++) DataGridRow.Cells[j].Value = arr[k, j].ToString();
                DataGridRow.HeaderCell.Value = "A" + (k + 1).ToString();
                grid.Rows.Insert(grid.Rows.Count - 1, DataGridRow);
            }
        }

        private void FillGrids()
        {
            for (int i = 0; i < TP.ASize; i++) GridA.Rows.Add(TP.mA[i].ToString());
            for (int i = 0; i < TP.BSize; i++) GridB.Rows.Add(TP.mB[i].ToString());
            FillBigGrid(GridC, TP.mC);
        }
        private void buttonMinEl_Click(object sender, EventArgs e)
        {
            CreateColumnsHeaders(GridHelp);
            SupportPlan = TP.MinEl();
            FillBigGrid(GridHelp, SupportPlan);
            FillHelpResult();
        }
        private void buttonNW_Click(object sender, EventArgs e)
        {
            CreateColumnsHeaders(GridHelp);
            SupportPlan = TP.NordWest();
            FillBigGrid(GridHelp, SupportPlan);
            FillHelpResult();
        }
        private void FillHelpResult()
        {
            float Sum = 0;
            for (int i = 0; i < SupportPlan.Length; i++)
            {
                int j = (i - i % TP.BSize) / TP.BSize;
                int k = i % TP.BSize;
                if (SupportPlan[j, k] == SupportPlan[j, k])
                    Sum += SupportPlan[j, k] * TP.mC[j, k];
            }
            textBoxResultTwoPage.Text = Sum.ToString();
            textBoxResultTwoPage.Visible = true;
            GridHelp.Visible = true;
            label1.Visible = true;
        }
        private void buttonResult_Click(object sender, EventArgs e)
        {
            CreateColumnsHeaders(GridResult);
            Optimum = TP.PotenMeth(SupportPlan);
            FillBigGrid(GridResult, Optimum);
            FillResult();
        }
        private void FillResult()
        {
            float Sum = 0;
            for (int i = 0; i < Optimum.Length; i++)
            {
                int j = (i - i % TP.BSize) / TP.BSize;
                int k = i % TP.BSize;
                if (Optimum[j, k] == Optimum[j, k])
                    Sum += Optimum[j, k] * TP.mC[j, k];
            }
            textBoxResult.Text = Sum.ToString();
            textBoxResult.Visible = true;
            GridResult.Visible = true;
            label2.Visible = true;
        }
    }
}