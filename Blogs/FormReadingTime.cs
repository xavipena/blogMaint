﻿using Blogs.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Blogs
{
    public partial class FormReadingTime : Form
    {
        Singleton Gdata = Singleton.GetInstance();
        bool NeedToSave = false;

        public FormReadingTime()
        {
            InitializeComponent();
            SetUpForm();
            SetDefaultValues();
            DefineGrids();
        }

        private void SetUpForm()
        {
        }

        private void SetDefaultValues()
        {
        }

        private void DefineGrids()
        {
            dgvArticles.Rows.Clear();
            dgvArticles.ColumnCount = 5;
            dgvArticles.AllowUserToAddRows = false;
            dgvArticles.MultiSelect = false;

            dgvArticles.Columns[0].Name = "ID";
            dgvArticles.Columns[0].Width = 40;
            dgvArticles.Columns[1].Name = "Títol";
            dgvArticles.Columns[1].Width = 400;
            dgvArticles.Columns[2].Name = "Temps";
            dgvArticles.Columns[2].Width = 50;
            dgvArticles.Columns[3].Name = "Mots";
            dgvArticles.Columns[3].Width = 50;
            dgvArticles.Columns[4].Name = "Mod";
            dgvArticles.Columns[4].Width = 40;

        }

        // ---------------------------------------------------------------------------
        // Load data
        // ---------------------------------------------------------------------------

        /// <summary>
        /// Load articles list
        /// </summary>
        private void LoadArticles()
        {
            Gdata.db.DBOpen();

            string sql = "select IDarticle, title, readTime, wordCount, type, date " +
                         "from articles where IDblog = " + Gdata.currentBlog + " and lang = '" + Gdata.Lang + "' " +
                         "order by date desc";
            var cmd = new MySqlCommand(sql, Gdata.db.Connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string[] aRow = new string[]
                {
                    reader.GetInt32(0).ToString(),
                    reader.GetString(1),
                    reader.GetInt32(2).ToString(),
                    reader.GetInt32(3).ToString(),
                    string.Empty
                };
                dgvArticles.Rows.Add(aRow);

            }

            Gdata.db.DBClose();
        }

        /// <summary>
        /// Load article list into grid
        /// </summary>
        private void LoadArticlesGrid()
        {
            dgvArticles.Rows.Clear();

            //cbOption op = cbBlogs.SelectedItem as cbOption;
            //Gdata.currentBlog = Int32.Parse(op.entityValue);
            LoadArticles();
            //SetButtonStatus();
        }

        // ---------------------------------------------------------------------------
        // Routines to update time/words
        // ---------------------------------------------------------------------------

        /// <summary>
        /// Check grid to determine which rows need update
        /// </summary>
        private void UpdateTableArticle()
        {
            foreach (DataGridViewRow row in dgvArticles.Rows)
            {
                if (row.Cells[4].Value.ToString() == Marks.MODIFIED)
                {
                    UpdateRow(row);
                }
            }
        }

        /// <summary>
        /// Update one single row from list
        /// </summary>
        /// <param name="row"></param>
        private void UpdateRow(DataGridViewRow row)
        {
            string sql = "update articles " +
                        "set readTime = @val1, wordCount = @val2 " +
                        "where IDblog = @par1 and IDarticle = @par2";

            Gdata.db.DBOpen();
            var cmd = new MySqlCommand(sql, Gdata.db.Connection);
            cmd.Parameters.AddWithValue("@par1", Gdata.currentBlog);
            cmd.Parameters.AddWithValue("@par2", row.Cells[0].Value);
            cmd.Parameters.AddWithValue("@val1", row.Cells[2].Value);
            cmd.Parameters.AddWithValue("@val2", row.Cells[3].Value);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
            finally
            {
                Gdata.db.DBClose();
            }
        }

        /// <summary>
        /// Calculate article read time
        /// </summary>
        /// <param name="row"></param>
        private void SetReadTimeFor(DataGridViewRow row)
        {
            // Search details and count words
            int ID = Int32.Parse(row.Cells[0].Value.ToString());
            int w = Workers.GetWordCount(ID);
            int m = (w / Articles.WORDS_PER_MIN) + 1;
            // update
            row.Cells[2].Value = m;
            row.Cells[3].Value = w;
            row.Cells[4].Value = Marks.MODIFIED;
            NeedToSave = true;
        }

        private void btnWords_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool noData = true;
            foreach (DataGridViewRow row in dgvArticles.SelectedRows)
            {
                SetReadTimeFor(row);
                noData = false;
            }
            if (noData)
            {
                lblMessage.Text = "Res seleccionat";
            }
            Cursor.Current = Cursors.Default;
        }

        private void btnWordsAll_Click(object sender, EventArgs e)
        {
            if (dgvArticles.Rows.Count == 0)
            {
                lblMessage.Text = "No hi ha articles";
                return;
            }
            Cursor.Current = Cursors.WaitCursor;
            int x = 0;
            foreach (DataGridViewRow row in dgvArticles.Rows)
            {
                if (Int32.Parse(row.Cells[2].Value.ToString()) == 0
                 || Int32.Parse(row.Cells[3].Value.ToString()) == 0)
                {
                    SetReadTimeFor(row);
                    x += 1;
                }
            }
            if (x > 0)
            {
                //LoadArticlesGrid();
                lblMessage.Text = x + " articles actualitzats";
            }
            Cursor.Current = Cursors.Default;
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            UpdateTableArticle();
            NeedToSave = false;
            LoadArticlesGrid();
        }

    }
}