using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using ArmySIManagment.BuisnessLogic.Models;
using ArmySIManagment.BuisnessLogic.Models.SensitiveItems;
using ArmySIManagment.Connectors;

namespace ArmySIManagment.GUI.ViewModels
{
    public class AddSIItemViewModel : Screen
    {
        private string _equipmentName;
        private int _serialNumber;
        private string _adminNumber;
        private List<SensitiveItemBaseClass> _siList;

        public List<SensitiveItemBaseClass> SiList
        {
            get
            {
                return _siList;
            }
            set
            {
                _siList = value;
                NotifyOfPropertyChange(() => SiList);
            }
        }

        public string AdminNumber
        {
            get
            {
                return _adminNumber;
            }
            set
            {
                _adminNumber = value;
                NotifyOfPropertyChange(() => AdminNumber);
            }
        }

        public int SerialNumber
        {
            get
            {
                return _serialNumber;
            }
            set
            {
                _serialNumber = value;
                NotifyOfPropertyChange(() => SerialNumber);
            }
        }

        public string EquipmentName
        {
            get
            {
                return _equipmentName;
            }
            set
            {
                _equipmentName = value;
                NotifyOfPropertyChange(() => EquipmentName);
            }
        }

        public AddSIItemViewModel(List<SensitiveItemBaseClass> siList)
        {
            DisplayName = "Add Sensitive Item";
            SiList = siList;
        }
        public void AddItemBtn()
        {
            if(SerialNumber != 0 && EquipmentName != "" && AdminNumber != "")
            {
                SensitiveItemBaseClass si = new SensitiveItemBaseClass();
                si.EquipmentName = EquipmentName;
                si.SerialNumber = SerialNumber;
                si.RosterNumber = AdminNumber;
                SiList.Add(si);
                ArmyDataBaseConnector.SaveSensitiveItem(si);
                TryClose();
            }
        }
    }
}
