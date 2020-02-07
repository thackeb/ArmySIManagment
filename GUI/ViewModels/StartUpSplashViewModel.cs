using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using Microsoft.Win32;

namespace ArmySIManagment.GUI.ViewModels
{
    public class StartUpSplashViewModel : Conductor<Screen>
    {
        private WindowManager _windowManager { get; set; }
        private MainViewModel _mainViewModel { get; set; }
        public StartUpSplashViewModel()
        {
    
            _windowManager = new WindowManager();
            _excelSheetFilePath = "Select a File";
        }

        private string _excelSheetFilePath;

        
        public string ExcelSheetFilePath
        {
            get
            {
                return _excelSheetFilePath;
            }
            set
            {
                _excelSheetFilePath = value;
                NotifyOfPropertyChange(() => ExcelSheetFilePath );
            }
        }

        public void SelectExcelSheet()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();

            try
            { 
                ExcelSheetFilePath= openFileDialog1.FileName;
            }
            catch (SecurityException ex)
            {
                MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                $"Details:\n\n{ex.StackTrace}");
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Can not open an Excel Sheet while it is in use by another program");
            }
        }

       
        public void Start()
        {
            if (ExcelSheetFilePath == "Select a File" || ExcelSheetFilePath == "")
            {
                _mainViewModel = new MainViewModel();
                _windowManager.ShowWindow(_mainViewModel);
                this.TryClose();
            }
            else
            {
                _mainViewModel = new MainViewModel(ExcelSheetFilePath);
                _windowManager.ShowWindow(_mainViewModel);
                this.TryClose();
            }
        }

    }
}
