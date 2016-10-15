using System;
using System.Collections.Generic;
using System.Windows.Forms;
using InventorSearchPlugin.Configuration;
using InventorSearchPlugin.Entries;
using InventorSearchPlugin.Helpers;
using InventorSearchPlugin.Implementation;
using InventorSearchPlugin.Infrastructure;

namespace InvAddIn.UI
{
    public partial class SearchModelsForm : Form
    {
        private IRepository modelRepository = null;
        private IList<Model> modelsList = new List<Model>(); 
 
        private IList<string> openFileList = new List<string>();
        private IList<Model> modelPropertiesList = new List<Model>(); 
        private IList<Model> scaleFactorModelsList = new List<Model>(); 

        public SearchModelsForm()
        {
            InitializeComponent();
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            Settings.InitSettings();

            ClearLists();

            if (Validator.ValidateSearchFields(widthTextBox.Text, heightTextBox.Text, lengthTextBox.Text,
                    deviationTextBox.Text)
                && Validator.Validate(Settings.Host, Settings.Port, Settings.User, Settings.Password, Settings.DbName))
            {
                modelRepository = new ModelRepository(new ModelContext());

                SearchModel searchModel = new SearchModel();
                try
                {
                    searchModel = new SearchModel
                    {
                        Width = double.Parse(widthTextBox.Text),
                        Height = double.Parse(heightTextBox.Text),
                        Length = double.Parse(lengthTextBox.Text),
                        Deviation = double.Parse(deviationTextBox.Text)
                    };
                }
                catch (ArgumentNullException exception)
                {
                    MessageBox.Show("Passed null reference: " + exception, "Search Models - WARNING");
                }
                catch (FormatException exception)
                {
                    MessageBox.Show("The format of an argument is invalid: " + exception, "Search Models - WARNING");
                }
                catch (OverflowException exception)
                {
                    MessageBox.Show("Casting or conversation operation in context is overflow: " + exception, "Search Models - WARNING");
                }

                SearchModel tempModel = new SearchModel();
                double tempDeviation = searchModel.Deviation;

                if (searchModel.Deviation > 0)
                {
                    searchModel.Deviation /= 100;
                    tempModel.Width = searchModel.Width * searchModel.Deviation;
                    tempModel.Height = searchModel.Height * searchModel.Deviation;
                    tempModel.Length = searchModel.Length * searchModel.Deviation;

                    try
                    {
                        modelsList = modelRepository.GetModels(searchModel, tempModel, tempDeviation) as IList<Model>;
                    }
                    catch (ArgumentNullException exception)
                    {
                        MessageBox.Show("Passed null reference is passed: " + exception, "Search Models - WARNING");
                    }
                }
                else
                {
                    try
                    {
                        modelsList = modelRepository.GetModels(searchModel, tempModel, tempDeviation) as IList<Model>;
                    }
                    catch (ArgumentNullException exception)
                    {
                        MessageBox.Show("Passed null reference is passed: " + exception, "Search Models - WARNING");
                    }
                }

                LoadModelsFromDatabase(searchModel);
            }
        }

        private void ClearLists()
        {
            modelsList.Clear();
            openFileList.Clear();
            modelPropertiesList.Clear();
            scaleFactorModelsList.Clear();
        }

        private void LoadModelsFromDatabase(SearchModel searchModel)
        {
            if (modelsList != null && modelsList.Count > 0) 
            {
                foreach (var model in modelsList)
                {
                    openFileList.Add(model.ModelLocation);
                    modelPropertiesList.Add(model);
                }

                FilterModels(searchModel, modelPropertiesList, openFileList);
            }
            else
            {
                MessageBox.Show("Not matches in database", "Search Models");
            }
        }

        private void FilterModels(SearchModel searchModel, IList<Model> propetriesList, IList<string> fileList)
        {
            IList<double> detailPercentageDeviationList = new List<double>();

            double modelLength = searchModel.Length;
            double modelHeight = searchModel.Height;
            double modelWidth = searchModel.Width;

            double percentageDeviation = double.Parse(deviationTextBox.Text);
            double percentage = 100;

            for (int i = 0; i < propetriesList.Count; i++)
            {
                Model scaleModel = new Model
                {
                    Length = modelLength*propetriesList[i].Length,
                    Height = modelHeight*propetriesList[i].Height,
                    Width = modelWidth*propetriesList[i].Width,
                    ModelLocation = propetriesList[i].ModelLocation
                };


                if (((propetriesList[i].Length / modelLength) <= (percentageDeviation + percentage))
                    && ((propetriesList[i].Length / modelLength) >= (percentageDeviation - percentage))
                    && ((propetriesList[i].Height / modelHeight <= (percentageDeviation + percentage))
                    && ((propetriesList[i].Height / modelHeight) >= (percentageDeviation - percentage))
                    && ((propetriesList[i].Width / modelWidth) <= percentageDeviation + percentage))
                    && ((propetriesList[i].Width / modelWidth) >= (percentageDeviation - percentage)))
                {
                    double lengthDeviation = (propetriesList[i].Length - modelLength) / modelLength * percentage;
                    double heightDeviation = (propetriesList[i].Height - modelHeight) / modelHeight * percentage;
                    double widthDeviation = (propetriesList[i].Width - modelWidth) / modelWidth * percentage;

                    double averageValue = (lengthDeviation + heightDeviation + widthDeviation) / 3;

                    detailPercentageDeviationList.Add(averageValue);

                    scaleFactorModelsList.Add(scaleModel);
                }
            }
            ReflectText(fileList, detailPercentageDeviationList);
        }

        private void ReflectText(IList<string> fileList, IList<double> detailPercentageDeviationList)
        {
            if (scaleFactorCheckBox.Checked)
            {
                GetValue(fileList, detailPercentageDeviationList, true);
            }
            else
            {
                GetValue(fileList, detailPercentageDeviationList, false);
            }
        }

        private void GetValue(IList<string> fileList, IList<double> detailPercentageDeviationList, bool isScale)
        {
            IList<string> modelsInfoList = new List<string>();
            IDictionary<SearchModel, string> modelsInfoDictionary = new Dictionary<SearchModel, string>();
            string caption = null;
            
            for (int i = 0; i < fileList.Count; i++)
            {
                string modelLocation = fileList[i];

                if (isScale)
                {
                    SearchModel scaleModel = new SearchModel
                    {
                        Length = Math.Round(scaleFactorModelsList[i].Length, 2),
                        Height = Math.Round(scaleFactorModelsList[i].Height, 2),
                        Width = Math.Round(scaleFactorModelsList[i].Width, 2),
                        Deviation = Math.Round(detailPercentageDeviationList[i], 2)
                    };

                    string modelInfo = String.Format(
                        "File name: {0}, scale factor in Length: {1}, scale factor in Height: {2}, scale factor in Width: {3}, percentage deviation models {4}",
                            modelLocation, scaleModel.Length, scaleModel.Height, scaleModel.Width, scaleModel.Deviation);

                    modelsInfoDictionary.Add(scaleModel, modelLocation);

                    modelsInfoList.Add(modelInfo);

                    caption = String.Format("Found {0} modals with scaling factor", modelsInfoDictionary.Count);
                }
                else
                {
                    SearchModel model = new SearchModel
                    {
                        Height = modelPropertiesList[i].Height,
                        Length = modelPropertiesList[i].Length,
                        Width = modelPropertiesList[i].Width,
                        Deviation = Math.Round(detailPercentageDeviationList[i], 2)
                    };

                    double modelPercentage = detailPercentageDeviationList[i];

                    string modelInfo = String.Format("File name: {0}, percentage deviation models {1}",
                            modelLocation, modelPercentage);

                    modelsInfoList.Add(modelInfo);

                    modelsInfoDictionary.Add(model, modelLocation);

                    caption = String.Format("Found {0} modals without scaling factor", modelsInfoDictionary.Count);
                }
            }

            SearchResultsForm searchResultsForm = new SearchResultsForm(modelsInfoDictionary)
            {
                Text = caption
            };

            HideSearchModelsForm();

            searchResultsForm.ShowDialog();
        }

        private void HideSearchModelsForm()
        {
            this.Hide();
            this.Close();
        }

        private void scaleFactorCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            if (scaleFactorCheckBox.Checked)
            {
                scaleFactorCheckBox.Text = "On";
            }
            else
            {
                scaleFactorCheckBox.Text = "Off";                
            }
        }
    }
}
