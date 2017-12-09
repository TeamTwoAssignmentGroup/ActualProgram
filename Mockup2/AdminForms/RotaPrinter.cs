using Mockup2.Support;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mockup2.AdminForms
{
    /// <summary>
    /// Shamelessly stolen from <see href="https://stackoverflow.com/questions/15853746/how-to-print-values-from-a-datagridview-control">this answer</see>, although it has been heavily modified.
    /// </summary>
    public class RotaPrinter
    {
        #region Variables

        int iCellHeight = 0; //Used to get/set the datagridview cell height
        int iTotalWidth = 0; //
        int iRow = 0;//Used as counter
        bool bFirstPage = false; //Used to check whether we are printing first page
        bool bNewPage = false;// Used to check whether we are printing a new page
        int iHeaderHeight = 0; //Used for the header height
        StringFormat strFormat; //Used to format the grid rows.
        ArrayList arrColumnLefts = new ArrayList();//Used to save left coordinates of columns
        ArrayList arrColumnWidths = new ArrayList();//Used to save column widths
        private PrintDocument _printDocument = new PrintDocument();
        private DataGridView gw = new DataGridView();
        private string _ReportHeader;
        float[] maxCellWidth =new float[10];
        float maxColumnWidth = 0;
        int numColumns = 10;
        PrintPreviewDialog printPreviewDialog1;
        PrintDialog printDialog1;
        int currentPage = 1;
        bool isPreview = true;

        #endregion

        public RotaPrinter(DataGridView gridview, string ReportHeader)
        {
            printDialog1 = new PrintDialog();
            _printDocument.PrintPage += new PrintPageEventHandler(_printDocument_PrintPage);
            _printDocument.BeginPrint += new PrintEventHandler(_printDocument_BeginPrint);
            gw = Clone(gridview);
            _ReportHeader = ReportHeader;

            gw.Columns[1].HeaderText = "Name";
            gw.Columns[2].HeaderText = "Surname";

            gw.Columns[4].HeaderText = "Mon";
            gw.Columns[5].HeaderText = "Tue";
            gw.Columns[6].HeaderText = "Wed";
            gw.Columns[7].HeaderText = "Thu";
            gw.Columns[8].HeaderText = "Fri";
            gw.Columns[9].HeaderText = "Sat";
            gw.Columns[10].HeaderText = "Sun";
        }

        /// <summary>
        /// Performs a clone of the suppled DataGridView, as it has to be edited for printing
        /// and this was changing the Form view of it too.
        /// </summary>
        /// <param name="dg">The <see cref="System.Windows.Forms.DataGridView"/>to create a clone of.</param>
        /// <returns>A new <see cref="DataGridView"/> that is a clone of the old that can be edited freely.</returns>
        private DataGridView Clone(DataGridView dg)
        {
            DataGridView result = new DataGridView();
            foreach (DataGridViewColumn column in dg.Columns)
            {
                result.Columns.Add(column.Name, column.HeaderText);

            }
            foreach (DataGridViewRow row in dg.Rows)
            {
                DataGridViewRow newRow = (DataGridViewRow)row.Clone();
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    newRow.Cells[i].Value = row.Cells[i].Value;
                }
                result.Rows.Add(newRow);
            }
            return result;
        }

        /// <summary>
        /// Required to get the <see cref="PrintPreviewDialog"/> to display a <see cref="PrintDialog"/> when the Print icon is clicked.
        /// </summary>
        private void AlterPrintDialog()
        {
            
            printPreviewDialog1 = new PrintPreviewDialog();
            printPreviewDialog1.Document = _printDocument;

            //printDialog1.AllowSomePages = true;
            //printDialog1.AllowCurrentPage = true;
            //printDialog1.AllowSelection = true;

            ToolStripButton b = new ToolStripButton();
            b.Image = Properties.Resources.printer_icon;
            b.DisplayStyle = ToolStripItemDisplayStyle.Image;
            b.Click += printPreview_PrintClick;
            ((ToolStrip)(printPreviewDialog1.Controls[1])).Items.RemoveAt(0);
            ((ToolStrip)(printPreviewDialog1.Controls[1])).Items.Insert(0, b);
            printPreviewDialog1.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printPreview_PrintClick(object sender, EventArgs e)
        {
            try
            {
                printDialog1.Document = _printDocument;
                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    _printDocument.Print();
                    printPreviewDialog1.Close();
                    printPreviewDialog1.Dispose();
                }
            }
            catch (Exception ex)
            {
                Log.WriteLine(ex);
                MessageBox.Show(ex.Message, ToString());
            }
        }

        /// <summary>
        /// Sets the maximum width that any cell content will be. This is to ensure the grid lines up correctly.
        /// </summary>
        /// <param name="g">The <see cref="Graphics"/> object to use for drawing the rota.</param>
        private void SetMaxWidth(Graphics g)
        {
            foreach (DataGridViewColumn column in gw.Columns)
            {
                column.DefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            }
            for(int i = 1; i< gw.Columns.Count; i++)
            {
                float cw = g.MeasureString(gw.Columns[i].HeaderText.ToString(), gw.Columns[i].DefaultCellStyle.Font).Width;
                Log.WriteLine("String: " + gw.Columns[i].HeaderText.ToString() + " Has length: " + cw);
                if (cw > maxColumnWidth)
                {
                    maxColumnWidth = cw;
                }
            }
            foreach (DataGridViewRow row in gw.Rows)
            {
                for(int i =1; i<row.Cells.Count;i++)
                {
                    row.Cells[i].Style.Font = new Font("Arial", 10,FontStyle.Regular);
                    float width = 0;
                    if (i > 3)
                    {
                        width = g.MeasureString("Off12", row.Cells[i].InheritedStyle.Font).Width;
                    }
                    else
                    {
                        width = g.MeasureString(row.Cells[i].FormattedValue.ToString(), row.Cells[i].InheritedStyle.Font).Width;
                    }
                    if (width > maxCellWidth[i-1])
                    {
                        maxCellWidth[i-1] = width;
                    }
                }
            }

            for(int i = 0; i < maxCellWidth.Count(); i++)
            {
                Log.WriteLine($"Max column width: {maxColumnWidth} and current max cell width: {maxCellWidth[i]}");
                if (maxColumnWidth > maxCellWidth[i])
                {
                    maxCellWidth[i] = maxColumnWidth;
                }
            }
        }

        /// <summary>
        /// Starts the printing process.
        /// </summary>
        public void PrintForm()
        {
            ////Open the print dialog
            //PrintDialog printDialog = new PrintDialog();
            //printDialog.Document = _printDocument;
            //printDialog.UseEXDialog = true;

            ////Get the document
            //if (DialogResult.OK == printDialog.ShowDialog())
            //{
            //    _printDocument.DocumentName = "Test Page Print";
            //    _printDocument.Print();
            //}

            //Open the print preview dialog
            
            //PrintPreviewDialog objPPdialog = new PrintPreviewDialog();
            //objPPdialog.Document = _printDocument;
            _printDocument.DefaultPageSettings.Landscape = true;
            AlterPrintDialog();
            //objPPdialog.ShowDialog();
            //printPreviewDialog1.ShowDialog();
        }

        /// <summary>
        /// Called everytime another page is set to print. Handles the layout and drawing of the rota.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Log.WriteLine($"From Page: {e.PageSettings.PrinterSettings.FromPage} To Page: {e.PageSettings.PrinterSettings.ToPage}");
            SetMaxWidth(e.Graphics);
            //try
            //{
            //Set the left margin
            int iLeftMargin = e.MarginBounds.Left;
            //Set the top margin
            int iTopMargin = e.MarginBounds.Top;
            //Whether more pages have to print or not
            bool bMorePagesToPrint = false;
            int iTmpWidth = 0;

            //For the first page to print set the cell width and header height
            if (bFirstPage)
            {
                foreach (DataGridViewColumn GridCol in gw.Columns)
                {
                    iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                        (double)iTotalWidth * (double)iTotalWidth *
                        ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                    iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                        GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;

                    // Save width and height of headers
                    arrColumnLefts.Add(iLeftMargin);
                    arrColumnWidths.Add(iTmpWidth);
                    iLeftMargin += iTmpWidth;
                }
            }
            //Loop till all the grid rows not get printed
            while (iRow <= gw.Rows.Count - 1)
            {
                DataGridViewRow GridRow = gw.Rows[iRow];
                //Set the cell height
                iCellHeight = GridRow.Height + 5;
                int iCount = 0;
                //Check whether the current page settings allows more rows to print
                if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                {
                    bNewPage = true;
                    bFirstPage = false;
                    bMorePagesToPrint = true;
                    break;
                }
                else
                {

                    if (bNewPage)
                    {
                        //Draw Header
                        e.Graphics.DrawString(_ReportHeader,
                            new Font(gw.Font, FontStyle.Bold),
                            Brushes.Black, e.MarginBounds.Left,
                            e.MarginBounds.Top - e.Graphics.MeasureString(_ReportHeader,
                            new Font(gw.Font, FontStyle.Bold),
                            e.MarginBounds.Width).Height - 13);

                        String strDate = "";
                        //Draw Date
                        e.Graphics.DrawString(strDate,
                            new Font(gw.Font, FontStyle.Bold), Brushes.Black,
                            e.MarginBounds.Left +
                            (e.MarginBounds.Width - e.Graphics.MeasureString(strDate,
                            new Font(gw.Font, FontStyle.Bold),
                            e.MarginBounds.Width).Width),
                            e.MarginBounds.Top - e.Graphics.MeasureString(_ReportHeader,
                            new Font(new Font(gw.Font, FontStyle.Bold),
                            FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                        //Draw Columns                 
                        iTopMargin = e.MarginBounds.Top;
                        DataGridViewColumn[] _GridCol = new DataGridViewColumn[gw.Columns.Count];
                        int colcount = 0;
                        //Convert ltr to rtl
                        foreach (DataGridViewColumn GridCol in gw.Columns)
                        {
                            _GridCol[colcount++] = GridCol;
                        }
                        float headerOffset = e.MarginBounds.Left;
                        for (int i = 1;i<_GridCol.Count();i++)
                        {
                            e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                new Rectangle((int)headerOffset, iTopMargin,
                                (int)maxCellWidth[i-1], iHeaderHeight));

                            e.Graphics.DrawRectangle(Pens.Black,
                                new Rectangle((int)headerOffset, iTopMargin,
                                (int)maxCellWidth[i-1], iHeaderHeight));

                            e.Graphics.DrawString(_GridCol[i].HeaderText,
                                _GridCol[i].DefaultCellStyle.Font,
                                new SolidBrush(_GridCol[i].InheritedStyle.ForeColor),
                                new RectangleF((int)headerOffset, iTopMargin,
                                (int)maxCellWidth[i-1], iHeaderHeight), strFormat);
                            iCount++;
                            headerOffset += maxCellWidth[i - 1];
                        }
                        bNewPage = false;
                        iTopMargin += iHeaderHeight;
                        
                    }
                    iCount = 0;
                    DataGridViewCell[] _GridCell = new DataGridViewCell[GridRow.Cells.Count];
                    int cellcount = 0;
                    //Convert ltr to rtl
                    foreach (DataGridViewCell Cel in GridRow.Cells)
                    {
                        _GridCell[cellcount++] = Cel;
                    }
                    //Draw Columns Contents    
                    float offset = e.MarginBounds.Left;
                    for (int i = 1;i<_GridCell.Count();i++)
                    {
                        
                        if (_GridCell[i].Value != null)
                        {
                            try
                            {
                                int num = int.Parse(_GridCell[i].Value.ToString());
                                _GridCell[i].Value = (num == 1) ? "On" : "Off";
                            }
                            catch { }
                            //e.Graphics.DrawString(_GridCell[i].FormattedValue.ToString(),
                            //    _GridCell[i].InheritedStyle.Font,
                            //    new SolidBrush(_GridCell[i].InheritedStyle.ForeColor),
                            //    new RectangleF((int)arrColumnLefts[iCount],
                            //    (float)iTopMargin,
                            //    (int)arrColumnWidths[iCount], (float)iCellHeight),
                            //    strFormat);
                            e.Graphics.DrawString(_GridCell[i].FormattedValue.ToString(),
                                _GridCell[i].Style.Font,
                                new SolidBrush(_GridCell[i].InheritedStyle.ForeColor),
                                new RectangleF(offset,
                                (float)iTopMargin,
                                maxCellWidth[i-1], (float)iCellHeight),
                                strFormat);
                        }
                        //Drawing Cells Borders 
                        e.Graphics.DrawRectangle(Pens.Black,
                            new Rectangle((int)offset, iTopMargin,
                            (int)maxCellWidth[i-1], iCellHeight));
                        iCount++;
                        offset += maxCellWidth[i-1];
                    }
                }
                iRow++;
                iTopMargin += iCellHeight;
            }
            //If more lines exist, print another page.
            if (bMorePagesToPrint)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
            //}
            //catch (Exception exc)
            //{
            //    MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK,
            //       MessageBoxIcon.Error);
            //}
            currentPage++;
        }

        /// <summary>
        /// Not hugely sure what this does or where it is called. Maybe it isn't?
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _printDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Center;
                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Trimming = StringTrimming.EllipsisCharacter;

                arrColumnLefts.Clear();
                arrColumnWidths.Clear();
                iCellHeight = 0;
                iRow = 0;
                bFirstPage = true;
                bNewPage = true;

                // Calculating Total Widths
                iTotalWidth = 0;
                foreach (DataGridViewColumn dgvGridCol in gw.Columns)
                {
                    iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
