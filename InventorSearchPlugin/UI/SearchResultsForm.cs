using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Inventor;
using InventorSearchPlugin.Entries;
using InventorSearchPlugin.Global;

namespace InvAddIn.UI
{
    
    public partial class SearchResultsForm : Form
    {
        private IDictionary<SearchModel, string> openModelsInAssemblyDictionary = new Dictionary<SearchModel, string>();

        public SearchResultsForm()
        {
            InitializeComponent();
        }

        public SearchResultsForm(IDictionary<SearchModel, string> scaleModelsInfoDictionary)
        {
            InitializeComponent();

            foreach (KeyValuePair<SearchModel, string> pair in scaleModelsInfoDictionary.OrderBy(m => m.Key.Deviation))
            {
                resultsDataGridView.Rows.Add(null, pair.Key.Deviation, pair.Key.Height, pair.Key.Length, pair.Key.Width, pair.Value);
            }
        }

        private void OpenAssemblyDocument()
        {
            Matrix matrix = AddInGlobal.InventorApp.TransientGeometry.CreateMatrix();

            Inventor.Point point;

            Vector xVector;
            Vector yVector;
            Vector zVector;

            AssemblyDocument assemblyDocument = AddInGlobal.InventorApp.Documents.Add(DocumentTypeEnum.kAssemblyDocumentObject) as AssemblyDocument;

            matrix.GetCoordinateSystem(out point, out xVector, out yVector, out zVector);

            int index = 0;

            foreach (KeyValuePair<SearchModel, string> pair in openModelsInAssemblyDictionary)
            {
                matrix.SetCoordinateSystem(point, xVector, yVector, zVector);
                assemblyDocument.ComponentDefinition.Occurrences.Add(pair.Value, matrix);

                point.X += ((++index) < openModelsInAssemblyDictionary.Count) ? 15 : 0;
                point.Y += (index < openModelsInAssemblyDictionary.Count) ? 15 : 0; 
            }

            openModelsInAssemblyDictionary.Clear();
        }

        private void addToAssembly_Click(object sender, System.EventArgs e)
        {
            bool isChecked =
                Convert.ToBoolean(
                    resultsDataGridView.Rows[resultsDataGridView.CurrentCell.RowIndex].Cells[0].Value.ToString());
            
            if (isChecked)
            {
                foreach (DataGridViewRow row in resultsDataGridView.Rows)
                {
                    bool isSelected = Convert.ToBoolean(row.Cells["checkModel"].Value);
                    if (isSelected)
                    {
                        var modelLocation = row.Cells["location"].Value.ToString();

                        SearchModel selectModel = new SearchModel
                        {
                            Height = (double) row.Cells["height"].Value,
                            Length = (double) row.Cells["length"].Value,
                            Width = (double) row.Cells["width"].Value
                        };

                        openModelsInAssemblyDictionary.Add(selectModel, modelLocation);
                    }
                }
                addToAssembly.Enabled = false;
                buildAssembly.Enabled = true;
            }
        }

        private void buildAssembly_Click(object sender, EventArgs e)
        {
            OpenAssemblyDocument();
        }

        private void selectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in resultsDataGridView.Rows)
            {
                row.Cells["checkModel"].Value = true;
            }
        }
    }
}
